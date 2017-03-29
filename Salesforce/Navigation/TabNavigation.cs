using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Salesforce
{
    public class TabNavigation
    {
        public class Contacts
        {
            public class FirstRecent
            {
                public class EditLayout
                {
                    public class Cancel
                    {
                        public static void Select()
                        {
                            LinkSelector.ById.Select("ext-gen139");
                        }
                    }
                    public static void Select()
                    {
                        LinkSelector.ByLinkText.Select("Edit Layout");
                    }
                }
            }
        }

        public class Leads
        {
            public class FirstRecent
            {
                public class EditLayout
                {
                    public class Cancel
                    {
                        public static void Select()
                        {
                            LinkSelector.ById.Select("ext-gen119");
                        }
                    }
                    public static void Select()
                    {
                        LinkSelector.ByLinkText.Select("Edit Layout");
                    }
                }
            }
        }

        public class Cases
        {
            public class FirstRecent
            {
                public class EditLayout
                {
                    public class Cancel
                    {
                        public static void Select()
                        {
                            LinkSelector.ById.Select("ext-gen135");
                        }
                    }
                    public static void Select()
                    {
                        LinkSelector.ByLinkText.Select("Edit Layout");
                    }
                }
            }
        }

        public class Accounts
        {
            public class FirstRecent
            {
                public class EditLayout
                {
                    public class Cancel
                    {
                        public static void Select()
                        {
                            LinkSelector.ById.Select("ext-gen107");
                        }
                    }
                    public static void Select()
                    {
                        LinkSelector.ByLinkText.Select("Edit Layout");
                    }
                }
            }
        }

    }
    public class LinkSelector
    {
        public class ByLinkText
        {
            public static void Select(string linkText)
            {
                var Link = Driver.Instance.FindElement(By.LinkText(linkText));
                Link.Click();
            }
        }
        public class ById
        {
            public static void Select(string id)
            {
                var Link = Driver.Instance.FindElement(By.Id(id));
                Link.Click();
            }
        }

        public class ByXPath
        {
            public static void Select(string xpath)
            {
                var Link = Driver.Instance.FindElement(By.XPath(xpath));
                Link.Click();
            }
        }     
    }
}
