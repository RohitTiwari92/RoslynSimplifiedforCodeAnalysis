using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelFillerFromCoreEngine;
using RoslynSimplifiedModel;

namespace RoslynSimplifiedforCodeAnalysis
{
    public class Init
    {
        private string Path { get; set; }
        public Init(string path)
        {
            Path = path;
        }

        public SolutionModel Process()
        {
            Filler fillmodel=new Filler();
            return fillmodel.FillModel(Path);
        }
    }
}
