using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynSimplifiedforCodeAnalysis.Modules.ClassModule;

namespace RoslynSimplifiedforCodeAnalysis.Modules.NamespaceModule
{
   public class GettheNamespaceListFromProjectModel
    {
        public List<string> GetNamespaceNameList(Compilation Comproj)
        {
            List<string> NamespaceNames = new List<string>();
            foreach (var syntaxTree in Comproj.SyntaxTrees)
            {
                var NamespaceVisitor = new NamespaceVirtualizationVisitor();
                NamespaceVisitor.Visit(syntaxTree.GetRoot());
                foreach (var item in NamespaceVisitor.Namespaces)
                {
                    NamespaceNames.Add( GetFullName(item));
                }
                
            }
            return NamespaceNames;
        }
        public static string GetFullName(NamespaceDeclarationSyntax node)
        {
           
                return String.Format("{0}.{1}",
                    GetFullName((NamespaceDeclarationSyntax)node.Parent),
                    ((IdentifierNameSyntax)node.Name).Identifier.ToString());
            
        }
        public List<NamespaceDeclarationSyntax> GetNamespaceModelList(Compilation Comproj)
        {
            List<NamespaceDeclarationSyntax> NamespaceModel = new List<NamespaceDeclarationSyntax>();
            foreach (var syntaxTree in Comproj.SyntaxTrees)
            {
                var NamespaceVisitor = new NamespaceVirtualizationVisitor();
                NamespaceVisitor.Visit(syntaxTree.GetRoot());
                NamespaceModel.AddRange(NamespaceVisitor.Namespaces);
            }
            return NamespaceModel;
        }
    }
}
