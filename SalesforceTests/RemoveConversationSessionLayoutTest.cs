using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salesforce.SinglePage;

namespace SalesforceTests
{
    [TestClass]
    //Removing left side bar from visual source page
    public class RemoveConversationSessionLayoutTest : SfHelperTests
    {
        [TestMethod]
        public void User_Can_Remove_ConversationSessionLayout()
        {
            ConversationSessionLayoutPage.GoTo();
            ConversationSessionLayoutPage.LeftSidebar.Remove();

           // Assert.IsTrue(ConversationSessionLayoutPage.CheckSuccess(), "Removal of sidebar failed.");

        }
    }
}
