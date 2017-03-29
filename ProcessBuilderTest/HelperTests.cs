using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salesforce;

namespace ProcessBuilderTest
{
    public class HelperTests
    {
       
            [TestInitialize]
            public void Init()
            {
                Driver.Initialize();
                LoginPage.GoTo();
                LoginPage.LoginAs("aasaya@60demo.com.pasandbox1").WithPassword("Gilligan5").Login();

            }

            [TestCleanup]
            public void Cleanup()
            {
                Driver.Close();
            }
      }
}