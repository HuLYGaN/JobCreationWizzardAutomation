using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace JobCreationWizzardAutomation
{
    public class DahsboardPage
    {
        public static bool IsAt
        {
            get
            {
                var spans = Driver.Instance.FindElements(By.ClassName("notice-body"));
                if (spans.Count > 0)
                    return spans[0].Text == "Signed in successfully.";
                return false;
            }
        }

 
            public static void Add_New_Job()
            {
                var addNewYobButton = Driver.Instance.FindElement(By.XPath("//a[contains(.,'Add New Job')]"));
                addNewYobButton.Click();
            }

        }
    }

