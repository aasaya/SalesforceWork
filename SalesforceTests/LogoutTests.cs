using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salesforce;

namespace SalesforceTests
{

    [TestClass]
    public class LogoutTests:SfHelperTests
    {
       
        [TestMethod]
        public void User_Can_Logout()
        {
            LoginPage.Logout();

            Assert.IsTrue(LoginPage.IsAt, "Failed to logout.");
        }
    }
}
