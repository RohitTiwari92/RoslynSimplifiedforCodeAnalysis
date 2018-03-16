using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace RoslynSimplifiedforCodeAnalysis.Modules.Helper
{
    static class SyntaxNodeHelper
    {
        public static bool TryGetParentSyntax<T>(SyntaxNode syntaxNode, out T result)
            where T : SyntaxNode
        {
            // set defaults
            result = null;

            if (syntaxNode == null)
            {
                return false;
            }

            try
            {
                syntaxNode = syntaxNode.Parent;

                if (syntaxNode == null)
                {
                    return false;
                }

                if (syntaxNode.GetType() == typeof(T))
                {
                    result = syntaxNode as T;
                    return true;
                }

                return TryGetParentSyntax<T>(syntaxNode, out result);
            }
            catch
            {
                return false;
            }
        }
    }
}



//uses of this class 
//NamespaceDeclarationSyntax namespaceDeclarationSyntax = null;
//if (!SyntaxNodeHelper.TryGetParentSyntax(classDeclarationSyntax, out namespaceDeclarationSyntax))
//{
//    return; // or whatever you want to do in this scenario
//}

//var namespaceName = namespaceDeclarationSyntax.Name.ToString();
//var fullClassName = namespaceName + "." + classDeclarationSyntax.Identifier.ToString();