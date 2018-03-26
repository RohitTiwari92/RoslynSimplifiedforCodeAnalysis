using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynSimplifiedModel
{
    public class InterfaceModel
    {
        public InterfaceDeclarationSyntax Interfacedeclaration { get; set; }
        public List<MethodModel> Methodmodels { get; set; }
        public List<PropertyModel> Propertymodels { get; set; }
    }
}
