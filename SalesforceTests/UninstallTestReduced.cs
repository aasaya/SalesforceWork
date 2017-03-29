using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salesforce;
using Salesforce.CollectionPage;
using Salesforce.Navigation;
using Salesforce.SinglePage;
using Salesforce.Utility;


namespace SalesforceTests
{
    [TestClass]
    public class UninstallTest:SfHelperTests
    {
        [TestMethod]
        public void User_Can_Uninstall_Salesforce()
       {
            // Remove ListViews
            ContactsListViewPage.GoTo();
            ContactsListViewPage.RemoveButtons();

            LeadsListViewPage.GoTo();
            LeadsListViewPage.RemoveButtons();

            CasesListViewPage.GoTo();
            CasesListViewPage.RemoveButtons();

            AccountsListViewPage.GoTo();
            AccountsListViewPage.RemoveButtons(); 

            //Remove permission sets from LiveText Admin
            CommonFunctions.RemovePermissionSets(); 

            //Remove LiveText visual force page
            ConversationSessionLayoutPage.GoTo();
            ConversationSessionLayoutPage.LeftSidebar.Remove(); 
           
            //Disable processes
            ProcessBuilderPage.GoTo();
            ProcessBuilderPage.RemoveProcesses();

            
            UninstallPage.GoTo();
            UninstallPage.Uninstall(); 

        }
    }
}
