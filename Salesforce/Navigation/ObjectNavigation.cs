using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Salesforce.Utility;

namespace Salesforce.Navigation
{
    public class ObjectNavigation
    {
        public static void CustomizeSearchLayoutGoTo(string objectId, string searchLayoutId)
        {
            Driver.Instance.Manage().Window.Maximize();
            CommonFunctions.ClickSetup();

            var customize = Driver.Instance.FindElement(By.Id("Customize_font"));
            customize.Click();

            var criticalUpdates = Driver.Instance.FindElements(By.Id("cruc_notify"));
            if (criticalUpdates.Count() > 0)
            {
                var ignore = Driver.Instance.FindElement(By.Id("cruc_displayno"));
                ignore.Click();

                var ok = Driver.Instance.FindElement(By.Name("ok"));
                ok.Click();
            }

            var objects = Driver.Instance.FindElement(By.Id(objectId));
            objects.Click();

            var searchLayouts = Driver.Instance.FindElement(By.Id(searchLayoutId));
            searchLayouts.Click();
        }
    }
}
