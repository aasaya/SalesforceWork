using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Salesforce.Navigation;
using Salesforce.CollectionPage;
using Salesforce.Utility;

namespace Salesforce.SinglePage
{
    public class LiveTextAgentPage
    {
        public static void RemovePermissionSets()
        {
            if (LeftNavigation.Administer.ManageUsers.PermissionSets.LTAIsInstalled())
            {
                LeftNavigation.Administer.ManageUsers.PermissionSets.ClickLiveTextAgent();
                ClickManageAssignments();
                Driver.Wait(TimeSpan.FromSeconds(3), "manage_user_assign_btn");
                CommonFunctions.RemovePermissionSets();
            }
            
        }

        public static void ClickManageAssignments()
        {
            CommonFunctions.ClickManageAssignments();
        }

        public static bool PermissionSetsRemoved()
        {
            //PermissionSetsPage.GoTo();
            if (LeftNavigation.Administer.ManageUsers.PermissionSets.LTAIsInstalled())
            {
                LeftNavigation.Administer.ManageUsers.PermissionSets.ClickLiveTextAgent();
                ClickManageAssignments();
                return CommonFunctions.PermissionSetsRemoved();
            }
            else
                return true; 
        }
    }
}
