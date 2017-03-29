using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Salesforce.Navigation;

namespace Salesforce.Utility
{
    public class CommonFunctions
    {
        public static void RemovePermissionSets()
        {
            if (IsLTAInstalled())
            {
                //Remove LiveText Admin Permission Sets
                LeftNavigation.Administer.ManageUsers.PermissionSets.GoTo();
                
                var permList = Driver.Instance.FindElements(By.CssSelector("div.x-grid3-cell-inner.x-grid3-col-Label > a > span"));
                for (int i = 0; i < permList.Count(); i++)
                {
                    if (permList[i].GetAttribute("textContent") == "LiveMessage Admin")
                    {
                        permList[i].Click();
                        break;
                    } 
                }        
                
                var manageAssignments = Driver.Instance.FindElement(By.Id("page:console:pc_form:button_manage_assignments"));
                manageAssignments.Click();
                                          
                var allCheckBox = Driver.Instance.FindElements(By.Id("allBox"));

                if (allCheckBox.Count() > 0)
                {
                    allCheckBox[0].Click();

                    var removeAssigments = Driver.Instance.FindElement(By.Id("manage_user_remove_btn"));
                    removeAssigments.Click();

                    IAlert alert = Driver.Instance.SwitchTo().Alert();
                    alert.Accept();
                }
                //Remove LiveText Agent Permission Sets
                LinkSelector.ByLinkText.Select("Permission Sets");
                LinkSelector.ByLinkText.Select("LiveMessage Agent");
                LinkSelector.ById.Select("page:console:pc_form:button_manage_assignments");

                allCheckBox = Driver.Instance.FindElements(By.Id("allBox"));

                if (allCheckBox.Count() > 0)
                {
                    allCheckBox[0].Click();

                    var removeAssigments = Driver.Instance.FindElement(By.Id("manage_user_remove_btn"));
                    removeAssigments.Click();

                    IAlert alert = Driver.Instance.SwitchTo().Alert();
                    alert.Accept();
                }
                //Remove LiveMessage Manager Permission Sets
                LinkSelector.ByLinkText.Select("Permission Sets");
                LinkSelector.ByLinkText.Select("LiveMessage Manager");
                LinkSelector.ById.Select("page:console:pc_form:button_manage_assignments");

                allCheckBox = Driver.Instance.FindElements(By.Id("allBox"));

                if (allCheckBox.Count() > 0)
                {
                    allCheckBox[0].Click();

                    var removeAssigments = Driver.Instance.FindElement(By.Id("manage_user_remove_btn"));
                    removeAssigments.Click();

                    IAlert alert = Driver.Instance.SwitchTo().Alert();
                    alert.Accept();
                }
                //Remove LiveMessage Send Text to List Permission Sets
                LinkSelector.ByLinkText.Select("Permission Sets");
                LinkSelector.ByLinkText.Select("LiveMessage Send Text to List");
                LinkSelector.ById.Select("page:console:pc_form:button_manage_assignments");

                allCheckBox = Driver.Instance.FindElements(By.Id("allBox"));

                if (allCheckBox.Count() > 0)
                {
                    allCheckBox[0].Click();

                    var removeAssigments = Driver.Instance.FindElement(By.Id("manage_user_remove_btn"));
                    removeAssigments.Click();

                    IAlert alert = Driver.Instance.SwitchTo().Alert();
                    alert.Accept();
                }
            }   
        }
        public static void ClickManageAssignments()
        {
            var manageAssignments = Driver.Instance.FindElement(By.Id("page:console:pc_form:button_manage_assignments"));
            manageAssignments.Click();
        }
        public static bool PermissionSetsRemoved()
        {
            var outerTable = Driver.Instance.FindElements(By.TagName("table"))[1];
            var innerTable = outerTable.FindElements(By.TagName("table"))[1];
            var row = innerTable.FindElements(By.TagName("td"))[0];
            if (row.Text == "No records to display.")
                return true;
            else
                return false;
        }
        
        //This function is used to determine if LTA is installed 
        public static bool IsLTAInstalled()
        {
            ClickSetup();
            var searchField = Driver.Instance.FindElement(By.Id("setupSearch"));
            searchField.Click();
            searchField.SendKeys("Install");

            var installedPackages = Driver.Instance.FindElement(By.LinkText("Installed Packages"));
            installedPackages.Click();

            var liveTextForSalesforce = Driver.Instance.FindElements(By.LinkText("LiveMessage for Salesforce"));
            if (liveTextForSalesforce.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool stringLookupByText(string clickHere)
        {
            var test = Driver.Instance.FindElements(By.LinkText(clickHere));
            if (test.Count == 1)
                return true;
            else
                return false;     
        }
       
        public static void ClickSetup()
        {
            var setupLink = Driver.Instance.FindElements(By.Id("setupLink"));
            if (setupLink.Count() > 0)
            {
                setupLink[0].Click();
                return;
            }

            var setup = Driver.Instance.FindElements(By.LinkText("Setup"));

            if (setup.Count > 0)
            {
                setup.ElementAt(0).Click();
                return;
            }
            else
            {
                var label = Driver.Instance.FindElement(By.Id("userNavLabel"));
                label.Click();
                var setup1 = Driver.Instance.FindElement(By.LinkText("Setup"));
                setup1.Click();
                return;
            }
        }
        public static Boolean isAlertPresent()
        {
            try
            {
                Driver.Instance.SwitchTo().Alert();
                return true;
            }   
            catch (NoAlertPresentException Ex)
            {
                return false;
            }   
        }   
    }
}
