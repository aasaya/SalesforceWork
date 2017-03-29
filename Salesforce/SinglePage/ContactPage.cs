using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Salesforce
{
    public class ContactPage
    {
        public static void ClickEditLayoutLink()
        {
            TabNavigation.Contacts.FirstRecent.EditLayout.Select();
            Driver.Wait(TimeSpan.FromSeconds(3), "publisherActionsInfoIcon");
        }

        public static void ReturnToHomePage()
        {
            TabNavigation.Contacts.FirstRecent.EditLayout.Cancel.Select();
            Driver.Wait(TimeSpan.FromSeconds(3), "publishersharebutton");
        }

        public static void RemoveButtons()
        {
            int i = 5;
            ContactsPage.ClickNameLink();
            ClickEditLayoutLink();
            Boolean isPresent = Driver.Instance.FindElements(By.Id(Button.ReturnId("Opt-out for Text Messages"))).Count > 0;
            ReturnToHomePage();

            while (isPresent && i > 0)
            {
                RemoveButton.OptOut();
                ClickEditLayoutLink();
                isPresent = Driver.Instance.FindElements(By.Id(Button.ReturnId("Opt-out for Text Messages"))).Count > 0;
                ReturnToHomePage();
                i--;
            }

            ClickEditLayoutLink();
            isPresent = Driver.Instance.FindElements(By.Id(Button.ReturnId("Opt-in for Text Messages"))).Count > 0;
            ReturnToHomePage();

            while (isPresent && i > 0)
            {
                RemoveButton.OptIn();
                ClickEditLayoutLink();
                isPresent = Driver.Instance.FindElements(By.Id(Button.ReturnId("Opt-in for Text Messages"))).Count > 0;
                ReturnToHomePage();
                i--;
            }

            ClickEditLayoutLink();
            isPresent = Driver.Instance.FindElements(By.Id(Button.ReturnId("Send Text Message"))).Count > 0;
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
            public static void OptOut()
            {
                Driver.Instance.Manage().Window.Maximize();
                ClickEditLayoutLink();
                Button.Remove(Button.ReturnId("Opt-out for Text Messages"), "ext-comp-1081", "ext-gen133");
            }

            public static void OptIn()
            {
                Driver.Instance.Manage().Window.Maximize();
                ClickEditLayoutLink();
                Button.Remove(Button.ReturnId("Opt-in for Text Messages"), "ext-comp-1081", "ext-gen133");
            }

            public static void SendText()
            {
                Driver.Instance.Manage().Window.Maximize();          
                ClickEditLayoutLink();
                Button.Remove(Button.ReturnId("Send Text Message"), "ext-comp-1081", "ext-gen133");
            } 
        }   

        public static bool ButtonsRemoved()
        {
            ClickEditLayoutLink();
            var Buttons = Driver.Instance.FindElement(By.Id("troughCategory__Button"));
            Buttons.Click();
            return (Button.IsRemoved("Opt-out for Text Messages") && Button.IsRemoved("Opt-in for Text Messages") && Button.IsRemoved("Send Text Message"));
        }
    }
}
    

