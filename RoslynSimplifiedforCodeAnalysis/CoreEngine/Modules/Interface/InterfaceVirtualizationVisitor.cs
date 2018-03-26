using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CoreEngine.Modules.Interface
{
    public class InterfaceVirtualizationVisitor : CSharpSyntaxRewriter
    {
        public InterfaceVirtualizationVisitor()
        {
            Interfaces = new List<InterfaceDeclarationSyntax>();
        }
        
        public List<InterfaceDeclarationSyntax> Interfaces { get; set; }

        public override SyntaxNode VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            //node = (NamespaceDeclarationSyntax)VisitNamespaceDeclaration(node);
            Interfaces.Add(node); // save your visited classes
            base.VisitInterfaceDeclaration(node);
            return node;

        }
    }
}
