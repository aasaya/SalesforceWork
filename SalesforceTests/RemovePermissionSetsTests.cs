using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salesforce.CollectionPage;
using Salesforce.Navigation;
using Salesforce.SinglePage;

namespace SalesforceTests
{
    [TestClass]
    //Removing Permission Set assignments from LTAdmin, LTManager, LTAgent & LTSendTexttoList
    public class RemovePermissionSetsTests : SfHelperTests
    {
        [TestMethod]
        public void User_Can_Remove_PermissionSets_from_LiveTextAdmin()
        {
            //PermissionSetsPage.GoTo();
            LiveTextAdminPage.RemovePermissionSets();

            Assert.IsTrue(LiveTextAdminPage.PermissionSetsRemoved(), "Removal of one of the permission sets failed.");
        }

        [TestMethod]
        public void User_Can_Remove_PermissionSets_from_LiveTextManager()
        {
            //PermissionSetsPage.GoTo();
            LiveTextManagerPage.RemovePermissionSets();

            Assert.IsTrue(LiveTextManagerPage.PermissionSetsRemoved(), "Removal of one of the permission sets failed.");
        }

        [TestMethod]
        public void User_Can_Remove_PermissionSets_from_LiveTextAgent()
        {
            //PermissionSetsPage.GoTo();
            LiveTextAgentPage.RemovePermissionSets();

            Assert.IsTrue(LiveTextAgentPage.PermissionSetsRemoved(), "Removal of one of the permission sets failed.");
        }

        [TestMethod]
        public void User_Can_Remove_PermissionSets_from_LiveTextSendTextToList()
        {
            //PermissionSetsPage.GoTo();
            LiveTextSendTextToListPage.RemovePermissionSets();

            Assert.IsTrue(LiveTextSendTextToListPage.PermissionSetsRemoved(), "Removal of one of the permission sets failed.");
        } 
    }
}
