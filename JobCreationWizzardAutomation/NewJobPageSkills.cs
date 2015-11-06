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
    public class NewJobPageSkills
    {
        public static string IsAt
        {
            get
            {
                var isAt = Driver.Instance.FindElement(By.XPath("//span[contains(.,'Enter all of the skills and technologies required for this position.')]"));
                if (isAt != null)
                    return isAt.Text;
                return "";
            }
        }

        public static string Validation_Message_One_Skill_Required
        {
            get
            {
                var validationMessageOne = Driver.Instance.FindElement(By.XPath("html/body/div[2]/div/div[2]/div/div[2]/div[4]/div/div[2]"));
                if (validationMessageOne != null)
                    return validationMessageOne.Text;
                return "";
            }
        }

        public static string Validation_Correct_Position
        {
            get
            {
                var validationMessageOne = Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_required_skills']/div/div[1]/div/div[3]/div[3]/div/div/span"));
                if (validationMessageOne != null)
                    return validationMessageOne.Text;
                return "";
            }
        }

        public static string Correct_Level
        {
            get
            {
                var validationMessageOne = Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_required_skills']/div/div[1]/div/div[3]/div[2]/div/div/div[1]/div/select")).FindElement(By.CssSelector("option[value='2']"));
                if (validationMessageOne != null)
                    return validationMessageOne.Text;
                return "";
            }
        }


        public static Skills Required(string required)
        {
            return new Skills(required);
        }
    }

    public class Skills
    {
        private readonly string required;
        private string skillLevel;


        public Skills(string required)
        {
            this.required = required;
        }

        public Skills LevelSelector(string skillLevel)
        {
            this.skillLevel = skillLevel;
            return this;
        }

        public void Populate()
        {
            var skill = Driver.Instance.FindElement(By.Id("job_skill_sets"));
            skill.SendKeys(required);
            skill.SendKeys(Keys.Enter);
            skill.Clear();
            Thread.Sleep(1000);
        }

        public void Level()
        {
            var skill = Driver.Instance.FindElement(By.Id("job_skill_sets"));
            skill.SendKeys(required);
            skill.SendKeys(Keys.Enter);

            switch (skillLevel)
            {
                case "Competent":
                    break;

                case "Strong":
                    var sl = Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_required_skills']/div/div[1]/div/div[3]/div[2]/div/div/div[1]/div/select")).FindElement(By.CssSelector("option[value='1']"));
                    sl.Click();
                    break;

                case "Expert":
                    var sl1 = Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_required_skills']/div/div[1]/div/div[3]/div[2]/div/div/div[1]/div/select")).FindElement(By.CssSelector("option[value='2']"));
                    sl1.Click();
                    break;

                case "":
                    break;

                default: throw new InvalidOperationException("Not valid input for commitment in the test.");
            }
        }


        public void Next()
        {
            var skill = Driver.Instance.FindElement(By.Id("job_skill_sets"));
            skill.SendKeys(required);
            skill.SendKeys(Keys.Enter);
            var next = Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_required_skills']/div/div[2]/div[2]/button"));
            next.Click();
        }
    }
}


