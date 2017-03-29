using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Salesforce
{
    public class CasesPage
    {
        public static void GoTo()
        {
            Driver.Instance.Manage().Window.Maximize();
            var CasesTab = Driver.Instance.FindElement(By.LinkText("Cases"));
            CasesTab.Click();
            Driver.Wait(TimeSpan.FromSeconds(3), "hotlist_mode");
        }

        public static void ClickNameLink()
        {
            var OuterTable = Driver.Instance.FindElements(By.TagName("table"))[1];
            var InnerTable = OuterTable.FindElements(By.TagName("table"))[1];
            var name = InnerTable.FindElements(By.TagName("a"))[0];
            name.Click();
            Driver.Wait(TimeSpan.FromSeconds(3), "publishersharebutton");
        }
    }
}
