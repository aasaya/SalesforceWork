using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salesforce;

namespace SalesforceTests
{
    public class SfHelperTests
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("dummyUsername").WithPassword("dummyPassword").Login();
            Driver.Instance.Manage().Window.Maximize();

        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
