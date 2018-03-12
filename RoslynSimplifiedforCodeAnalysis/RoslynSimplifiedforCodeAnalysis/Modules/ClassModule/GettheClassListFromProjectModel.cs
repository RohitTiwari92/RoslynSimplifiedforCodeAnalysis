using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynSimplifiedforCodeAnalysis.Modules.ClassModule
{
    public class GettheClassListFromProjectModel
    {
        public List<string> GetClassNameList(Compilation Comproj)
        {
             List<string> classNames=new List<string>();
            foreach (var syntaxTree in Comproj.SyntaxTrees)
            {
                var classVisitor = new ClassVirtualizationVisitor();
                classVisitor.Visit(syntaxTree.GetRoot());
                classNames.AddRange(classVisitor.Classes.Select(cls => cls.Identifier.ValueText));
            }
            return classNames;
        }

        public List<ClassDeclarationSyntax> GetClassModelList(Compilation Comproj)
        {
            List<ClassDeclarationSyntax> classModel = new List<ClassDeclarationSyntax>();
            foreach (var syntaxTree in Comproj.SyntaxTrees)
            {
                var classVisitor = new ClassVirtualizationVisitor();
                classVisitor.Visit(syntaxTree.GetRoot());
                classModel.AddRange(classVisitor.Classes);
            }
            return classModel;
        }
    }
}
