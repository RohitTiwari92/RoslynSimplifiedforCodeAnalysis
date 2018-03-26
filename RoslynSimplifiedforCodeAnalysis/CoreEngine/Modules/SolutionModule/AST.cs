using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace CoreEngine.Modules.SolutionModule
{
    public class AST
    {
        public Solution GetAsTfromSolutionFile(string @solutionPath)
        {
            var msWorkspace = MSBuildWorkspace.Create();
            var solution = msWorkspace.OpenSolutionAsync(solutionPath).Result;
            return solution;
        }
    }
}
