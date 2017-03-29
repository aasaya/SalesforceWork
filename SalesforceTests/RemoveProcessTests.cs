using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salesforce.CollectionPage;

namespace SalesforceTests 
{
    [TestClass]
    //Remove processes from process builder
    public class RemoveProcessTests : SfHelperTests
    {
        [TestMethod]
        public void User_Can_Remove_Processes()
        {
            ProcessBuilderPage.GoTo();
            ProcessBuilderPage.RemoveProcesses();

            //Assert.IsTrue(ProcessBuilderPage.ProcessesRemoved(), "Removal of one of the processes failed.");
            ProcessBuilderPage.backToSetup();
        }
    }
}
