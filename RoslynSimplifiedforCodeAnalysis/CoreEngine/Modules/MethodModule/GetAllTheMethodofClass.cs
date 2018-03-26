using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CoreEngine.Modules.MethodModule
{
    public class GetAllTheMethodofClass
    {
        public List<string> GetMethodNameList(ClassDeclarationSyntax classsyn)
        {
            IEnumerable<MethodDeclarationSyntax> methods = GetMethodModelList(classsyn);
            return methods.Select(method => method.Identifier.ValueText).ToList();
        }

        public List<MethodDeclarationSyntax> GetMethodModelList(ClassDeclarationSyntax classsyn)
        {
            return classsyn.SyntaxTree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>().ToList();
        }
    }
}
