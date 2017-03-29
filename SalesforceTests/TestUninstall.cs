using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salesforce;
using Salesforce.CollectionPage;
using Salesforce.Navigation;
using Salesforce.SinglePage;

namespace SalesforceTests
{
    [TestClass]
    public class TestUninstall : SfHelperTests
    {
        [TestMethod]
        public void user_can_uninstall_saleforce()
        {
            UninstallPage.GoTo();
            UninstallPage.Uninstall();
            Assert.IsTrue(UninstallPage.checkSuccess(), "Uninstall failed.");
        }
    }
}
