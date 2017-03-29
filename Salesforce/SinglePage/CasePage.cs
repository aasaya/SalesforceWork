using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Salesforce
{
    public class CasePage
    {
        public static void ClickEditLayoutLink()
        {
            TabNavigation.Cases.FirstRecent.EditLayout.Select();
            Driver.Wait(TimeSpan.FromSeconds(3), "publisherActionsInfoIcon");
        }

        public static void ReturnToHomePage()
         {
             TabNavigation.Cases.FirstRecent.EditLayout.Cancel.Select();
             Driver.Wait(TimeSpan.FromSeconds(3), "publishersharebutton");
         }
        public static void RemoveButtons()
        {
            int i = 5;
            CasesPage.ClickNameLink();
            ClickEditLayoutLink();
            Boolean isPresent = Driver.Instance.FindElements(By.Id(Button.ReturnId("Send Text Message"))).Count > 0;
            ReturnToHomePage();

            while (isPresent && i > 0)
            {
                RemoveButton.SendText();
                ClickEditLayoutLink();
                isPresent = Driver.Instance.FindElements(By.Id(Button.ReturnId("Send Text Message"))).Count > 0;
                ReturnToHomePage();
                i--;
            } 
        }
        public class RemoveButton
        {
            public static void SendText()
            {

                Driver.Instance.Manage().Window.Maximize();
                ClickEditLayoutLink();
                Button.Remove(Button.ReturnId("Send Text Message"), "IsSelfServiceClosed", "ext-gen129");      
            }
        }

        public static bool ButtonsRemoved()
        {
            ClickEditLayoutLink();
            var Buttons = Driver.Instance.FindElement(By.Id("troughCategory__Button"));
            Buttons.Click();
            return (Button.IsRemoved("Send Text Message"));
        }
    }
}
