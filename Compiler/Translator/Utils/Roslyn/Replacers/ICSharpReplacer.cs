using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Translator
{
    public interface ICSharpReplacer
    {
        SyntaxNode Replace(SyntaxNode root, SemanticModel model);
    }
}
