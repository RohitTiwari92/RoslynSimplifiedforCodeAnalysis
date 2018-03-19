using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            RoslynSimplifiedforCodeAnalysis.Modules.ProjectModule.GettheProjectListFromSolutionAst projast=new RoslynSimplifiedforCodeAnalysis.Modules.ProjectModule.GettheProjectListFromSolutionAst();
            var pres=projast.GetProjectNameList(res);
            Assert.AreEqual(pres.Count, 2);

        }
    }
}
