using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Salesforce.Utility;

namespace Salesforce
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress);
        }

        public static void Logout()
        {
            var name = Driver.Instance.FindElement(By.Id("userNavLabel"));
            name.Click();

            var logoutlink = Driver.Instance.FindElement(By.LinkText("Logout"));
            logoutlink.Click();

            Driver.Wait(TimeSpan.FromSeconds(3));
        }
        public static bool IsNotAt
        {
            get 
            {
                if ((PageSelector.CheckPage("salesforce.com - Customer Secure Login Page")) == true)
                    return false;
                return true; 
            }
        }

        public static bool IsAt
        {
            get { return PageSelector.CheckPage("salesforce.com - Customer Secure Login Page"); }
        }
        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }
        //This function makes the active app Sales
        public static void Reset()
        {
            Driver.Wait(TimeSpan.FromSeconds(3), "userNavLabel");
            var button = Driver.Instance.FindElement(By.Id("tsidLabel"));
            if (button.Text != "Sales")
            {
                button.Click();
                var sales = Driver.Instance.FindElement(By.LinkText("Sales"));
                sales.Click();

                if (CommonFunctions.isAlertPresent())
                {
                    IAlert alert = Driver.Instance.SwitchTo().Alert();
                    alert.Accept();
                }
                
            }          
        }
    }

    public class LoginCommand
    {
        private readonly string userName;
        private string password;

        public LoginCommand (string userName)
        {
            this.userName = userName;
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            var loginInput = Driver.Instance.FindElement(By.Id("username"));
            loginInput.SendKeys(userName);

            var passwordInput = Driver.Instance.FindElement(By.Id("password"));
            passwordInput.SendKeys(password);

            var loginButton = Driver.Instance.FindElement(By.Id("Login"));
            loginButton.Click();
        }
    }
    public class PageSelector
    {
        public static bool CheckPage(string PageTitle)
        {
            String parentWindow = Driver.Instance.CurrentWindowHandle;
            int winCount = Driver.Instance.WindowHandles.Count;
            var handles = Driver.Instance.WindowHandles.Take(winCount);
            if (winCount > 0)
            {
                Driver.Instance.SwitchTo().Window(handles.ElementAt(winCount - 1));
                if (Driver.Instance.Title == PageTitle)
                {
                    if (winCount > 1)
                    { 
                    Driver.Instance.Close();
                    Driver.Instance.SwitchTo().Window(parentWindow);
                    }
                    return true;
                }
                else
                {
                    if (winCount > 1)
                    {
                        Driver.Instance.Close();
                        Driver.Instance.SwitchTo().Window(parentWindow);
                    }
                    return false;
                }
            }
            else return false;
        }
    }
}
