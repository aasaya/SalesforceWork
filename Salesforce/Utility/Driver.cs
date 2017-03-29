using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace Salesforce
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseAddress
        {
            //get { return "http://test.salesforce.com"; }
            get { return "http://login.salesforce.com"; }
        }

        public static void Initialize()
        {
            //Instance = new FirefoxDriver();
            //Instance = new FirefoxDriver(new FirefoxBinary(), new FirefoxProfile(), TimeSpan.FromSeconds(120));
            Instance = new ChromeDriver();
            Wait(TimeSpan.FromSeconds(5));
        }

        public static void Close()
        {
            //Instance.Close();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 1000));
        }

        public static void WaitByXPath(TimeSpan timeSpan, string xpath)
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(timeSpan.TotalSeconds * 1000));
            wait.Until(d => d.FindElement(By.XPath(xpath)));
        }

        public static void Wait(TimeSpan timeSpan, string waitForId)
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(timeSpan.TotalSeconds * 1000));
            wait.Until(d => d.FindElement(By.Id(waitForId)));
        }

        public static void WaitByLinkText(TimeSpan timeSpan, string waitForLinkText)
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(timeSpan.TotalSeconds * 1000));
            wait.Until(d => d.FindElement(By.LinkText(waitForLinkText)));
        }

        public static bool WaitUntilRemovedByLinkText(TimeSpan timeSpan, string waitForLinkText)
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(timeSpan.TotalSeconds * 1000));
            wait.Until<Boolean>((d) =>
            {
                return d.FindElements(By.LinkText(waitForLinkText)).Count == 0;
            });
            return false;
        }
    }
}
