    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynSimplifiedforCodeAnalysis.Modules.ClassModule
{
   public class ClassVirtualizationVisitor : CSharpSyntaxRewriter
    {
        public ClassVirtualizationVisitor()
        {
            Classes = new List<ClassDeclarationSyntax>();
        }

        public List<ClassDeclarationSyntax> Classes { get; set; }

        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
          

            //string className = node.Identifier.ValueText;
            Classes.Add(node); // save your visited classes
            base.VisitClassDeclaration(node);
            return node;
        }
    }
}
