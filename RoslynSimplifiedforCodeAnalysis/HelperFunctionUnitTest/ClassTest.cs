using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoslynSimplifiedforCodeAnalysis.Modules.NamespaceModule;
using RoslynSimplifiedforCodeAnalysis.Modules.ProjectModule;
using RoslynSimplifiedforCodeAnalysis.Modules.ClassModule;

namespace HelperFunctionUnitTest
{
    [TestClass]
    public class ClassTest
    {
        private static string solutionpath { get; set; }

        [ClassInitialize]
        public static void ClassInit(TestContext con)
        {
            solutionpath = ConfigurationManager.AppSettings["TestPath"] + @"HelperTestSubject\HelperTestSubject.sln";
        }

        [TestMethod]
        [TestCategory("CoreEngine")]
        public void ClassCountTest()
        {
            RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST sast = new RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectModelList(res);
            CompileProject cproj = new CompileProject();
            var pcomp = cproj.Compile(pres[0]).Result;        
            GettheClassListFromProjectModel clsobj=new GettheClassListFromProjectModel();
            var clsres = clsobj.GetClassNameList(pcomp);
            Assert.AreEqual(clsres.Count, 2);

        }

        [TestMethod]
        [TestCategory("CoreEngine")]
        public void ClassNameTest()
        {
            RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST sast = new RoslynSimplifiedforCodeAnalysis.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectModelList(res);
            CompileProject cproj = new CompileProject();
            var pcomp = cproj.Compile(pres[0]).Result;
            GettheClassListFromProjectModel clsobj = new GettheClassListFromProjectModel();
            var clsres = clsobj.GetClassNameList(pcomp);
            Assert.AreEqual(clsres[0], "Class1");

        }
    }
}
