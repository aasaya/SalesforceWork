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
    public class AccountsListViewPage
    {
        public static void GoTo()
        {
            Driver.Instance.Manage().Window.Maximize();
            LeftNavigation.Build.Customize.Accounts.SearchLayouts.Select();
            LeftNavigation.Build.Customize.Accounts.SearchLayouts.AccountsListView.ClickEdit();
        }

        public static void RemoveButtons()
        {
            if (LeftNavigation.Build.Customize.Accounts.SearchLayouts.AccountsListView.LTAIsInstalled())
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
            if (LeftNavigation.Build.Customize.Accounts.SearchLayouts.AccountsListView.LTAIsInstalled())
                return Button.ButtonsRemoved();
            else
                return true;
        }

        public static bool ClickEditThenCheckIfButtonsRemoved()
        {
            LeftNavigation.Build.Customize.Accounts.SearchLayouts.AccountsListView.ClickEdit();
            return ButtonsRemoved();
        }
    }
}
