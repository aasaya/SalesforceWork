using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Salesforce.Utility;

namespace Salesforce
{
    public class UninstallPage
    {
        public static void GoTo()
        {
            Driver.Instance.Manage().Window.Maximize();
            CommonFunctions.ClickSetup();

            var search = Driver.Instance.FindElement(By.Id("setupSearch"));
            search.SendKeys("Install");

            var packageLink = Driver.Instance.FindElement(By.Id("ImportedPackage_font"));
            packageLink.Click();
        }
        public static void Uninstall()
        {
            Console.WriteLine("The value of uninstalled is: {0}", IsUninstalled());
            if (!IsUninstalled())
            {
                var uninstallLink = Driver.Instance.FindElement(By.LinkText("LiveMessage for Salesforce"));
                uninstallLink.Click();

                var uninstallButton = Driver.Instance.FindElement(By.Name("uninstallPackage"));
                uninstallButton.Click();

                var yesButton = Driver.Instance.FindElement(By.Id("p5"));
                yesButton.Click();

                var nextUninstallButton = Driver.Instance.FindElement(By.Id("Uninstall"));
                nextUninstallButton.Click();
            } 
        }

        public static bool IsUninstalled()
        {
            var outerTable = Driver.Instance.FindElements(By.TagName("table"))[1];
            var innerTable = outerTable.FindElements(By.TagName("table"))[1];
            var uninstall = innerTable.FindElements(By.ClassName("actionLink"));

            for (int i = 0; i < uninstall.Count; i++)
            {
                if (uninstall.ElementAt(i).GetAttribute("title").Contains("LiveMessage for Salesforce"))
                {
                    return false;
                }
            }
                return true;
        }

        public static bool checkSuccess()
        {
            var lta = Driver.Instance.FindElements(By.LinkText("LiveMessage for Salesforce"))[0];
            if (lta.Displayed)
            {
                return Driver.WaitUntilRemovedByLinkText(TimeSpan.FromMinutes(1), "LiveMessage for Salesforce");
            }
            else
                return true;
        }
    }
}
