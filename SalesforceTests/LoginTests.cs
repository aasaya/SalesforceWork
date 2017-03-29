using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salesforce;

namespace SalesforceTests
{
    [TestClass]
    public class LoginTests:SfHelperTests
    {
        [TestMethod]
        public void User_Can_Login()
        {
            Assert.IsTrue(LoginPage.IsNotAt, "Failed to login.");
        }
    }
}
