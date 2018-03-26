using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace RoslynSimplifiedModel
{
   public class ProjectModel
    {
        public Project proj { get; set; }
        public Compilation CompliedProj { get; set; }
        public List<NamspaceModel> NamespacemodeList { get; set; } 
    }
}
