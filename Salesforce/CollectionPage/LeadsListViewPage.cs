using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Salesforce.Navigation;
using Salesforce.Utility;

namespace Salesforce
{
    public class LeadsListViewPage
    {
        public static void GoTo()
        {
            Driver.Instance.Manage().Window.Maximize();
            LeftNavigation.Build.Customize.Leads.SearchLayouts.Select();
            LeftNavigation.Build.Customize.Leads.SearchLayouts.LeadsListView.ClickEdit();
        }

        public static void RemoveButtons()
        {
            if (LeftNavigation.Build.Customize.Leads.SearchLayouts.LeadsListView.LTAIsInstalled())
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
            if (LeftNavigation.Build.Customize.Leads.SearchLayouts.LeadsListView.LTAIsInstalled())
                return Button.ButtonsRemoved();
            else
                return true;
        }

        public static bool ClickEditThenCheckIfButtonsRemoved()
        {
            LeftNavigation.Build.Customize.Leads.SearchLayouts.LeadsListView.ClickEdit();
            return ButtonsRemoved();
        }
    }
}
