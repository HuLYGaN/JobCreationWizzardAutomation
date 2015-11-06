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
    public class NewJobPageConfirm
    {
        public static string IsAt
        {
            get
            {
                var isAt = Driver.Instance.FindElement(By.XPath("//span[contains(.,'I understand that Toptal will review this application, talk with me about it, and then start assembling a team to identify the best candidates for this position.')]"));
                if (isAt != null)
                    return isAt.Text;
                return "";
            }
        }

        public static string ConfirmationOne
        {
            get
            {
                var confirmation = Driver.Instance.FindElement(By.XPath("html/body/div[2]/div/div[2]/div/div[2]/div[5]/div[1]/div[2]"));
                if (confirmation != null)
                    return confirmation.Text;
                return "";
            }
        }

        public static string ConfirmationTwo
        {
            get
            {
                var confirmation = Driver.Instance.FindElement(By.XPath("html/body/div[2]/div/div[2]/div/div[2]/div[5]/div[3]/div[2]"));
                if (confirmation != null)
                    return confirmation.Text;
                return "";
            }
        }

        public static string ConfirmationThree
        {
            get
            {
                var confirmation = Driver.Instance.FindElement(By.XPath("html/body/div[2]/div/div[2]/div/div[2]/div[5]/div[2]/div[2]"));
                if (confirmation != null)
                    return confirmation.Text;
                return "";
            }
        }

        public static Confirm Review (bool review)
        {
            return new Confirm(review);
        }

        public static void Next()
        {
        
                var next = Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_confirmation']/div/div[2]/div[2]/button"));
                next.Click();
            
        }
    }

     public class Confirm
        {
            private bool review;
            private bool deposit;
            private bool days;

         public Confirm(bool review)
         {
             this.review = review;
         }

         public Confirm Deposit(bool deposit)
         {
             this.deposit = deposit;
             return this;
         }

         public Confirm Days(bool days)
         {
             this.days = days;
             return this;
         }

         public void Do()
         {
             switch (review)
             {
                 case true:
                     var cl = Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_confirmation']/div/div[1]/div/div[1]/label/span"));
                     cl.Click();
                     break;
                 default: throw new InvalidOperationException("Not valid input for estimated length in the test.");
             }

             switch (deposit)
             {
                 case true:
                     var cl = Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_confirmation']/div/div[1]/div/div[2]/label/span"));
                     cl.Click();
                     break;
                 default: throw new InvalidOperationException("Not valid input for estimated length in the test.");
             }

             switch (days)
             {
                 case true:
                     var cl = Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_confirmation']/div/div[1]/div/div[3]/label/span"));
                     cl.Click();
                     break;
                 default: throw new InvalidOperationException("Not valid input for estimated length in the test.");
             }
         }
     }
}

