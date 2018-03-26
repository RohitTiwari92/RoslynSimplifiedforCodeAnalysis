using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace RoslynSimplifiedforCodeAnalysis.Modules.ProjectModule
{
    public class AST
    {
        public Project GetAsTfromSolutionFile(string @ProjectPath)
        {
            var msWorkspace = MSBuildWorkspace.Create();
            var solution = msWorkspace.OpenProjectAsync(ProjectPath).Result;
            return solution;
        }
    }
}
