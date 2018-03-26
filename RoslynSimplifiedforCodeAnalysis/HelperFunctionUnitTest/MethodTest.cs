using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreEngine.Modules.ClassModule;
using CoreEngine.Modules.MethodModule;
using CoreEngine.Modules.ProjectModule;

namespace HelperFunctionUnitTest
{
    [TestClass]
    public class MethodTest
    {
        private static string solutionpath { get; set; }

        [ClassInitialize]
        public static void ClassInit(TestContext con)
        {
            solutionpath = ConfigurationManager.AppSettings["TestPath"] + @"HelperTestSubject\HelperTestSubject.sln";
        }

        [TestMethod]
        [TestCategory("CoreEngine")]
        public void MethodCountTest()
        {
            CoreEngine.Modules.SolutionModule.AST sast = new CoreEngine.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectModelList(res);
            CompileProject cproj = new CompileProject();
            var pcomp = cproj.Compile(pres[0]).Result;
            GettheClassListFromProjectModel clsobj = new GettheClassListFromProjectModel();
            var clsres = clsobj.GetClassModelList(pcomp);
            GetAllTheMethodofClass mclsobj=new GetAllTheMethodofClass();
            List<string> m_count =new List<string>();
            foreach (var item in clsres)
            {
                m_count.AddRange( mclsobj.GetMethodNameList(item));
            }
            Assert.AreEqual(m_count.Count, 1);

        }

        [TestMethod]
        [TestCategory("CoreEngine")]
        public void MethodNameTest()
        {
            CoreEngine.Modules.SolutionModule.AST sast = new CoreEngine.Modules.SolutionModule.AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            GettheProjectListFromSolutionAst projast = new GettheProjectListFromSolutionAst();
            var pres = projast.GetProjectModelList(res);
            CompileProject cproj = new CompileProject();
            var pcomp = cproj.Compile(pres[0]).Result;
            GettheClassListFromProjectModel clsobj = new GettheClassListFromProjectModel();
            var clsres = clsobj.GetClassModelList(pcomp);
            GetAllTheMethodofClass mclsobj = new GetAllTheMethodofClass();
            List<string> m_count = new List<string>();
            foreach (var item in clsres)
            {
                m_count.AddRange(mclsobj.GetMethodNameList(item));
            }
            Assert.AreEqual(m_count[0], "testmethod");

        }
    }
}
