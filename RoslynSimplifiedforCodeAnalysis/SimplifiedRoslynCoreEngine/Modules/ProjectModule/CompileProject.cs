using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace RoslynSimplifiedforCodeAnalysis.Modules.ProjectModule
{
    public class CompileProject
    {
        public async Task<Compilation> Compile(Project proj)
        {
            Compilation compilation = await proj.GetCompilationAsync();
            return compilation;
        }
    }
}
