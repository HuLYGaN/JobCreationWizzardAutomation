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
    public class LoginPage
    {

        public static bool IsAt
        {
            get 
            {
                var h1s = Driver.Instance.FindElements(By.TagName("h1"));
                if (h1s.Count > 0)
                    return h1s[0].Text == "Login";
                return false;
            }
        }

        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }
    }

    public class LoginCommand
    {
        private readonly string userName;
        private string password;

        public LoginCommand(string userName)
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

            var username = Driver.Instance.FindElement(By.Id("user_email"));
            username.SendKeys(userName);

            var pass = Driver.Instance.FindElement(By.Id("user_password"));
            pass.SendKeys(password);

            var loginButton = Driver.Instance.FindElement(By.Name("commit"));
            loginButton.Click();
         
        }
    }
}

