using Bridge.Contract.Constants;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.TypeSystem;
using Mono.Cecil;
using Object.Net.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ArrayType = ICSharpCode.NRefactory.TypeSystem.ArrayType;
using ByReferenceType = ICSharpCode.NRefactory.TypeSystem.ByReferenceType;

namespace Bridge.Contract
{
    public class BridgeType
    {
        public BridgeType(string key)
        {
            this.Key = key;
        }

        public virtual IEmitter Emitter
        {
            get;
            set;
        }

        public virtual string Key
        {
            get;
            private set;
        }

        public virtual TypeDefinition TypeDefinition
        {
            get;
            set;
        }

        public virtual IType Type
        {
            get;
            set;
        }

        public virtual ITypeInfo TypeInfo
        {
            get;
            set;
        }

        public Module Module
        {
            get;
            set;
        }
    }

    public class BridgeTypes : Dictionary<string, BridgeType>
    {
        private Dictionary<IType, BridgeType> byType = new Dictionary<IType, BridgeType>();
        private Dictionary<TypeReference, BridgeType> byTypeRef = new Dictionary<TypeReference, BridgeType>();
        private Dictionary<ITypeInfo, BridgeType> byTypeInfo = new Dictionary<ITypeInfo, BridgeType>();
        public void InitItems(IEmitter emitter)
        {
            var logger = emitter.Log;

            logger.Trace("Initializing items for Bridge types...");

            this.Emitter = emitter;
            byType = new Dictionary<IType, BridgeType>();
            foreach (var item in this)
            {
                var type = item.Value;
                var key = BridgeTypes.GetTypeDefinitionKey(type.TypeDefinition);
                type.Emitter = emitter;
                type.Type = ReflectionHelper.ParseReflectionName(key).Resolve(emitter.Resolver.Resolver.TypeResolveContext);
                type.TypeInfo = emitter.Types.FirstOrDefault(t => t.Key == key);

                if (type.TypeInfo != null && emitter.TypeInfoDefinitions.ContainsKey(type.TypeInfo.Key))
                {
                    var typeInfo = this.Emitter.TypeInfoDefinitions[type.Key];

                    type.TypeInfo.Module = typeInfo.Module;
                    type.TypeInfo.FileName = typeInfo.FileName;
                    type.TypeInfo.Dependencies = typeInfo.Dependencies;
                }
            }

            logger.Trace("Initializing items for Bridge types done");
        }

        public IEmitter Emitter
        {
            get;
            set;
        }

        public BridgeType Get(string key)
        {
            return this[key];
        }

        public BridgeType Get(TypeDefinition type, bool safe = false)
        {
            foreach (var item in this)
            {
                if (item.Value.TypeDefinition == type)
                {
                    return item.Value;
                }
            }

            if (!safe)
            {
                throw new Exception("Cannot find type: " + type.FullName);
            }

            return null;
        }

        public BridgeType Get(TypeReference type, bool safe = false)
        {
            BridgeType bType;

            if (this.byTypeRef.TryGetValue(type, out bType))
            {
                return bType;
            }

            var name = type.FullName;
            if (type.IsGenericInstance)
            {
                if (this.byTypeRef.TryGetValue(type.GetElementType(), out bType))
                {
                    return bType;
                }

                name = type.GetElementType().FullName;
            }

            foreach (var item in this)
            {
                if (item.Value.TypeDefinition.FullName == name)
                {
                    this.byTypeRef[type] = item.Value;
                    if (type.IsGenericInstance && type != type.GetElementType())
                    {
                        this.byTypeRef[type.GetElementType()] = item.Value;
                    }

                    return item.Value;
                }
            }

            if (!safe)
            {
                throw new Exception("Cannot find type: " + type.FullName);
            }

            return null;
        }

        public BridgeType Get(IType type, bool safe = false)
        {
            BridgeType bType;

            if (this.byType.TryGetValue(type, out bType))
            {
                return bType;
            }

            var originalType = type;
            if (type.IsParameterized)
            {
                type = ((ParameterizedTypeReference)type.ToTypeReference()).GenericType.Resolve(this.Emitter.Resolver.Resolver.TypeResolveContext);
            }

            if (type is ByReferenceType)
            {
                type = ((ByReferenceType)type).ElementType;
            }

            if (this.byType.TryGetValue(type, out bType))
            {
                return bType;
            }

            foreach (var item in this)
            {
                if (item.Value.Type.Equals(type))
                {
                    this.byType[type] = item.Value;

                    if (!type.Equals(originalType))
                    {
                        this.byType[originalType] = item.Value;
                    }

                    return item.Value;
                }
            }

            if (!safe)
            {
                throw new Exception("Cannot find type: " + type.ReflectionName);
            }

            return null;
        }

        public BridgeType Get(ITypeInfo type, bool safe = false)
        {
            BridgeType bType;

            if (this.byTypeInfo.TryGetValue(type, out bType))
            {
                return bType;
            }

            foreach (var item in this)
            {
                if (this.Emitter.GetReflectionName(item.Value.Type) == type.Key)
                {
                    this.byTypeInfo[type] = item.Value;
                    return item.Value;
                }
            }

            if (!safe)
            {
                throw new Exception("Cannot find type: " + type.Key);
            }

            return null;
        }

        public IType ToType(AstType type)
        {
            var resolveResult = this.Emitter.Resolver.ResolveNode(type, this.Emitter);
            return resolveResult.Type;
        }

        public static string GetParentNames(IEmitter emitter, TypeDefinition typeDef)
        {
            List<string> names = new List<string>();
            while (typeDef.DeclaringType != null)
            {
                names.Add(BridgeTypes.ToJsName(typeDef.DeclaringType, emitter, true, true));
                typeDef = typeDef.DeclaringType;
            }

            names.Reverse();
            return names.Join(".");
        }

        public static string GetParentNames(IEmitter emitter, IType type)
        {
            List<string> names = new List<string>();
            while (type.DeclaringType != null)
            {
                var name = BridgeTypes.ConvertName(BridgeTypes.ToJsName(type.DeclaringType, emitter, true, true));

                if (type.DeclaringType.TypeArguments.Count > 0)
                {
                    name += Helpers.PrefixDollar(type.TypeArguments.Count);
                }
                names.Add(name);
                type = type.DeclaringType;
            }

            names.Reverse();
            return names.Join(".");
        }

        public static string GetGlobalTarget(ITypeDefinition typeDefinition, AstNode node, bool removeGlobal = false)
        {
            string globalTarget = null;
            var globalMethods = typeDefinition.Attributes.FirstOrDefault(a => a.AttributeType.FullName == "Bridge.GlobalMethodsAttribute");

            if (globalMethods != null)
            {
                var value = globalMethods.PositionalArguments.Count > 0 && (bool)globalMethods.PositionalArguments.First().ConstantValue;
                globalTarget = !removeGlobal || value ? JS.Types.Bridge.Global.NAME : "";
            }
            else
            {
                var mixin = typeDefinition.Attributes.FirstOrDefault(a => a.AttributeType.FullName == "Bridge.MixinAttribute");

                if (mixin != null)
                {
                    var value = mixin.PositionalArguments.First().ConstantValue;
                    if (value != null)
                    {
                        globalTarget = value.ToString();
                    }

                    if (string.IsNullOrEmpty(globalTarget))
                    {
                        throw new EmitterException(node, string.Format("The argument to the [MixinAttribute] for the type {0} must not be null or empty.", typeDefinition.FullName));
                    }
                }
            }

            return globalTarget;
        }

        public static string ToJsName(IType type, IEmitter emitter, bool asDefinition = false, bool excludens = false, bool isAlias = false, bool skipMethodTypeParam = false, bool removeScope = true, bool nomodule = false, bool ignoreLiteralName = true, bool ignoreVirtual = false, bool excludeTypeOnly = false)
        {
            var itypeDef = type.GetDefinition();
            BridgeType bridgeType = emitter.BridgeTypes.Get(type, true);

            if (itypeDef != null)
            {
                string globalTarget = BridgeTypes.GetGlobalTarget(itypeDef, null, removeScope);

                if (globalTarget != null)
                {
                    if (bridgeType != null && !nomodule)
                    {
                        bool customName;
                        globalTarget = BridgeTypes.AddModule(globalTarget, bridgeType, excludens, false, out customName);
                    }
                    return globalTarget;
                }
            }

            if (itypeDef != null && itypeDef.Attributes.Any(a => a.AttributeType.FullName == "Bridge.NonScriptableAttribute"))
            {
                throw new EmitterException(emitter.Translator.EmitNode, "Type " + type.FullName + " is marked as not usable from script");
            }

            if (type.Kind == TypeKind.Array)
            {
                var arrayType = type as ArrayType;

                if (arrayType != null && arrayType.ElementType != null)
                {
                    var elementAlias = BridgeTypes.ToJsName(arrayType.ElementType, emitter, asDefinition, excludens, isAlias, skipMethodTypeParam, excludeTypeOnly: excludeTypeOnly);

                    if (isAlias)
                    {
                        return $"{elementAlias}$Array{(arrayType.Dimensions > 1 ? "$" + arrayType.Dimensions : "")}";
                    }

                    if (arrayType.Dimensions > 1)
                    {
                        return string.Format(JS.Types.System.Array.TYPE + "({0}, {1})", elementAlias, arrayType.Dimensions);
                    }
                    return string.Format(JS.Types.System.Array.TYPE + "({0})", elementAlias);
                }

                return JS.Types.ARRAY;
            }

            if (type.Kind == TypeKind.Delegate)
            {
                return JS.Types.FUNCTION;
            }

            if (type.Kind == TypeKind.Dynamic)
            {
                return JS.Types.System.Object.NAME;
            }

            if (type is ByReferenceType)
            {
                return BridgeTypes.ToJsName(((ByReferenceType)type).ElementType, emitter, asDefinition, excludens, isAlias, skipMethodTypeParam, excludeTypeOnly: excludeTypeOnly);
            }

            if (ignoreLiteralName)
            {
                var isObjectLiteral = itypeDef != null && emitter.Validator.IsObjectLiteral(itypeDef);
                var isPlainMode = isObjectLiteral && emitter.Validator.GetObjectCreateMode(emitter.GetTypeDefinition(type)) == 0;

                if (isPlainMode)
                {
                    return "System.Object";
                }
            }

            if (type.Kind == TypeKind.Anonymous)
            {
                var at = type as AnonymousType;
                if (at != null && emitter.AnonymousTypes.ContainsKey(at))
                {
                    return emitter.AnonymousTypes[at].Name;
                }
                else
                {
                    return JS.Types.System.Object.NAME;
                }
            }

            var typeParam = type as ITypeParameter;
            if (typeParam != null)
            {
                if ((skipMethodTypeParam || excludeTypeOnly) && (typeParam.OwnerType == SymbolKind.Method) || Helpers.IsIgnoreGeneric(typeParam.Owner, emitter))
                {
                    return JS.Types.System.Object.NAME;
                }
            }

            var name = excludens ? "" : type.Namespace;

            var hasTypeDef = bridgeType != null && bridgeType.TypeDefinition != null;
            var isNested = false;
            if (hasTypeDef)
            {
                var typeDef = bridgeType.TypeDefinition;

                if (typeDef.IsNested && !excludens)
                {
                    name = BridgeTypes.ToJsName(typeDef.DeclaringType, emitter, true, ignoreVirtual: true, nomodule: nomodule);
                    isNested = true;
                }

                name = (string.IsNullOrEmpty(name) ? "" : (name + ".")) + BridgeTypes.ConvertName(emitter.GetTypeName(itypeDef, typeDef));
            }
            else
            {
                if (type.DeclaringType != null && !excludens)
                {
                    name = BridgeTypes.ToJsName(type.DeclaringType, emitter, true, ignoreVirtual: true);
                    isNested = true;
                }

                name = (string.IsNullOrEmpty(name) ? "" : (name + ".")) + BridgeTypes.ConvertName(type.Name);
            }

            bool isCustomName = false;
            if (bridgeType != null)
            {
                if (nomodule)
                {
                    name = GetCustomName(name, bridgeType, excludens, isNested, ref isCustomName, null);
                }
                else
                {
                    name = BridgeTypes.AddModule(name, bridgeType, excludens, isNested, out isCustomName);
                }
            }

            var tDef = type.GetDefinition();
            var skipSuffix = tDef != null && tDef.ParentAssembly.AssemblyName != CS.NS.BRIDGE && emitter.Validator.IsExternalType(tDef) && Helpers.IsIgnoreGeneric(tDef);

            if (!hasTypeDef && !isCustomName && type.TypeArguments.Count > 0 && !skipSuffix)
            {
                name += Helpers.PrefixDollar(type.TypeArguments.Count);
            }

            var genericSuffix = "$" + type.TypeArguments.Count;
            if (skipSuffix && !isCustomName && type.TypeArguments.Count > 0 && name.EndsWith(genericSuffix))
            {
                name = name.Substring(0, name.Length - genericSuffix.Length);
            }

            if (isAlias)
            {
                name = OverloadsCollection.NormalizeInterfaceName(name);
            }

            if (type.TypeArguments.Count > 0 && !Helpers.IsIgnoreGeneric(type, emitter) && !asDefinition && !skipMethodTypeParam)
            {
                if (isAlias)
                {
                    StringBuilder sb = new StringBuilder(name);
                    bool needComma = false;
                    sb.Append(JS.Vars.D);
                    bool isStr = false;
                    foreach (var typeArg in type.TypeArguments)
                    {
                        if (sb.ToString().EndsWith(")"))
                        {
                            sb.Append(" + \"");
                        }

                        if (needComma && !sb.ToString().EndsWith(JS.Vars.D.ToString()))
                        {
                            sb.Append(JS.Vars.D);
                        }

                        needComma = true;
                        var isTypeParam = typeArg.Kind == TypeKind.TypeParameter;
                        bool needGet = isTypeParam && !asDefinition && !excludeTypeOnly;
                        if (needGet)
                        {
                            if (!isStr)
                            {
                                sb.Insert(0, "\"");
                                isStr = true;
                            }
                            sb.Append("\" + " + JS.Types.Bridge.GET_TYPE_ALIAS + "(");
                        }

                        var typeArgName = BridgeTypes.ToJsName(typeArg, emitter, asDefinition, false, true, skipMethodTypeParam, ignoreVirtual:true, excludeTypeOnly: excludeTypeOnly);

                        if (!needGet && typeArgName.StartsWith("\""))
                        {
                            var tName = typeArgName.Substring(1);

                            if (tName.EndsWith("\""))
                            {
                                tName = tName.Remove(tName.Length - 1);
                            }

                            sb.Append(tName);

                            if (!isStr)
                            {
                                isStr = true;
                                sb.Insert(0, "\"");
                            }
                        }
                        else if (!isTypeParam || !excludeTypeOnly)
                        {
                            sb.Append(typeArgName);
                        }

                        if (needGet)
                        {
                            sb.Append(")");
                        }
                    }

                    if (isStr && sb.Length >= 1)
                    {
                        var sbEnd = sb.ToString(sb.Length - 1, 1);

                        if (!sbEnd.EndsWith(")") && !sbEnd.EndsWith("\""))
                        {
                            sb.Append("\"");
                        }
                    }

                    name = sb.ToString();
                }
                else
                {
                    StringBuilder sb = new StringBuilder(name);
                    bool needComma = false;
                    sb.Append("(");
                    foreach (var typeArg in type.TypeArguments)
                    {
                        if (needComma)
                        {
                            sb.Append(",");
                        }

                        needComma = true;

                        sb.Append(BridgeTypes.ToJsName(typeArg, emitter, skipMethodTypeParam: skipMethodTypeParam, excludeTypeOnly: excludeTypeOnly));
                    }
                    sb.Append(")");
                    name = sb.ToString();
                }
            }

            if (!ignoreVirtual && !isAlias)
            {
                var td = type.GetDefinition();
                if (td != null && emitter.Validator.IsVirtualType(td))
                {
                    string fnName = td.Kind == TypeKind.Interface ? JS.Types.Bridge.GET_INTERFACE : JS.Types.Bridge.GET_CLASS;
                    name = fnName + "(\"" + name + "\")";
                }
                else if (!isAlias && itypeDef != null && itypeDef.Kind == TypeKind.Interface)
                {
                    var externalInterface = emitter.Validator.IsExternalInterface(itypeDef);
                    if (externalInterface != null && externalInterface.IsVirtual)
                    {
                        name = JS.Types.Bridge.GET_INTERFACE + "(\"" + name + "\")";
                    }
                }
            }

            return name;
        }

        public static string ToJsName(TypeDefinition type, IEmitter emitter, bool asDefinition = false, bool excludens = false, bool ignoreVirtual = false, bool nomodule = false)
        {
            return BridgeTypes.ToJsName(ReflectionHelper.ParseReflectionName(BridgeTypes.GetTypeDefinitionKey(type)).Resolve(emitter.Resolver.Resolver.TypeResolveContext), emitter, asDefinition, excludens, ignoreVirtual:ignoreVirtual, nomodule: nomodule);
        }

        public static string DefinitionToJsName(IType type, IEmitter emitter, bool ignoreLiteralName = true)
        {
            return BridgeTypes.ToJsName(type, emitter, true, ignoreLiteralName: ignoreLiteralName);
        }

        public static string DefinitionToJsName(TypeDefinition type, IEmitter emitter)
        {
            return BridgeTypes.ToJsName(type, emitter, true);
        }

        public static string ToJsName(AstType astType, IEmitter emitter)
        {
            var simpleType = astType as SimpleType;

            if (simpleType != null && simpleType.Identifier == "dynamic")
            {
                return JS.Types.System.Object.NAME;
            }

            var resolveResult = emitter.Resolver.ResolveNode(astType, emitter);

            var symbol = resolveResult.Type as ISymbol;

            var name = BridgeTypes.ToJsName(
                resolveResult.Type,
                emitter,
                astType.Parent is TypeOfExpression && symbol != null && symbol.SymbolKind == SymbolKind.TypeDefinition);

            if (name != CS.NS.BRIDGE && !name.StartsWith(CS.Bridge.DOTNAME) && astType.ToString().StartsWith(CS.NS.GLOBAL))
            {
                return JS.Types.Bridge.Global.DOTNAME + name;
            }

            return name;
        }

        public static void EnsureModule(BridgeType type)
        {
            var def = type.Type.GetDefinition();
            if (def != null && type.Module == null)
            {
                var typeDef = def;

                do
                {
                    if (typeDef.Attributes.Count > 0)
                    {
                        var attr = typeDef.Attributes.FirstOrDefault(a => a.AttributeType.FullName == "Bridge.ModuleAttribute");

                        if (attr != null)
                        {
                            BridgeTypes.ReadModuleFromAttribute(type, attr);
                        }
                    }

                    typeDef = typeDef.DeclaringTypeDefinition;
                }
                while (typeDef != null && type.Module == null);                

                if (type.Module == null)
                {
                    var asm = def.ParentAssembly;

                    if (asm.AssemblyAttributes.Count > 0)
                    {
                        var attr = asm.AssemblyAttributes.FirstOrDefault(a => a.AttributeType.FullName == "Bridge.ModuleAttribute");

                        if (attr != null)
                        {
                            BridgeTypes.ReadModuleFromAttribute(type, attr);
                        }
                    }
                }
            }
        }

        private static void ReadModuleFromAttribute(BridgeType type, IAttribute attr)
        {
            Module module = null;

            if (attr.PositionalArguments.Count == 1)
            {
                var obj = attr.PositionalArguments[0].ConstantValue;

                if (obj is bool)
                {
                    module = new Module((bool)obj, type.Emitter);
                }
                else if (obj is string)
                {
                    module = new Module(obj.ToString(), type.Emitter);
                }
                else if (obj is int)
                {
                    module = new Module("", (ModuleType) (int) obj, type.Emitter);
                }
                else
                {
                    module = new Module(type.Emitter);
                }
            }
            else if (attr.PositionalArguments.Count == 2)
            {
                if (attr.PositionalArguments[0].ConstantValue is string)
                {
                    var name = attr.PositionalArguments[0].ConstantValue;
                    var preventName = attr.PositionalArguments[1].ConstantValue;

                    module = new Module(name != null ? name.ToString() : "", type.Emitter, (bool)preventName);
                }
                else if (attr.PositionalArguments[1].ConstantValue is bool)
                {
                    var mtype = attr.PositionalArguments[0].ConstantValue;
                    var preventName = attr.PositionalArguments[1].ConstantValue;

                    module = new Module("", (ModuleType)(int)mtype, type.Emitter,(bool)preventName);
                }
                else
                {
                    var mtype = attr.PositionalArguments[0].ConstantValue;
                    var name = attr.PositionalArguments[1].ConstantValue;

                    module = new Module(name != null ? name.ToString() : "", (ModuleType)(int)mtype, type.Emitter);
                }
            }
            else if (attr.PositionalArguments.Count == 3)
            {
                var mtype = attr.PositionalArguments[0].ConstantValue;
                var name = attr.PositionalArguments[1].ConstantValue;
                var preventName = attr.PositionalArguments[2].ConstantValue;

                module = new Module(name != null ? name.ToString() : "", (ModuleType)(int)mtype, type.Emitter, (bool)preventName);
            }
            else
            {
                module = new Module(type.Emitter);
            }

            if (attr.NamedArguments.Count > 0)
            {
                foreach (var namedArgument in attr.NamedArguments)
                {
                    if (namedArgument.Key.Name == "Name")
                    {
                        module.Name = namedArgument.Value.ConstantValue != null ? (string)namedArgument.Value.ConstantValue : "";
                    }
                    else if (namedArgument.Key.Name == "ExportAsNamespace")
                    {
                        module.ExportAsNamespace = namedArgument.Value.ConstantValue != null ? (string)namedArgument.Value.ConstantValue : "";
                    }
                }
            }

            type.Module = module;
        }

        public static string AddModule(string name, BridgeType type, bool excludeNs, bool isNested, out bool isCustomName)
        {
            isCustomName = false;
            var emitter = type.Emitter;
            var currentTypeInfo = emitter.TypeInfo;
            Module module = null;
            string moduleName = null;

            if (type.TypeInfo == null)
            {
                BridgeTypes.EnsureModule(type);
                module = type.Module;
            }
            else
            {
                module = type.TypeInfo.Module;
            }

            if (currentTypeInfo != null && module != null)
            {
                if (emitter.Tag != "TS" || currentTypeInfo.Module == null || !currentTypeInfo.Module.Equals(module))
                {
                    if (!module.PreventModuleName || (currentTypeInfo.Module != null && currentTypeInfo.Module.Equals(module)))
                    {
                        moduleName = module.ExportAsNamespace;
                    }

                    EnsureDependencies(type, emitter, currentTypeInfo, module);
                }
            }

            return GetCustomName(name, type, excludeNs, isNested, ref isCustomName, moduleName);
        }

        private static string GetCustomName(string name, BridgeType type, bool excludeNs, bool isNested, ref bool isCustomName, string moduleName)
        {
            var emitter = type.Emitter;
            var customName = emitter.Validator.GetCustomTypeName(type.TypeDefinition, emitter, excludeNs);

            if (!String.IsNullOrEmpty(customName))
            {
                isCustomName = true;
                name = customName;
            }

            if (!String.IsNullOrEmpty(moduleName) && (!isNested || isCustomName))
            {
                name = string.IsNullOrWhiteSpace(name) ? moduleName : (moduleName + "." + name);
            }

            return name;
        }

        public static void EnsureDependencies(BridgeType type, IEmitter emitter, ITypeInfo currentTypeInfo, Module module)
        {
            if (!emitter.DisableDependencyTracking
                && currentTypeInfo.Key != type.Key
                && !Module.Equals(currentTypeInfo.Module, module)
                && !emitter.CurrentDependencies.Any(d => d.DependencyName == module.OriginalName))
            {
                emitter.CurrentDependencies.Add(new ModuleDependency
                {
                    DependencyName = module.OriginalName,
                    VariableName = module.ExportAsNamespace,
                    Type = module.Type,
                    PreventName = module.PreventModuleName
                });
            }
        }

        private static System.Collections.Generic.Dictionary<string, string> replacements;
        private static Regex convRegex;

        public static string ConvertName(string name)
        {
            if (BridgeTypes.convRegex == null)
            {
                replacements = new System.Collections.Generic.Dictionary<string, string>(4);
                replacements.Add("`", JS.Vars.D.ToString());
                replacements.Add("/", ".");
                replacements.Add("+", ".");
                replacements.Add("[", "");
                replacements.Add("]", "");
                replacements.Add("&", "");

                BridgeTypes.convRegex = new Regex("(\\" + String.Join("|\\", replacements.Keys.ToArray()) + ")", RegexOptions.Compiled | RegexOptions.Singleline);
            }

            return BridgeTypes.convRegex.Replace
            (
                name,
                delegate (Match m)
                {
                    return replacements[m.Value];
                }
            );
        }

        public static string GetTypeDefinitionKey(TypeDefinition type)
        {
            return BridgeTypes.GetTypeDefinitionKey(type.FullName);
        }

        public static string GetTypeDefinitionKey(string name)
        {
            return name.Replace("/", "+");
        }

        public static string ToTypeScriptName(AstType astType, IEmitter emitter, bool asDefinition = false, bool ignoreDependency = false)
        {
            string name = null;
            var primitive = astType as PrimitiveType;
            name = BridgeTypes.GetTsPrimitivie(primitive);
            if (name != null)
            {
                return name;
            }

            var composedType = astType as ComposedType;
            if (composedType != null && composedType.ArraySpecifiers != null && composedType.ArraySpecifiers.Count > 0)
            {
                return BridgeTypes.ToTypeScriptName(composedType.BaseType, emitter) + string.Concat(Enumerable.Repeat("[]", composedType.ArraySpecifiers.Count));
            }

            var simpleType = astType as SimpleType;
            if (simpleType != null && simpleType.Identifier == "dynamic")
            {
                return "any";
            }

            var resolveResult = emitter.Resolver.ResolveNode(astType, emitter);
            return BridgeTypes.ToTypeScriptName(resolveResult.Type, emitter, asDefinition: asDefinition, ignoreDependency: ignoreDependency);
        }

        public static string ObjectLiteralSignature(IType type, IEmitter emitter)
        {
            var typeDef = type.GetDefinition();
            var isObjectLiteral = typeDef != null && emitter.Validator.IsObjectLiteral(typeDef);

            if (isObjectLiteral)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("{");

                var fields = type.GetFields().Where(f => f.IsPublic && f.DeclaringTypeDefinition.FullName != "System.Object");
                var properties = type.GetProperties().Where(p => p.IsPublic && p.DeclaringTypeDefinition.FullName != "System.Object");

                var comma = false;

                foreach (var field in fields)
                {
                    if (comma)
                    {
                        sb.Append(", ");
                    }

                    sb.Append(OverloadsCollection.Create(emitter, field).GetOverloadName());
                    sb.Append(": ");
                    sb.Append(BridgeTypes.ToTypeScriptName(field.Type, emitter));

                    comma = true;
                }

                foreach (var property in properties)
                {
                    if (comma)
                    {
                        sb.Append(", ");
                    }

                    sb.Append(OverloadsCollection.Create(emitter, property).GetOverloadName());
                    sb.Append(": ");
                    sb.Append(BridgeTypes.ToTypeScriptName(property.ReturnType, emitter));

                    comma = true;
                }

                sb.Append("}");
                return sb.ToString();
            }

            return null;
        }

        public static string ToTypeScriptName(IType type, IEmitter emitter, bool asDefinition = false, bool excludens = false, bool ignoreDependency = false, List<string> guard = null)
        {
            if (type.Kind == TypeKind.Delegate)
            {
                if (guard == null)
                {
                    guard = new List<string>();
                }

                if (guard.Contains(type.FullName))
                {
                    return "Function";
                }

                guard.Add(type.FullName);
                var method = type.GetDelegateInvokeMethod();

                StringBuilder sb = new StringBuilder();
                sb.Append("{");
                sb.Append("(");

                var last = method.Parameters.LastOrDefault();
                foreach (var p in method.Parameters)
                {
                    var ptype = BridgeTypes.ToTypeScriptName(p.Type, emitter, guard:guard);

                    if (p.IsOut || p.IsRef)
                    {
                        ptype = "{v: " + ptype + "}";
                    }

                    sb.Append(p.Name + ": " + ptype);
                    if (p != last)
                    {
                        sb.Append(", ");
                    }
                }

                sb.Append(")");
                sb.Append(": ");
                sb.Append(BridgeTypes.ToTypeScriptName(method.ReturnType, emitter, guard: guard));
                sb.Append("}");
                guard.Remove(type.FullName);
                return sb.ToString();
            }

            var oname = ObjectLiteralSignature(type, emitter);

            if (oname != null)
            {
                return oname;
            }

            if (type.IsKnownType(KnownTypeCode.String))
            {
                return "string";
            }

            if (type.IsKnownType(KnownTypeCode.Boolean))
            {
                return "boolean";
            }

            if (type.IsKnownType(KnownTypeCode.Void))
            {
                return "void";
            }

            if (type.IsKnownType(KnownTypeCode.Array))
            {
                return "any[]";
            }

            if (type.IsKnownType(KnownTypeCode.Byte) ||
                type.IsKnownType(KnownTypeCode.Char) ||
                type.IsKnownType(KnownTypeCode.Double) ||
                type.IsKnownType(KnownTypeCode.Int16) ||
                type.IsKnownType(KnownTypeCode.Int32) ||
                type.IsKnownType(KnownTypeCode.SByte) ||
                type.IsKnownType(KnownTypeCode.Single) ||
                type.IsKnownType(KnownTypeCode.UInt16) ||
                type.IsKnownType(KnownTypeCode.UInt32))
            {
                return "number";
            }

            if (type.Kind == TypeKind.Array)
            {
                ICSharpCode.NRefactory.TypeSystem.ArrayType arrayType = (ICSharpCode.NRefactory.TypeSystem.ArrayType)type;
                return BridgeTypes.ToTypeScriptName(arrayType.ElementType, emitter, asDefinition, excludens, guard: guard) + "[]";
            }

            if (type.Kind == TypeKind.Dynamic || type.IsKnownType(KnownTypeCode.Object))
            {
                return "any";
            }

            if (type.Kind == TypeKind.Enum && type.DeclaringType != null && !excludens)
            {
                return "number";
            }

            if (NullableType.IsNullable(type))
            {
                return BridgeTypes.ToTypeScriptName(NullableType.GetUnderlyingType(type), emitter, asDefinition, excludens, guard: guard);
            }

            BridgeType bridgeType = emitter.BridgeTypes.Get(type, true);
            //string name = BridgeTypes.ConvertName(excludens ? type.Name : type.FullName);

            var name = excludens ? "" : type.Namespace;

            var hasTypeDef = bridgeType != null && bridgeType.TypeDefinition != null;
            bool isNested = false;

            if (hasTypeDef)
            {
                var typeDef = bridgeType.TypeDefinition;
                if (typeDef.IsNested && !excludens)
                {
                    //name = (string.IsNullOrEmpty(name) ? "" : (name + ".")) + BridgeTypes.GetParentNames(emitter, typeDef);
                    name = BridgeTypes.ToJsName(typeDef.DeclaringType, emitter, true, ignoreVirtual: true);
                    isNested = true;
                }

                name = (string.IsNullOrEmpty(name) ? "" : (name + ".")) + BridgeTypes.ConvertName(emitter.GetTypeName(bridgeType.Type.GetDefinition(), typeDef));
            }
            else
            {
                if (type.DeclaringType != null && !excludens)
                {
                    //name = (string.IsNullOrEmpty(name) ? "" : (name + ".")) + BridgeTypes.GetParentNames(emitter, type);
                    name = BridgeTypes.ToJsName(type.DeclaringType, emitter, true, ignoreVirtual: true);

                    if (type.DeclaringType.TypeArguments.Count > 0)
                    {
                        name += Helpers.PrefixDollar(type.TypeArguments.Count);
                    }
                    isNested = true;
                }

                name = (string.IsNullOrEmpty(name) ? "" : (name + ".")) + BridgeTypes.ConvertName(type.Name);
            }

            bool isCustomName = false;
            if (bridgeType != null)
            {
                if (!ignoreDependency && emitter.AssemblyInfo.OutputBy != OutputBy.Project &&
                    bridgeType.TypeInfo != null && bridgeType.TypeInfo.Namespace != emitter.TypeInfo.Namespace)
                {
                    var info = BridgeTypes.GetNamespaceFilename(bridgeType.TypeInfo, emitter);
                    var ns = info.Item1;
                    var fileName = info.Item2;

                    if (!emitter.CurrentDependencies.Any(d => d.DependencyName == fileName))
                    {
                        emitter.CurrentDependencies.Add(new ModuleDependency()
                        {
                            DependencyName = fileName
                        });
                    }
                }

                name = BridgeTypes.GetCustomName(name, bridgeType, excludens, isNested, ref isCustomName, null);
            }

            if (!hasTypeDef && !isCustomName && type.TypeArguments.Count > 0)
            {
                name += Helpers.PrefixDollar(type.TypeArguments.Count);
            }

            if (isCustomName && excludens && name != null)
            {
                var idx = name.LastIndexOf('.');

                if (idx > -1)
                {
                    name = name.Substring(idx + 1);
                }
            }

            if (!asDefinition && type.TypeArguments.Count > 0 && !Helpers.IsIgnoreGeneric(type, emitter, true))
            {
                StringBuilder sb = new StringBuilder(name);
                bool needComma = false;
                sb.Append("<");
                foreach (var typeArg in type.TypeArguments)
                {
                    if (needComma)
                    {
                        sb.Append(",");
                    }

                    needComma = true;
                    sb.Append(BridgeTypes.ToTypeScriptName(typeArg, emitter, asDefinition, excludens, guard: guard));
                }
                sb.Append(">");
                name = sb.ToString();
            }

            return name;
        }

        public static string GetTsPrimitivie(PrimitiveType primitive)
        {
            if (primitive != null)
            {
                switch (primitive.KnownTypeCode)
                {
                    case KnownTypeCode.Void:
                        return "void";

                    case KnownTypeCode.Boolean:
                        return "boolean";

                    case KnownTypeCode.String:
                        return "string";

                    case KnownTypeCode.Double:
                    case KnownTypeCode.Byte:
                    case KnownTypeCode.Char:
                    case KnownTypeCode.Int16:
                    case KnownTypeCode.Int32:
                    case KnownTypeCode.SByte:
                    case KnownTypeCode.Single:
                    case KnownTypeCode.UInt16:
                    case KnownTypeCode.UInt32:
                        return "number";
                }
            }

            return null;
        }

        public static Tuple<string, string, Module> GetNamespaceFilename(ITypeInfo typeInfo, IEmitter emitter)
        {
            var ns = typeInfo.GetNamespace(emitter, true);
            var fileName = ns ?? typeInfo.GetNamespace(emitter);
            var module = typeInfo.Module;
            string moduleName = null;

            if (module != null && module.Type == ModuleType.UMD)
            {
                if (!module.PreventModuleName)
                {
                    moduleName = module.ExportAsNamespace;
                }

                if (!String.IsNullOrEmpty(moduleName))
                {
                    ns = string.IsNullOrWhiteSpace(ns) ? moduleName : (moduleName + "." + ns);
                }
                else
                {
                    module = null;
                }
            }

            switch (emitter.AssemblyInfo.FileNameCasing)
            {
                case FileNameCaseConvert.Lowercase:
                    fileName = fileName.ToLower();
                    break;

                case FileNameCaseConvert.CamelCase:
                    var sepList = new string[] { ".", System.IO.Path.DirectorySeparatorChar.ToString(), "\\", "/" };

                    // Populate list only with needed separators, as usually we will never have all four of them
                    var neededSepList = new List<string>();

                    foreach (var separator in sepList)
                    {
                        if (fileName.Contains(separator.ToString()) && !neededSepList.Contains(separator))
                        {
                            neededSepList.Add(separator);
                        }
                    }

                    // now, separating the filename string only by the used separators, apply lowerCamelCase
                    if (neededSepList.Count > 0)
                    {
                        foreach (var separator in neededSepList)
                        {
                            var stringList = new List<string>();

                            foreach (var str in fileName.Split(separator[0]))
                            {
                                stringList.Add(str.ToLowerCamelCase());
                            }

                            fileName = stringList.Join(separator);
                        }
                    }
                    else
                    {
                        fileName = fileName.ToLowerCamelCase();
                    }
                    break;
            }

            return new Tuple<string, string, Module>(ns, fileName, module);
        }
    }
}