using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Salesforce.Navigation;

namespace Salesforce.SinglePage
{
    public class ConversationSessionLayoutPage
    {
        public static void GoTo()
        {
            LeftNavigation.Build.Create.Objects.Select();
        }
        
        public static void ClickCustomConsoleComponents()
        {
            var ccc = Driver.Instance.FindElement(By.LinkText("Custom Console Components"));
            ccc.Click();
        }
        public class LeftSidebar
        {
            public static void Remove()
            {
              
                //Just removed LeftNavigation.xxx.LTAIsInstalled().  Cleanup may be needed
                if (Utility.CommonFunctions.IsLTAInstalled())
                {
    
                    Utility.CommonFunctions.ClickSetup();
                    ConversationSessionLayoutPage.GoTo();
                    var conversationSession = Driver.Instance.FindElement(By.LinkText("Conversation Session"));
                    conversationSession.Click();
                    ConversationSessionPage.PageLayouts.Edit.Select();
                    ConversationSessionLayoutPage.ClickCustomConsoleComponents();

                    if (LiveTextVisualForcePageIsPresent())
                    {
                        var remove = Driver.Instance.FindElement(By.Id("removeLinkWS_LEFT0"));
                        remove.Click();
                    }
                    if (QuickTextVisualForcePageIsPresent())
                    {
                        var remove = Driver.Instance.FindElement(By.Id("removeLinkWS_LEFT1"));
                        remove.Click();
                    }

                    var save = Driver.Instance.FindElement(By.Name("save"));
                        save.Click(); 
                  } 
                
               }
        }

        public static bool LiveTextVisualForcePageIsPresent()
        {
            var ltvfp = Driver.Instance.FindElement(By.Id("removeLinkWS_LEFT0"));
                return (ltvfp.Displayed);
        }
        public static bool QuickTextVisualForcePageIsPresent()
        {
            var qtvfp = Driver.Instance.FindElement(By.Id("removeLinkWS_LEFT1"));
            return (qtvfp.Displayed);
        }



        /* public static bool CheckSuccess()
         {
             LeftNavigation.Build.Create.Objects.Select();
             //if (LeftNavigation.Build.Create.Objects.LTAIsInstalled())
             if (Utility.CommonFunctions.IsLTAInstalled())
             {
                 FromCustomObjectsToCustomComponents();
                 return SidebarRemoved();
             }
             else
                 return true;
         } */

        public static void FromCustomObjectsToCustomComponents()
        {
            LeftNavigation.Build.Create.Objects.ConversationSession.Select();
            ConversationSessionPage.PageLayouts.Edit.Select();
            ClickCustomConsoleComponents();
        }
    }       
}
