using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salesforce;

namespace SalesforceTests
{
    [TestClass]
    //Removing Opt out, Opt in and Send Text Message buttons from Leads, Contacts, Cases and Accounts tabs
    public class RemoveButtonsTests: SfHelperTests
    {    
       [TestMethod]
        public void User_Can_Remove_Buttons_from_Contacts_tab()
        {
            ContactsPage.GoTo();
            ContactPage.RemoveButtons();

            Assert.IsTrue(ContactPage.ButtonsRemoved(), "Removal of one of the Text Message buttons failed.");
            ContactPage.ReturnToHomePage();
        }
        
       [TestMethod]
        public void User_Can_Remove_Buttons_from_Leads_tab()
        {
            LeadsPage.GoTo();
            LeadPage.RemoveButtons();

            Assert.IsTrue(LeadPage.ButtonsRemoved(), "Removal of one of the Text Message buttons failed.");
            LeadPage.ReturnToHomePage();
        } 
             
        [TestMethod]
        public void User_Can_Remove_Buttons_from_Cases_tab()
        {
            CasesPage.GoTo();
            CasePage.RemoveButtons();

            Assert.IsTrue(CasePage.ButtonsRemoved(), "Removal of Send Text Message button failed.");
            CasePage.ReturnToHomePage();
        } 
        
        [TestMethod]
        public void User_Can_Remove_Buttons_from_Accounts_tab()
        {
            AccountsPage.GoTo();
            AccountPage.RemoveButtons();

            Assert.IsTrue(AccountPage.ButtonsRemoved(), "Removal of one of the Text Message buttons failed.");
            AccountPage.ReturnToHomePage();
        }          
    }
}
