using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Salesforce.Navigation;
using Salesforce.Utility;

namespace Salesforce.CollectionPage
{
    public class ContactsListViewPage
    {
        public static void GoTo()
        {
            Driver.Instance.Manage().Window.Maximize();
            LeftNavigation.Build.Customize.Contacts.SearchLayouts.Select();
            LeftNavigation.Build.Customize.Contacts.SearchLayouts.ContactsListView.ClickEdit();
        }

        public static void RemoveButtons()
        {
            if (LeftNavigation.Build.Customize.Contacts.SearchLayouts.ContactsListView.LTAIsInstalled())
            {
                if (!ButtonsRemoved())               
                    Button.RemoveButtons();              
                else
                    Button.ClickCancel();
            }
            else
                Button.ClickCancel();    
        }

        public static bool ButtonsRemoved()
        {
            if (LeftNavigation.Build.Customize.Contacts.SearchLayouts.ContactsListView.LTAIsInstalled())           
                return Button.ButtonsRemoved();           
            else
                return true;
        }

        public static bool ClickEditThenCheckIfButtonsRemoved()
        {
            LeftNavigation.Build.Customize.Contacts.SearchLayouts.ContactsListView.ClickEdit();
            return ButtonsRemoved();
        }
    }
}
