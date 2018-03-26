using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace CoreEngine.Modules.ProjectModule
{
   public class GettheProjectListFromSolutionAst
    {
       public List<string> GetProjectNameList(Solution sol)
       {
           return sol.Projects.Select(project => project.Name).ToList();
       }

       public List<Project> GetProjectModelList(Solution sol)
       {
           return sol.Projects.ToList();
       }
    }
}
