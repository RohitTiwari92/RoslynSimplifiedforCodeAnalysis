using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynSimplifiedModel
{
   public class ProjectModel
    {
        public Project project { get; set; }
        public Compilation CompliedProj { get; set; }
        public List<NamspaceModel> NamespacecustmodeList { get; set; }

       // public List<NamespaceDeclarationSyntax> NamespacemodeList { get; set; }
    }
}
