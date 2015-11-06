using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace JobCreationWizzardAutomation
{
    public class HomePage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("http://toptal:assay!cuff=Flap@staging.toptal.net");
        
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => d.SwitchTo().ActiveElement().FindElement(By.XPath("/html/body/div[1]/header/div[3]/div/div/nav/ul/li[3]/a")).Displayed);
           
            Driver.Instance.FindElement(By.XPath("/html/body/div[1]/header/div[3]/div/div/nav/ul/li[3]/a")).Click();
        }
    }
}
