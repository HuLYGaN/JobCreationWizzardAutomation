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
    public class NewJobPageDetails
    {
        public static string Validation_Message_One_First_Iteration
        {
            get
            {
                var validationMessageOne = Driver.Instance.FindElement(By.XPath("html/body/div[2]/div/div[2]/div/div[2]/div[3]/div[3]/div[2]"));
                if (validationMessageOne != null)
                    return validationMessageOne.Text;
                return "";
            }
        }

        public static string Validation_Message_Two_First_Iteration
        {
            get
            {
                var validationMessageTwo = Driver.Instance.FindElement(By.XPath("html/body/div[2]/div/div[2]/div/div[2]/div[3]/div[1]/div[2]"));
                if (validationMessageTwo != null)
                    return validationMessageTwo.Text;
                return "";
            }
        }

        public static string Validation_Message_Three_First_Iteration
        {
            get
            {
                var validationMessageThree = Driver.Instance.FindElement(By.XPath("html/body/div[2]/div/div[2]/div/div[2]/div[3]/div[2]/div[2]"));
                if (validationMessageThree != null)
                    return validationMessageThree.Text;
                return "";
            }
        }

        public static string Validation_Message_Language
        {
            get
            {
                var validationMessageThree = Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_details']/div/div[1]/div[1]/span"));
                if (validationMessageThree != null)
                    return validationMessageThree.Text;
                return "";
            }
        }

        public static string Validation_Message_Invalid_Date_Format
        {
            get
            {
                var validationMessage = Driver.Instance.FindElement(By.XPath("html/body/div[2]/div/div[2]/div/div[2]/div[3]/div/div[2]"));
                if (validationMessage != null)
                    return validationMessage.Text;
                return "";
            }
        }
    }
}
