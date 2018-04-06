using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoslynSimplifiedforCodeAnalysis;

namespace CoreFillerFunctionUnitTest
{
    [TestClass]
    public class WorkingCheck
    {
        private static string solutionpath { get; set; }

        [ClassInitialize]
        public static void ClassInit(TestContext con)
        {
            solutionpath = ConfigurationManager.AppSettings["TestPath"] + @"HelperTestSubject\HelperTestSubject.sln";
        }
        [TestMethod]
        [TestCategory("Filler")]
        public void IsFillerWorking()
        {
            Init initobj=new Init(solutionpath);
            initobj.Process();
        }
    }
}
