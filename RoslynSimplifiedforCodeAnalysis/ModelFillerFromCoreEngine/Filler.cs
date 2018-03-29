using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEngine.Modules.NamespaceModule;
using CoreEngine.Modules.ProjectModule;
using Microsoft.CodeAnalysis;
using RoslynSimplifiedModel;
using AST = CoreEngine.Modules.SolutionModule.AST;

namespace ModelFillerFromCoreEngine
{
    public class Filler
    {
        public void FillModel(string Solfilepath)
        {
            SolutionModel solmodel = new SolutionModel();
            AST solast=new AST();
            Solution astsolution= solast.GetAsTfromSolutionFile(@Solfilepath);         
            solmodel.SolDataAst = astsolution;

            GettheProjectListFromSolutionAst prjoobj=new GettheProjectListFromSolutionAst();
             List<Project> projectmodellist= prjoobj.GetProjectModelList(astsolution);

            List<ProjectModel> projmodellidst=new List<ProjectModel>();

            foreach (var Pitem in projectmodellist)
            {
                ProjectModel pmodel=new ProjectModel();
                CompileProject Cproj = new CompileProject();
                pmodel.CompliedProj=    Cproj.Compile(Pitem).Result;
                pmodel.project = Pitem;
                GettheNamespaceListFromProjectModel namespaceobj=new GettheNamespaceListFromProjectModel();
                pmodel.NamespacemodeList = namespaceobj.GetNamespaceModelList(pmodel.CompliedProj);
                projmodellidst.Add(pmodel);
            }

        }
    }
}
