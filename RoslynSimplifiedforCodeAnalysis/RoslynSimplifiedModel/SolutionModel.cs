using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace RoslynSimplifiedModel
{
    public class SolutionModel
    {
        public Solution SolDataAst { get; set; }
        public List<ProjectModel> Projectlist { get; set; } 
    }
}
