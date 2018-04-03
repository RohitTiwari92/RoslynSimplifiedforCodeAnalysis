using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CoreEngine.Modules.ClassModule;
using CoreEngine.Modules.Helper;
using CoreEngine.Modules.NamespaceModule;
using CoreEngine.Modules.ProjectModule;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
                GettheNamespaceListFromProjectModel nmmodel=new GettheNamespaceListFromProjectModel();
                List<NamespaceDeclarationSyntax> namespacemodeList=    nmmodel.GetNamespaceModelList(pmodel.CompliedProj);
                pmodel.NamespacemodeList.AddRange(namespacemodeList);
                List<NamspaceModel> Namespacecustmode =new List<NamspaceModel>();
                List<ClassDeclarationSyntax> AllClsmodel =new List<ClassDeclarationSyntax>();
                GettheClassListFromProjectModel clsobj=new GettheClassListFromProjectModel();
                AllClsmodel = clsobj.GetClassModelList(pmodel.CompliedProj);
                foreach (var nsitem in namespacemodeList)
                {
                    NamspaceModel nsModel=new NamspaceModel();
                    nsModel.Namespacedeclaration = nsitem;
                    string nsname = nsitem.Name.ToString();
                    //need to change the code
                    //start
                    foreach (var cditem in AllClsmodel)
                    {
                        NamespaceDeclarationSyntax namespaceDeclarationSyntax = null;
                        if (!SyntaxNodeHelper.TryGetParentSyntax(cditem, out namespaceDeclarationSyntax))
                        {
                            return; // or whatever you want to do in this scenario
                        }

                        var namespaceName = namespaceDeclarationSyntax.Name.ToString();

                        if (namespaceName.Equals(nsname))
                        {
                            //nsModel.Classmodel.Add(cditem);
                        }
                    }

                    //end


                }
            }

        }
    }
}
