using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using CoreEngine.Modules.ClassModule;

namespace CoreEngine.Modules.Interface
{
   public class GettheInterfaceListFromProjectModel
    {
        public List<string> GetInterfaceNameList(Compilation Comproj)
        {
            List<string> InterfaceNames = new List<string>();
            foreach (var syntaxTree in Comproj.SyntaxTrees)
            {
                var InterfaceVisitor = new InterfaceVirtualizationVisitor();
                InterfaceVisitor.Visit(syntaxTree.GetRoot());
                foreach (var item in InterfaceVisitor.Interfaces)
                {
                    InterfaceNames.Add( item.Identifier.ValueText);
                }
                
            }
            return InterfaceNames;
        }
 
        public List<InterfaceDeclarationSyntax> GetInterfaceModelList(Compilation Comproj)
        {
            List<InterfaceDeclarationSyntax> InterfaceModel = new List<InterfaceDeclarationSyntax>();
            foreach (var syntaxTree in Comproj.SyntaxTrees)
            {
                var InterfaceVisitor = new InterfaceVirtualizationVisitor();
                InterfaceVisitor.Visit(syntaxTree.GetRoot());
                InterfaceModel.AddRange(InterfaceVisitor.Interfaces);
            }
            return InterfaceModel;
        }
    }
}
