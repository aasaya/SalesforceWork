using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salesforce;
using Salesforce.CollectionPage;

namespace SalesforceTests
{
    [TestClass]
    //Moving Selected Buttons to Available Buttons in List Views of Contacts, Leads, Accounts and Cases.
    public class RemoveCustomButtonsTests : SfHelperTests
    {
        [TestMethod]
        public void User_Can_Remove_Custom_Buttons_from_ContactsListView()
        {
            ContactsListViewPage.GoTo();
            ContactsListViewPage.RemoveButtons();

            Assert.IsTrue(ContactsListViewPage.ClickEditThenCheckIfButtonsRemoved(), "Removal of one of the custom buttons failed.");
        } 
        [TestMethod]
        public void User_Can_Remove_Custom_Buttons_from_LeadsListView()
        {
            LeadsListViewPage.GoTo();
            LeadsListViewPage.RemoveButtons();

            Assert.IsTrue(LeadsListViewPage.ClickEditThenCheckIfButtonsRemoved(), "Removal of one of the custom buttons failed.");
        }

       [TestMethod]
        public void User_Can_Remove_Buttons_from_Cases_tab()
        {
            CasesListViewPage.GoTo();
            CasesListViewPage.RemoveButtons();

            Assert.IsTrue(CasesListViewPage.ClickEditThenCheckIfButtonsRemoved(), "Removal of one of the custom buttons failed.");            
        } 
        
        [TestMethod] 
        public void User_Can_Remove_Buttons_from_Accounts_tab()
        {
            
            AccountsListViewPage.GoTo();
            AccountsListViewPage.RemoveButtons();

            Assert.IsTrue(AccountsListViewPage.ClickEditThenCheckIfButtonsRemoved(), "Removal of one of the custom buttons failed."); 
        } 
    }
}
