using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Salesforce.Utility;

namespace Salesforce.Navigation
{
    public class LeftNavigation
    {
        public class Build
        {
            public class Create
            {
                public class Workflow_Approvals
                {
                    public class ProcessBuilder
                    {
                        public static void Select()
                        {
                            Driver.Instance.Manage().Window.Maximize();
                            LinkSelector.ById.Select("ProcessAutomation_font");
                        }
                    }
                }
                public class Objects
                {
                    public static void Select()
                    {
                        Driver.Instance.Manage().Window.Maximize();
                        //LinkSelector.ById.Select("setupLink");
                        CommonFunctions.ClickSetup();
                        LinkSelector.ById.Select("DevTools_font");
                        LinkSelector.ById.Select("CustomObjects_font");
                    }
                    public static bool LTAIsInstalled()
                    {
                        return CommonFunctions.stringLookupByText("Conversation Session");
                    }
                    public class ConversationSession
                    {
                        public static void Select()
                        {
                            LinkSelector.ByLinkText.Select("Conversation Session");
                        }
                    }
                }
            }
            public class Customize
            {
                public class Accounts
                {
                    public class SearchLayouts
                    {
                        public static void Select()
                        {
                            ObjectNavigation.CustomizeSearchLayoutGoTo("Account_font", "AccountSearchLayouts_font");
                        }

                        public class AccountsListView
                        {
                            public static bool LTAIsInstalled()
                            {
                                bool test = CommonFunctions.stringLookupByText("Click here to create a new custom list button");
                                if (test == true)
                                    return false;
                                else
                                    return true;
                            }
                            public static void ClickEdit()
                            {
                                LinkSelector.ByXPath.Select("(//a[contains(text(),'Edit')])[5]");
                            }
                        }
                        
                    }
                }

                public class Leads
                {
                    public class SearchLayouts
                    {
                        public static void Select()
                        {
                            ObjectNavigation.CustomizeSearchLayoutGoTo("Lead_font", "LeadSearchLayouts_font");
                        }
                        public class LeadsListView
                        {
                            public static bool LTAIsInstalled()
                            {
                                bool test = CommonFunctions.stringLookupByText("Click here to create a new custom list button");
                                if (test == true)
                                    return false;
                                else
                                    return true;
                            }
                            public static void ClickEdit()
                            {
                                LinkSelector.ByXPath.Select("(//a[contains(text(),'Edit')])[5]");
                            }
                        }
                    }
                }

                public class Contacts
                {
                    public class SearchLayouts
                    {                       
                        public static void Select()
                        {
                            ObjectNavigation.CustomizeSearchLayoutGoTo("Contact_font", "ContactSearchLayouts_font");
                        }
                        public class ContactsListView
                        {
                            public static bool LTAIsInstalled()
                            {
                                bool test = CommonFunctions.stringLookupByText("Click here to create a new custom list button");
                                if (test == true)
                                    return false;
                                else
                                    return true;
                            }
                            public static void ClickEdit()
                            {
                                LinkSelector.ByXPath.Select("(//a[contains(text(),'Edit')])[5]");
                            }
                        }                       
                    }
                }

                public class Cases
                {
                    public class SearchLayouts
                    {
                        public static void Select()
                        {
                            ObjectNavigation.CustomizeSearchLayoutGoTo("Case_font", "CaseSearchLayouts_font");
                        }
                        public class CasesListView
                        {
                            public static bool LTAIsInstalled()
                            {
                                bool test = CommonFunctions.stringLookupByText("Click here to create a new custom list button");
                                if (test == true)
                                    return false;
                                else
                                    return true;
                            }
                            public static void ClickEdit()
                            {
                                LinkSelector.ByXPath.Select("(//a[contains(text(),'Edit')])[5]");
                            }
                        }                  
                    }
                }
            }
        }
        public class Administer
        {
            public class ManageUsers
            {
                public class PermissionSets
                {
                    public static void GoTo()
                    {
                        CommonFunctions.ClickSetup();
                        var manageUsers = Driver.Instance.FindElement(By.Id("Users_font"));
                        manageUsers.Click();

                        try
                        {

                            // Check the presence of alert
                            IAlert alert = Driver.Instance.SwitchTo().Alert();
                            // Alert present; click ignore
                            var ignore = Driver.Instance.FindElement(By.Id("cruc_displayno"));
                            ignore.Click();
                            // if present consume the alert
                            alert.Accept();

                        }
                        catch (NoAlertPresentException ex)
                        {
                            // Alert not present
                        }

                    

                    var permissionSets = Driver.Instance.FindElement(By.Id("PermSets_font")); 
                        permissionSets.Click();

                    }
                    public static bool LTAIsInstalled()
                    {
                        return CommonFunctions.stringLookupByText("LiveText Admin");
                    }
                    public static void ClickLiveTextAdmin()
                    {
                        LinkSelector.ByLinkText.Select("LiveText Admin");
                    }
                    public static void ClickLiveTextAgent()
                    {
                        LinkSelector.ByLinkText.Select("LiveText Agent");
                    }
                    public static void ClickLiveTextManager()
                    {
                        LinkSelector.ByLinkText.Select("LiveText Manager");
                    }
                    public static void ClickLiveTextSendTextToList()
                    {
                        LinkSelector.ByLinkText.Select("LiveText Send Text to List");
                    }
                }
            }
        }
    }
}
