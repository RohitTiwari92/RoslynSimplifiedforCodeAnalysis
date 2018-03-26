using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreEngine.Modules.ProjectModule;

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
        [TestCategory("CoreEngine")]
        public void TestCountProjectsInSolutionFile()
        {
            CoreEngine.Modules.SolutionModule.AST sast = new CoreEngine.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast =new GettheProjectListFromSolutionAst();
            var pres=projast.GetProjectNameList(res);
            Assert.AreEqual(pres.Count, 2);
        }

        [TestMethod]
        [TestCategory("CoreEngine")]
        public void TestCheckforProjectNameInSolutionFile()
        {
            CoreEngine.Modules.SolutionModule.AST sast = new CoreEngine.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectNameList(res);
            Assert.AreEqual(pres[0], "HelperTestSubject");
        }

        [TestMethod]
        [TestCategory("CoreEngine")]
        public void TestCountProjectModelsInSolutionFile()
        {
            CoreEngine.Modules.SolutionModule.AST sast = new CoreEngine.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectModelList(res);
            Assert.AreEqual(pres.Count, 2);
        }

        [TestMethod]
        [TestCategory("CoreEngine")]
        public void TestProjectCompilation()
        {
            CoreEngine.Modules.SolutionModule.AST sast = new CoreEngine.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectModelList(res);
            CompileProject cproj =new CompileProject();           
            Assert.IsNotNull(cproj.Compile(pres[0]));
        }
    }
}
