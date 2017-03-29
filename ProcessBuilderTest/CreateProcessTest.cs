using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using ProcessBuilder;
using Salesforce;

namespace ProcessBuilderTest
{
    [TestClass]
    public class CreateProcessTest : HelperTests
    {
        [TestMethod]
        public void CreateProcess()
        {
            Assert.IsTrue(LoginPage.IsNotAt, "Failed to login.");
            Salesforce.CollectionPage.ProcessBuilderPage.GoTo();
            Salesforce.CollectionPage.ProcessBuilderPage.AddITRProcess();

        }

        [TestMethod]
        public void RemoveProcess()
        {
            Assert.IsTrue(LoginPage.IsNotAt, "Failed to login.");
            Salesforce.CollectionPage.ProcessBuilderPage.GoTo();
            Salesforce.CollectionPage.ProcessBuilderPage.RemoveProcesses("Omni-channel Process");

        }
    }
}

