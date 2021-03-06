﻿using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreEngine.Modules.SolutionModule;
using System.IO;
namespace HelperFunctionUnitTest
{
    [TestClass]
    public class SolutionASTTest
    {
        private static string solutionpath { get; set; }

        [ClassInitialize]
        public static void ClassInit(TestContext con)

        {
            solutionpath = ConfigurationManager.AppSettings["TestPath"]+ @"HelperTestSubject\HelperTestSubject.sln";
        }

        [TestMethod]
        [TestCategory("CoreEngine")]
        public void TestMethodSolutionAST()
        {
            AST sast=new AST();
            var res = sast.GetAsTfromSolutionFile(solutionpath);
            Assert.IsNotNull(res);
        }
    }
}
