using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace JobCreationWizzardAutomation
{
    public class NewJobPageTechCall
    {
        public static string IsAt
        {
            get
            {
                var isAt = Driver.Instance.FindElement(By.XPath("html/body/div[2]/div/div[2]/div/div[1]/section/div/div[2]/div/div[2]/div[3]/div[5]/div/div[1]/div[1]/div"));
                if (isAt != null)
                    return isAt.Text;
                return "";
            }
        }

        public static void Jump()
        {

            var next = Driver.Instance.FindElement(By.XPath("html/body/div[2]/div/div[2]/div/div[1]/section/div/div[2]/div/div[2]/div[3]/div[5]/div/div[2]/div/a"));
            next.Click();
        }
    }
}
