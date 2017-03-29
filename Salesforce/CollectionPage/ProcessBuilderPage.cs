using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Salesforce.Navigation;
using Salesforce.Utility;
using OpenQA.Selenium.Support.UI;


namespace Salesforce.CollectionPage
{

    public class ProcessBuilderPage
    {
        public static int mover = 0;
        public static void GoTo()
        {

            CommonFunctions.ClickSetup();
            var searchBox = Driver.Instance.FindElement(By.Id("setupSearch"));
            searchBox.SendKeys("process");
            Driver.Wait(TimeSpan.FromSeconds(1));
            LeftNavigation.Build.Create.Workflow_Approvals.ProcessBuilder.Select();

        }

        public static void RemoveProcesses()
        {
            Driver.Wait(TimeSpan.FromSeconds(4));
            var processes = Driver.Instance.FindElement(By.ClassName("processNumber"));
            int count = Int32.Parse(processes.Text.Split(' ')[0]);
            
            if (count > 0)
            {

                
                for (int j = count; j > 0; j--)
                {
                    var bodyRow = Driver.Instance.FindElements(By.ClassName("processuimgntConsoleListRow"))[j-1];
                    var process = bodyRow.FindElement(By.ClassName("label"));
                    var name = process.GetAttribute("title");

                    NameType myName;
                    bodyRow = Driver.Instance.FindElements(By.ClassName("processuimgntConsoleListRow"))[j-1];
                    var statuses = bodyRow.FindElement(By.ClassName("status"));
                    var myStatus = statuses.GetAttribute("title");

                    Console.WriteLine("name is {0} and status is {1}", name, myStatus);
                    if (Enum.TryParse(name, false, out myName))
                    {
                        if (myStatus == "Active")
                        {
                            Deactivate(myName, j-1);  
                        }
                        
                    }
                    else
                    {
                        DeactivateAndDeleteNonDefaultProcess(j-1);
                    }
                }
            }
            backToSetup();
        }

        
        private static void Deactivate(NameType name, int row)
        {
            switch (name)
            {
                case NameType.ConfirmOptIn:
                    deactivateProcess(row);
                    break;

                case NameType.ScheduledMessageStatusChange:
                    deactivateProcess(row);
                    break;

                case NameType.ScheduleMessage:
                    deactivateProcess(row);
                    break;

                case NameType.SendMessage:
                    deactivateProcess(row);
                    break;

                default:
                    break;
            }
        }
        public static void backToSetup()
        {
            var backToSetup = Driver.Instance.FindElement(By.LinkText("Back To Setup"));
            backToSetup.Click();
        }
        public static void deactivateProcess(int i)
        {
            var bodyRow = Driver.Instance.FindElements(By.ClassName("processuimgntConsoleListRow"))[i];
            var label = bodyRow.FindElement(By.ClassName("label"));
            var arrowHead = label.FindElement(By.ClassName("versionArrow"));
            arrowHead.Click();
            Driver.Wait(TimeSpan.FromSeconds(2));

            var deactivate = Driver.Instance.FindElement(By.LinkText("Deactivate"));
            deactivate.Click();
            Driver.Wait(TimeSpan.FromSeconds(2));

            var confirm = Driver.Instance.FindElement(By.XPath("(//button[@type='button'])[4]"));
            confirm.Click();

            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(15));
            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText("Deactivate")));
            }
            catch (Exception)
            {
                Driver.Wait(TimeSpan.FromSeconds(2));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText("Deactivate")));
            }

        }

        public static void deactivateNDProcess()
        {
            Console.WriteLine("Deactivating process ");
            var deactivate = Driver.Instance.FindElement(By.XPath("(//button[@type='button'])[6]"));
            deactivate.Click();
            Driver.Wait(TimeSpan.FromSeconds(2));

            var confirm = Driver.Instance.FindElement(By.XPath("(//button[@type='button'])[24]"));
            confirm.Click();

            Driver.Wait(TimeSpan.FromSeconds(2));
            var viewAllProcesses = Driver.Instance.FindElement(By.XPath("(//button[@type='button'])[3]"));
            viewAllProcesses.Click();
            Driver.Wait(TimeSpan.FromSeconds(6));
        }

        public static void deleteProcess(int majorRowIndex, int minorRowIndex)
        {
            var bodyRow = Driver.Instance.FindElements(By.ClassName("processuimgntConsoleListRow"))[majorRowIndex];
            var label = bodyRow.FindElement(By.ClassName("label"));
            var arrowHead = label.FindElement(By.ClassName("versionArrow"));
            arrowHead.Click();
            Driver.Wait(TimeSpan.FromSeconds(2));
            Console.WriteLine("I am in delete now");
            var summaryRow = Driver.Instance.FindElements(By.ClassName("processuimgntVersionListRow"));

            if (summaryRow.Count() > 0)
            {
                var action = summaryRow[minorRowIndex].FindElement(By.ClassName("action"));
                var delete = action.FindElement(By.TagName("a"));
                delete.Click();
                Driver.Wait(TimeSpan.FromSeconds(4));

                var confirmDelete = Driver.Instance.FindElement(By.XPath("(//button[@type='button'])[4]"));
                confirmDelete.Click();
                Driver.Wait(TimeSpan.FromSeconds(4));
            }
        }

        public static void clickDownArrow(int x)
        {
            var sumRows = Driver.Instance.FindElements(By.ClassName("processuimgntVersionListRow"));
            if (sumRows.Count() == 0)
            {
                var bodyRow = Driver.Instance.FindElements(By.ClassName("processuimgntConsoleListRow"))[x];
                var label = bodyRow.FindElement(By.ClassName("label"));
                var arrowHead = label.FindElement(By.ClassName("versionArrow"));
                arrowHead.Click();
                Console.WriteLine("mouth open");
            }

            Driver.Wait(TimeSpan.FromSeconds(3));
        }

        public static void clickUpArrow(int x)
        {
            var sumRows = Driver.Instance.FindElements(By.ClassName("processuimgntVersionListRow"));
            if (sumRows.Count() != 0)
            {
                var bodyRow = Driver.Instance.FindElements(By.ClassName("processuimgntConsoleListRow"))[x];
                var label = bodyRow.FindElement(By.ClassName("label"));
                var arrowHead = label.FindElement(By.ClassName("versionArrow"));
                arrowHead.Click();
                Console.WriteLine("mouth closed");
            }

            Driver.Wait(TimeSpan.FromSeconds(3));
        }
        

        public static void DeactivateAndDeleteNonDefaultProcess(int superRowIndex)
        {
            clickDownArrow(superRowIndex);
            var summaryRows = Driver.Instance.FindElements(By.ClassName("processuimgntVersionListRow"));
            int numOfSubrows = summaryRows.Count();
            Console.WriteLine("I have {0} rows when i is {1} ", numOfSubrows, superRowIndex);
            clickUpArrow(superRowIndex);
            for (int k = numOfSubrows; k > 0; k--)
            {
                clickDownArrow(superRowIndex);
                summaryRows = Driver.Instance.FindElements(By.ClassName("processuimgntVersionListRow"));
                Console.WriteLine("Here k is {0}", k);
                var statusOfSummaryRow = summaryRows[k - 1].FindElement(By.ClassName("status")).GetAttribute("title");
                Console.WriteLine("Status of subrow {0} is {1}", k-1,statusOfSummaryRow );
                clickUpArrow(superRowIndex);
                if (statusOfSummaryRow == "Inactive")
                {
                    deleteProcess(superRowIndex, k - 1);
                    Console.WriteLine("row {0} that was inactive is deleted ", k-1);
                }
                else
                {
                    clickDownArrow(superRowIndex);
                    summaryRows = Driver.Instance.FindElements(By.ClassName("processuimgntVersionListRow"));
                    var processVersion = summaryRows[k - 1].FindElement(By.ClassName("label")).FindElement(By.TagName("a"));
                    processVersion.Click();
                    Driver.Wait(TimeSpan.FromSeconds(3));
                    deactivateNDProcess();
                    Console.WriteLine("The summary row is {0} has been deactivated", k-1);
                    deleteProcess(superRowIndex, k - 1);
                    Console.WriteLine("row {0} that was active is deleted ", k - 1);
                }
            }
         }
    }
    public enum NameType
    {
        ConfirmOptIn,
        ScheduleMessage,
        ScheduledMessageStatusChange,
        SendMessage
    } 

}
