using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CoreEngine.Modules.ClassModule;
using CoreEngine.Modules.Helper;
using CoreEngine.Modules.MethodModule;
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
        public SolutionModel FillModel(string Solfilepath)
        {
            SolutionModel solmodel = new SolutionModel();
            AST solast = new AST();
            Solution astsolution = solast.GetAsTfromSolutionFile(@Solfilepath);
            solmodel.SolDataAst = astsolution;
            GettheProjectListFromSolutionAst prjoobj = new GettheProjectListFromSolutionAst();
            List<Project> projectmodellist = prjoobj.GetProjectModelList(astsolution);
            List<ProjectModel> projmodellidst = new List<ProjectModel>();
            foreach (var Pitem in projectmodellist)
            {
                FIllProjectModel(Pitem, projmodellidst);
            }
            return solmodel;
        }

        private static void FIllProjectModel(Project Pitem, List<ProjectModel> projmodellidst)
        {
            ProjectModel pmodel = new ProjectModel();
            CompileProject Cproj = new CompileProject();
            pmodel.CompliedProj = Cproj.Compile(Pitem).Result;
            pmodel.project = Pitem;
            projmodellidst.Add(pmodel);
            GettheNamespaceListFromProjectModel nmmodel = new GettheNamespaceListFromProjectModel();
            List<NamespaceDeclarationSyntax> namespacemodeList = nmmodel.GetNamespaceModelList(pmodel.CompliedProj);
            List<NamspaceModel> Namespacecustmode = new List<NamspaceModel>();
            List<ClassDeclarationSyntax> AllClsmodel = new List<ClassDeclarationSyntax>();
            GettheClassListFromProjectModel clsobj = new GettheClassListFromProjectModel();
            AllClsmodel = clsobj.GetClassModelList(pmodel.CompliedProj);
            foreach (var nsitem in namespacemodeList)
            {
                FillNamespaceModel(nsitem, AllClsmodel, Namespacecustmode);
            }
            
        }

        private static void FillNamespaceModel(NamespaceDeclarationSyntax nsitem, List<ClassDeclarationSyntax> AllClsmodel, List<NamspaceModel> Namespacecustmode)
        {
            NamspaceModel nsModel = new NamspaceModel();
            nsModel.Namespacedeclaration = nsitem;
            string nsname = nsitem.Name.ToString();
            //need to change the code
            //start
            foreach (var cditem in AllClsmodel)
            {
                NamespaceDeclarationSyntax namespaceDeclarationSyntax = null;
                if (!SyntaxNodeHelper.TryGetParentSyntax(cditem, out namespaceDeclarationSyntax))
                {
                    // return true;
                }
                else
                {
                    var namespaceName = namespaceDeclarationSyntax.Name.ToString();
                    FillClassModel(namespaceName, nsname, cditem);
                }
            }
            //end
            Namespacecustmode.Add(nsModel);           
        }

        private static void FillClassModel(string namespaceName, string nsname, ClassDeclarationSyntax cditem)
        {
            if (namespaceName.Equals(nsname))
            {
                ClassModel clmodel = new ClassModel();
                clmodel.Classdeclaration = cditem;
                var mtdModelList = FIllMethoddModel(cditem);
                clmodel.Methodmodels = mtdModelList;
            }
        }

        private static List<MethodModel> FIllMethoddModel(ClassDeclarationSyntax cditem)
        {
            GetAllTheMethodofClass mtdobj = new GetAllTheMethodofClass();
            List<MethodDeclarationSyntax> mtddecsytx = mtdobj.GetMethodModelList(cditem);
            List<MethodModel> mtdModelList = new List<MethodModel>();
            foreach (var mtditem in mtddecsytx)
            {
                MethodModel mtdModel = new MethodModel();
                mtdModel.Methoddeclaration = mtditem;
                mtdModelList.Add(mtdModel);
            }
            return mtdModelList;
        }
    }
}
