using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoslynSimplifiedforCodeAnalysis.Modules.ProjectModule;

namespace HelperFunctionUnitTest
{
    [TestClass]
    public class ProjectCountTest
    {
        private static string solutionpath { get; set; }

        [ClassInitialize]
        public static void ClassInit(TestContext con)
        {
            solutionpath = ConfigurationManager.AppSettings["TestPath"] + @"HelperTestSubject\HelperTestSubject.sln";
        }
        [TestMethod]
        public void TestCountProjectsInSolutionFile()
        {
            RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST sast = new RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast =new GettheProjectListFromSolutionAst();
            var pres=projast.GetProjectNameList(res);
            Assert.AreEqual(pres.Count, 2);
        }

        [TestMethod]
        public void TestCheckforProjectNameInSolutionFile()
        {
            RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST sast = new RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectNameList(res);
            Assert.AreEqual(pres[0], "HelperTestSubject");
        }

        [TestMethod]
        public void TestCountProjectModelsInSolutionFile()
        {
            RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST sast = new RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectModelList(res);
            Assert.AreEqual(pres.Count, 2);
        }

        [TestMethod]
        public void TestProjectCompilation()
        {
            RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST sast = new RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectModelList(res);
            CompileProject cproj =new CompileProject();           
            Assert.IsNotNull(cproj.Compile(pres[0]));
        }
    }
}
