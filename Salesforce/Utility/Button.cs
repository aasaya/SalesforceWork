using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Salesforce.CollectionPage;

namespace Salesforce
{
    public class Button
    {
        public static void Remove(string buttonId, string tableMemberId, string saveButtonId)
        {
            var button = Driver.Instance.FindElement(By.Id(buttonId));
            var outerTable = Driver.Instance.FindElements(By.TagName("table"))[1];
            var innerTable = outerTable.FindElement(By.TagName("table"));

            Actions builder = new Actions(Driver.Instance);
 
            builder.ClickAndHold(button).MoveToElement(innerTable).Release().Build().Perform();

            var clickTable = Driver.Instance.FindElement(By.Id(tableMemberId));
            clickTable.Click();

            var saveButton = Driver.Instance.FindElement(By.Id(saveButtonId));
            saveButton.Click();
        }

        public static bool IsRemoved(string buttonName)
        {
            var test = Driver.Instance.FindElements(By.ClassName("btn"));
            for (int i = 0; i < test.Count; i++)
            {
                if (test.ElementAt(i).Text.Contains(buttonName))
                {
                    return false;
                }
            }
            return true;
        }

        //Remove Opt-out, Opt-in and Send Text to List from Selected to Available buttons in List View
        public static void RemoveButtons()
        {
            var selectedButtons = Driver.Instance.FindElement(By.Id("actionRefs_select_1"));
            var selection = selectedButtons.FindElements(By.TagName("option"));
            int i = selection.Count;
            var leftArrow = Driver.Instance.FindElement(By.CssSelector("img.leftArrowIcon"));
            
            while (i > 0)
            {
                selection.ElementAt(i - 1).Click();
                leftArrow.Click();
                i--;
            }
            var save = Driver.Instance.FindElement(By.Name("save"));
            save.Click();
        }

        //ButtonsRemoved used by ListView pages
        public static bool ButtonsRemoved()
        {
            var selectedButtons = Driver.Instance.FindElement(By.Id("actionRefs_select_1"));
            return (selectedButtons.FindElements(By.TagName("option"))[0].GetAttribute("label").Equals("--None--"));
        }

        public static void ClickCancel()
        {
            var cancel = Driver.Instance.FindElement(By.Name("cancel"));
            cancel.Click();
        }

        public static IWebElement ReturnButton(string buttonName)
        {
            var test = Driver.Instance.FindElements(By.ClassName("btn"));
            
            for (int i = 0; i < test.Count; i++)
            {
                if (test.ElementAt(i).Text.Contains(buttonName))
                    return test.ElementAt(i);
            }
            return null;
        }

        public static string ReturnId(string buttonName)
        {
            var test = Driver.Instance.FindElements(By.ClassName("btn"));
            for (int i = 0; i < test.Count; i++)
            {
                if (test.ElementAt(i).Text.Contains(buttonName))
                {
                    Console.WriteLine(test.ElementAt(i).GetAttribute("id"));
                    return test.ElementAt(i).GetAttribute("id");
                }  
            }
            return "not_found";
        }
    }
}
