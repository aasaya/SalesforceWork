using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Salesforce.SinglePage
{
    public class ConversationSessionPage
    {
        public class PageLayouts
        {
            public class Edit
            {
                public static void Select()
                {
                    var pageLayout = Driver.Instance.FindElement(By.Id("LayoutList_link"));
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(pageLayout).Perform();
                    var edit = Driver.Instance.FindElement(By.XPath("(//a[contains(text(),'Edit')])[2]"));
                    edit.Click();
                }
            }
        }
    }
}
