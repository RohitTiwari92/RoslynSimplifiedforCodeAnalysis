using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreEngine.Modules.ClassModule;
using CoreEngine.Modules.ProjectModule;
using CoreEngine.Modules.Interface;

namespace HelperFunctionUnitTest
{
    [TestClass]
    public class InterfaceTest
    {
        private static string solutionpath { get; set; }

        [ClassInitialize]
        public static void ClassInit(TestContext con)
        {
            solutionpath = ConfigurationManager.AppSettings["TestPath"] + @"HelperTestSubject\HelperTestSubject.sln";
        }

        [TestMethod]
        [TestCategory("CoreEngine")]
        public void InterfaceCountTest()
        {
            CoreEngine.Modules.SolutionModule.AST sast = new CoreEngine.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectModelList(res);
            CompileProject cproj = new CompileProject();
            var pcomp = cproj.Compile(pres[0]).Result;
            GettheInterfaceListFromProjectModel Iobj = new GettheInterfaceListFromProjectModel();
            var Ires = Iobj.GetInterfaceNameList(pcomp);
            Assert.AreEqual(1,Ires.Count);
        }

        [TestMethod]
        [TestCategory("CoreEngine")]
        public void InterfaceNameTest()
        {
            CoreEngine.Modules.SolutionModule.AST sast = new CoreEngine.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectModelList(res);
            CompileProject cproj = new CompileProject();
            var pcomp = cproj.Compile(pres[0]).Result;
            GettheInterfaceListFromProjectModel Iobj = new GettheInterfaceListFromProjectModel();
            var Ires = Iobj.GetInterfaceNameList(pcomp);
            Assert.AreEqual(Ires[0], "Interface2");

        }
    }
}
