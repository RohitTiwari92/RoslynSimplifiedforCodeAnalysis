using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynSimplifiedforCodeAnalysis.Modules.NamespaceModule
{
    public class NamespaceVirtualizationVisitor : CSharpSyntaxRewriter
    {
        public NamespaceVirtualizationVisitor()
        {
            Namespaces = new List<NamespaceDeclarationSyntax>();
        }

        public List<NamespaceDeclarationSyntax> Namespaces { get; set; }

        public  SyntaxNode VisitClassDeclaration(NamespaceDeclarationSyntax node)
        {
            node = (NamespaceDeclarationSyntax)VisitNamespaceDeclaration(node);
            Namespaces.Add(node); // save your visited classes
            return node;
        }
    }
}
