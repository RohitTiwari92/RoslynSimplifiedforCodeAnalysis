using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoslynSimplifiedforCodeAnalysis.Modules.ProjectModule;
using RoslynSimplifiedforCodeAnalysis.Modules.NamespaceModule;

namespace HelperFunctionUnitTest
{
    [TestClass]
    public class NamespaceTest
    {


        private static string solutionpath { get; set; }

        [ClassInitialize]
        public static void ClassInit(TestContext con)
        {
            solutionpath = ConfigurationManager.AppSettings["TestPath"] + @"HelperTestSubject\HelperTestSubject.sln";
        }

        [TestMethod]
        public  void NamespaceCountTest()
        {
            RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST sast = new RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectModelList(res);
            CompileProject cproj = new CompileProject();
            var pcomp =  cproj.Compile(pres[0]).Result;
            GettheNamespaceListFromProjectModel gprj = new GettheNamespaceListFromProjectModel();
            var resc = gprj.GetNamespaceNameList(pcomp);
            Assert.AreEqual(resc.Count,2);

        }

        [TestMethod]
        public void NamespaceNameTest()
        {
            RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST sast = new RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectModelList(res);
            CompileProject cproj = new CompileProject();
            var pcomp = cproj.Compile(pres[0]).Result;
            GettheNamespaceListFromProjectModel gprj = new GettheNamespaceListFromProjectModel();
            var resc = gprj.GetNamespaceNameList(pcomp);
            Assert.AreEqual(resc[0], "HelperTestSubject");

        }
    }
}
