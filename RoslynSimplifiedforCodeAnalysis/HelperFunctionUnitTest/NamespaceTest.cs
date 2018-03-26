using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreEngine.Modules.ProjectModule;
using CoreEngine.Modules.NamespaceModule;

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
        [TestCategory("CoreEngine")]
        public  void NamespaceCountTest()
        {
            CoreEngine.Modules.SolutionModule.AST sast = new CoreEngine.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectModelList(res);
            CompileProject cproj = new CompileProject();
            var pcomp =  cproj.Compile(pres[0]).Result;
            GettheNamespaceListFromProjectModel gprj = new GettheNamespaceListFromProjectModel();
            var resc = gprj.GetNamespaceNameList(pcomp);
            Assert.AreEqual(resc.Count,3);

        }

        [TestMethod]
        [TestCategory("CoreEngine")]
        public void NamespaceNameTest()
        {
            CoreEngine.Modules.SolutionModule.AST sast = new CoreEngine.Modules.SolutionModule.AST();
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
