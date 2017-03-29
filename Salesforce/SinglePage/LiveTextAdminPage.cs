using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salesforce.Navigation;
using Salesforce.CollectionPage;
using Salesforce.Utility;
using Salesforce.SinglePage;
using OpenQA.Selenium;

namespace Salesforce.SinglePage
{
    public class LiveTextAdminPage
    {
        public static void RemovePermissionSets()
        {
            Console.WriteLine("Is LTA installed?: {0} ", LeftNavigation.Administer.ManageUsers.PermissionSets.LTAIsInstalled());
            if (LeftNavigation.Administer.ManageUsers.PermissionSets.LTAIsInstalled())
            {
                LeftNavigation.Administer.ManageUsers.PermissionSets.ClickLiveTextAdmin();
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
                LeftNavigation.Administer.ManageUsers.PermissionSets.ClickLiveTextAdmin();
                ClickManageAssignments();
                return CommonFunctions.PermissionSetsRemoved();
            }
            else
                return true;
        }
    }
}
