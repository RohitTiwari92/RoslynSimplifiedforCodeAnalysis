using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynSimplifiedModel
{
  public  class ClassModel
    {
        public ClassDeclarationSyntax Classdeclaration { get; set; }
        public List<MethodModel> Methodmodels = new List<MethodModel>();
        public List<PropertyModel> Propertymodels = new List<PropertyModel>(); 
    }
}
