using Bridge.Contract;
using Bridge.Contract.Constants;
using ICSharpCode.NRefactory.CSharp;
using Microsoft.Ajax.Utilities;
using Mono.Cecil;
using Object.Net.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.Utils;
using TopologicalSorting;
using AssemblyDefinition = Mono.Cecil.AssemblyDefinition;

namespace Bridge.Translator
{
    public partial class Translator : ITranslator
    {
        public const string Bridge_ASSEMBLY = CS.NS.BRIDGE;
        public const string Bridge_ASSEMBLY_DOT = Bridge_ASSEMBLY + ".";
        public const string BridgeResourcesPlusSeparatedFormatList = "Bridge.Resources.list";
        public const string BridgeResourcesJsonFormatList = "Bridge.Resources.json";
        public const string BridgeResourcesCombinedPrefix = "Bridge.Resources.Parts.";
        public const string LocalesPrefix = "Bridge.Resources.Locales.";
        public const string DefaultLocalesOutputName = "Bridge.Locales.js";
        public const string BridgeConsoleName = "bridge.console.js";
        public const string SupportedProjectType = "Library";
        public const string DefaultRootNamespace = "ClassLibrary";
        public const string SystemAssemblyName = "mscorlib";

        public static readonly Encoding OutputEncoding = new UTF8Encoding(false);
        private static readonly string[] MinifierCodeSettingsInternalFileNames = new string[] { "bridge.js", "bridge.min.js", "bridge.collections.js", "bridge.collections.min.js" };

        private char[] invalidPathChars;
        public char[] InvalidPathChars
        {
            get
            {
                if (invalidPathChars == null)
                {
                    var l = new List<char>(Path.GetInvalidPathChars());
                    l.AddRange(new char[] { '<', '>', ':', '"', '|', '?', '*' });
                    invalidPathChars = l.Distinct().ToArray();
                }

                return invalidPathChars;
            }
        }

        public FileHelper FileHelper
        {
            get; private set;
        }

        private static readonly CodeSettings MinifierCodeSettingsSafe = new CodeSettings
        {
            EvalTreatment = Microsoft.Ajax.Utilities.EvalTreatment.MakeAllSafe,
            LocalRenaming = Microsoft.Ajax.Utilities.LocalRenaming.KeepAll,
            TermSemicolons = true,
            StrictMode = false
        };

        private static readonly CodeSettings MinifierCodeSettingsInternal = new CodeSettings
        {
            TermSemicolons = true,
            StrictMode = false
        };

        private static readonly CodeSettings MinifierCodeSettingsLocales = new CodeSettings
        {
            TermSemicolons = true
        };

        protected Translator(string location)
        {
            this.Location = location;
            this.Validator = this.CreateValidator();
            this.DefineConstants = new List<string>() { "BRIDGE" };
            this.ProjectProperties = new ProjectProperties();
            this.FileHelper = new FileHelper();
            this.Outputs = new TranslatorOutput();
        }

        public Translator(string location, string source, bool fromTask = false) : this(location)
        {
            this.FromTask = fromTask;
            this.Source = source;
        }

        public Translator(string location, string source, bool recursive, string lib) : this(location, source, false)
        {
            this.Recursive = recursive;
            this.AssemblyLocation = lib;
            this.FolderMode = true;
            this.Outputs = new TranslatorOutput();
        }

        public void Translate()
        {
            var logger = this.Log;
            logger.Info("Translating...");

            var config = this.AssemblyInfo;

            if (this.Rebuild)
            {
                logger.Info("Building assembly as Rebuild option is enabled");
                this.BuildAssembly();
            }
            else if (!File.Exists(this.AssemblyLocation))
            {
                logger.Info("Building assembly as it is not found at " + this.AssemblyLocation);
                this.BuildAssembly();
            }

            this.Outputs.Report = new TranslatorOutputItem
            {
                Content = new StringBuilder(),
                OutputKind = TranslatorOutputKind.Report,
                OutputType = TranslatorOutputType.None,
                Name = this.AssemblyInfo.Report.FileName ?? "bridge.report.log",
                Location = this.AssemblyInfo.Report.Path
            };

            var references = this.InspectReferences();
            this.References = references;

            this.LogProductInfo();

            this.Plugins = Bridge.Translator.Plugins.GetPlugins(this, config, logger);

            logger.Info("Reading plugin configs...");
            this.Plugins.OnConfigRead(config);
            logger.Info("Reading plugin configs done");

            if (!string.IsNullOrWhiteSpace(config.BeforeBuild))
            {
                try
                {
                    logger.Info("Running BeforeBuild event " + config.BeforeBuild + " ...");
                    this.RunEvent(config.BeforeBuild);
                    logger.Info("Running BeforeBuild event done");
                }
                catch (System.Exception exc)
                {
                    var message = "Error: Unable to run beforeBuild event command: " + exc.Message + "\nStack trace:\n" + exc.StackTrace;

                    logger.Error("Exception occurred. Message: " + message);

                    throw new Bridge.Translator.TranslatorException(message);
                }
            }

            this.BuildSyntaxTree();


            var resolver = new MemberResolver(this.ParsedSourceFiles, Emitter.ToAssemblyReferences(references, logger), this.AssemblyDefinition);
            resolver = this.Preconvert(resolver, config);

            this.InspectTypes(resolver, config);

            resolver.CanFreeze = true;
            var emitter = this.CreateEmitter(resolver);

            if (!this.AssemblyInfo.OverflowMode.HasValue)
            {
                this.AssemblyInfo.OverflowMode = this.OverflowMode;
            }

            emitter.Translator = this;
            emitter.AssemblyInfo = this.AssemblyInfo;
            emitter.References = references;
            emitter.SourceFiles = this.SourceFiles;
            emitter.Log = this.Log;
            emitter.Plugins = this.Plugins;
            emitter.InitialLevel = 1;

            if (this.AssemblyInfo.Module != null)
            {
                this.AssemblyInfo.Module.Emitter = emitter;
            }

            foreach(var td in this.TypeInfoDefinitions)
            {
                if (td.Value.Module != null)
                {
                    td.Value.Module.Emitter = emitter;
                }
            }

            this.SortReferences();

            logger.Info("Before emitting...");
            this.Plugins.BeforeEmit(emitter, this);
            logger.Info("Before emitting done");

            this.AddMainOutputs(emitter.Emit());
            this.EmitterOutputs = emitter.Outputs;

            logger.Info("After emitting...");
            this.Plugins.AfterEmit(emitter, this);
            logger.Info("After emitting done");

            logger.Info("Translating done");
        }

        protected virtual MemberResolver Preconvert(MemberResolver resolver, IAssemblyInfo config)
        {
            bool needRecompile = false;
            foreach (var sourceFile in this.ParsedSourceFiles)
            {
                this.Log.Trace("Preconvert " + sourceFile.ParsedFile.FileName);
                var syntaxTree = sourceFile.SyntaxTree;
                var tempEmitter = new TempEmitter { AssemblyInfo = config };
                var detecter = new PreconverterDetecter(resolver, tempEmitter);
                syntaxTree.AcceptVisitor(detecter);

                if (detecter.Found)
                {
                    var fixer = new PreconverterFixer(resolver, tempEmitter, this.Log);
                    var astNode = syntaxTree.AcceptVisitor(fixer);
                    syntaxTree = astNode != null ? (SyntaxTree)astNode : syntaxTree;
                    sourceFile.SyntaxTree = syntaxTree;
                    needRecompile = true;
                }
            }

            if (needRecompile)
            {
                return new MemberResolver(this.ParsedSourceFiles, resolver.Assemblies, this.AssemblyDefinition);
            }

            return resolver;
        }

        protected virtual void SortReferences()
        {
            var graph = new TopologicalSorting.DependencyGraph();

            foreach (var t in this.References)
            {
                var tProcess = graph.Processes.FirstOrDefault(p => p.Name == t.Name.Name);

                if (tProcess == null)
                {
                    tProcess = new TopologicalSorting.OrderedProcess(graph, t.Name.Name);
                }

                foreach (var xref in t.MainModule.AssemblyReferences)
                {
                    var dProcess = graph.Processes.FirstOrDefault(p => p.Name == xref.Name);

                    if (dProcess == null)
                    {
                        dProcess = new TopologicalSorting.OrderedProcess(graph, xref.Name);
                    }

                    tProcess.After(dProcess);
                }
            }

            if (graph.ProcessCount > 0)
            {
                AssemblyDefinition asmDef = null;

                try
                {
                    var list = new List<AssemblyDefinition>(this.References.Count());

                    this.Log.Trace("Sorting references...");

                    this.Log.Trace("\t\tCalculate sorting references...");
                    //IEnumerable<IEnumerable<OrderedProcess>> sorted = graph.CalculateSort();
                    TopologicalSort sorted = graph.CalculateSort();
                    this.Log.Trace("\t\tCalculate sorting references done");

                    // The fix required for Mono 5.0.0.94
                    // It does not "understand" TopologicalSort's Enumerator in foreach
                    // foreach (var processes in sorted)
                    // The code is modified to get it "directly" and "typed"
                    var sortedISetEnumerable = sorted as IEnumerable<ISet<OrderedProcess>>;
                    this.Log.Trace("\t\tGot Enumerable<ISet<OrderedProcess>>");

                    var sortedISetEnumerator = sortedISetEnumerable.GetEnumerator();
                    this.Log.Trace("\t\tGot Enumerator<ISet<OrderedProcess>>");

                    //foreach (var processes in sorted)
                    while (sortedISetEnumerator.MoveNext())
                    {
                        var processes = sortedISetEnumerator.Current;

                        foreach (var process in processes)
                        {
                            this.Log.Trace("\tHandling " + process.Name);

                            asmDef = this.References.FirstOrDefault(r => r.Name.Name == process.Name);

                            if (asmDef != null && list.All(r => r.Name.Name != asmDef.Name.Name))
                            {
                                list.Add(asmDef);
                            }
                        }
                    }

                    this.References = list;

                    this.Log.Trace("Sorting references done:");

                    for (int i = 0; i < list.Count; i++)
                    {
                        this.Log.Trace("\t" + list[i].Name);
                    }
                }
                catch (System.Exception ex)
                {
                    this.Log.Warn(string.Format("Topological sort failed {0} with error {1}", asmDef != null ? "at reference " + asmDef.FullName : string.Empty, ex));
                }
            }
        }

        private static void NewLine(StringBuilder sb, string line = null)
        {
            if (line != null)
            {
                sb.Append(line);
            }

            sb.Append(Emitter.NEW_LINE);
        }

        private static void NewLine(MemoryStream sb, string line = null)
        {
            if (line != null)
            {
                var b = OutputEncoding.GetBytes(line);
                sb.Write(b, 0, b.Length);
            }

            var nl = OutputEncoding.GetBytes(Emitter.NEW_LINE);
            sb.Write(nl, 0, nl.Length);
        }

        public bool CheckIfRequiresSourceMap(TranslatorOutputItem output)
        {
            return !output.IsEmpty
                && output.OutputType == TranslatorOutputType.JavaScript
                && output.OutputKind.HasFlag(TranslatorOutputKind.ProjectOutput)
                && !output.OutputKind.HasFlag(TranslatorOutputKind.Locale)
                && !output.OutputKind.HasFlag(TranslatorOutputKind.PluginOutput)
                && !output.OutputKind.HasFlag(TranslatorOutputKind.Reference)
                && !output.OutputKind.HasFlag(TranslatorOutputKind.Resource)
                && !output.OutputKind.HasFlag(TranslatorOutputKind.Metadata);
        }

        public bool CheckIfRequiresSourceMap(BridgeResourceInfoPart resourcePart)
        {
            var fileHelper = new FileHelper();

            return resourcePart != null
                && resourcePart.Assembly == null // i.e. this assembly output
                && fileHelper.IsJS(resourcePart.Name);
        }

        public TranslatorOutputItem FindTranslatorOutputItem(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return null;
            }

            foreach (var output in this.Outputs.GetOutputs())
            {
                if (output.FullPath.LocalPath == filePath)
                {
                    return output;
                }
            }

            return null;
        }

        public string GenerateSourceMap(string fileName, string content, Action<SourceMapBuilder> before = null)
        {
            if (this.AssemblyInfo.SourceMap.Enabled)
            {
                var projectPath = Path.GetDirectoryName(this.Location);

                SourceMapGenerator.Generate(fileName, projectPath, ref content,
                    before,
                    (sourceRelativePath) =>
                    {
                        string path = null;
                        ParsedSourceFile sourceFile = null;

                        try
                        {
                            path = Path.Combine(projectPath, sourceRelativePath);
                            sourceFile = this.ParsedSourceFiles.First(pf => pf.ParsedFile.FileName == path);

                            return sourceFile.SyntaxTree.TextSource ?? sourceFile.SyntaxTree.ToString(Translator.GetFormatter());
                        }
                        catch (Exception ex)
                        {
                            throw (TranslatorException)TranslatorException.Create(
                                "Could not get ParsedSourceFile for SourceMap. Exception: {0}; projectPath: {1}; sourceRelativePath: {2}; path: {3}.",
                                ex.ToString(), projectPath, sourceRelativePath, path);
                        }

                    },
                    new string[0], this.SourceFiles, this.AssemblyInfo.SourceMap.Eol, this.Log
                );
            }

            return content;
        }

        private static CSharpFormattingOptions GetFormatter()
        {
            var formatter = FormattingOptionsFactory.CreateSharpDevelop();
            formatter.AnonymousMethodBraceStyle = BraceStyle.NextLine;
            formatter.MethodBraceStyle = BraceStyle.NextLine;
            formatter.StatementBraceStyle = BraceStyle.NextLine;
            formatter.PropertyBraceStyle = BraceStyle.NextLine;
            formatter.ConstructorBraceStyle = BraceStyle.NextLine;
            formatter.NewLineAfterConstructorInitializerColon = NewLinePlacement.NewLine;
            formatter.NewLineAferMethodCallOpenParentheses = NewLinePlacement.NewLine;
            formatter.ClassBraceStyle = BraceStyle.NextLine;
            formatter.ArrayInitializerBraceStyle = BraceStyle.NextLine;
            formatter.IndentPreprocessorDirectives = false;

            return formatter;
        }

        public void RunAfterBuild()
        {
            this.Log.Info("Checking AfterBuild event...");

            if (!string.IsNullOrWhiteSpace(this.AssemblyInfo.AfterBuild))
            {
                try
                {
                    this.Log.Trace("Run AfterBuild event");
                    this.RunEvent(this.AssemblyInfo.AfterBuild);
                }
                catch (System.Exception ex)
                {
                    var message = "Error: Unable to run afterBuild event command: " + ex.ToString();

                    this.Log.Error(message);
                    throw new Bridge.Translator.TranslatorException(message);
                }
            }
            else
            {
                this.Log.Trace("No AfterBuild event specified");
            }

            this.Log.Info("Done checking AfterBuild event...");
        }

        protected virtual Emitter CreateEmitter(IMemberResolver resolver)
        {
            this.Log.Info("Creating emitter...");

            var emitter = new Emitter(this.TypeDefinitions, this.BridgeTypes, this.Types, this.Validator, resolver, this.TypeInfoDefinitions, this.Log);

            this.Log.Info("Creating emitter done");

            return emitter;
        }

        protected virtual Validator CreateValidator()
        {
            return new Validator();
        }

        public EmitterException CreateExceptionFromLastNode()
        {
            return this.EmitNode != null ? new EmitterException(this.EmitNode) : null;
        }
    }
}