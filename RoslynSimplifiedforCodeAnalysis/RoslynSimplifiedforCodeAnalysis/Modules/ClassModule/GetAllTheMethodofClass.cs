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
  public  class GetAllTheMethodofClass
    {
        public List<string> GetClassNameList(ClassDeclarationSyntax classsyn)
        {
            IEnumerable<MethodDeclarationSyntax> methods = GetMethodModelList(classsyn);
            List<string> MethodNames = new List<string>();
            foreach (var method in methods)
            {
                MethodNames.Add(method.Identifier.ValueText);
            }
            return MethodNames;
        }

        public List<MethodDeclarationSyntax> GetMethodModelList(ClassDeclarationSyntax classsyn)
        {
            
            return classsyn.SyntaxTree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>().ToList();
        }
    }
}
