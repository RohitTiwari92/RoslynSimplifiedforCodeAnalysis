using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynSimplifiedModel
{
  public  class NamspaceModel
    {
        public NamespaceDeclarationSyntax Namespacedeclaration { get; set; }
        public List<ClassModel> Classmodel { get; set; }
        public List<InterfaceModel> Interfacemodel { get; set; }
    }
}
