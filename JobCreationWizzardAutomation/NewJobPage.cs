using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace JobCreationWizzardAutomation
{
    public class NewJobPage
    {
        public static string Panel_Text
        {
            get
            {
                var panelText = Driver.Instance.FindElement(By.ClassName("panel-header"));
                if (panelText != null)
                    return panelText.Text;
                return "";
            }
        }


        public static string Note_Text
        {
            get
            {
                var noteText = Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_details']/div/div[1]/div/div[1]/div"));
                if (noteText != null)
                    return noteText.Text;
                return "";
            }
        }

        public static string Validation_Message_One_First_Iteration
        {
            get
            {
                var validationMessageOne = Driver.Instance.FindElement(By.XPath("html/body/div[2]/div/div[2]/div/div[2]/div[2]/div[1]/div[2]"));
                if (validationMessageOne != null)
                    return validationMessageOne.Text;
                return "";
            }
        }


        public static string Validation_Message_Two_First_Iteration
        {
            get
            {
                var validationMessageTwo = Driver.Instance.FindElement(By.XPath("html/body/div[2]/div/div[2]/div/div[2]/div[2]/div[2]/div[2]"));
                if (validationMessageTwo != null)
                    return validationMessageTwo.Text;
                return "";
            }
        }

        public static string Validation_Message_Second_Iteration
        {
            get
            {
                var validationMessageTwo = Driver.Instance.FindElement(By.XPath("html/body/div[2]/div/div[2]/div/div[2]/div[2]/div/div[2]"));
                if (validationMessageTwo != null)
                    return validationMessageTwo.Text;
                return "";
            }
        }



        public static NewJobCommand Job(string jobTitle)
        {
            return new NewJobCommand(jobTitle);
        }

        public static Details Language(string language)
        {
            return new Details(language);
        }
    }


    public class NewJobCommand
    {
        private readonly string jobTitle;
        private string jobDescription;

        public NewJobCommand(string jobTitle)
        {
            this.jobTitle = jobTitle;
        }

        public NewJobCommand JobDescription(string jobDescription)
        {
            this.jobDescription = jobDescription;
            return this;
        }

        public void Next()
        {
            var title = Driver.Instance.FindElement(By.Id("job_title"));
            title.SendKeys(jobTitle);

            var description = Driver.Instance.FindElement(By.Id("job_description"));
            description.SendKeys(jobDescription);

            var next = Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_name_and_description']/div/div[2]/div[2]/button"));
            next.Click();
        }
    }

    public class Details
    {
        private readonly string language;
        private string zonePreference;
        private string desiredCommitment;
        private string timeZone;
        private string hoursOverlap;
        private string startDate;
        private string estimatedLength;
        private string removeEnglish;



        public Details(string language)
        {
            this.language = language;
        }

        public Details ZonePreferences(string zonePreference)
        {
            this.zonePreference = zonePreference;
            return this;
        }

        public Details DesiredCommitment(string desiredCommitment)
        {
            this.desiredCommitment = desiredCommitment;
            return this;
        }

        public Details TimeZone(string timeZone)
        {
            this.timeZone = timeZone;
            return this;
        }

        public Details HoursOverlap(string hoursOverlap)
        {
            this.hoursOverlap = hoursOverlap;
            return this;
        }

        public Details StartDate(string startDate)
        {
            this.startDate = startDate;
            return this;
        }

        public Details EstimatedLength(string estimatedLength)
        {
            this.estimatedLength = estimatedLength;
            return this;
        }

        public Details RemoveEnglish(string removeEnglish)
        {
            this.removeEnglish = removeEnglish;
            return this;
        }



        public void Next()
        {

            var lang = Driver.Instance.FindElement(By.Id("job_languages"));
            lang.SendKeys(language);
            lang.SendKeys(Keys.Enter);

            var date = Driver.Instance.FindElement(By.Id("job_start_date"));
            date.SendKeys(startDate);
         
            if (zonePreference == "Yes")
            {
                var yes = Driver.Instance.FindElement(By.Id("job_prefer_timezone_yes"));
                yes.Click();
            }
            else
            {
                var no = Driver.Instance.FindElement(By.Id("job_prefer_timezone_no"));
            }

            switch (removeEnglish)
            {
                case "Yes":
                    Driver.Instance.FindElement(By.Id("job_languages")).Click();
                    Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_details']/div/div[1]/div/div[11]/div/div/div/div"));
                    Driver.Instance.SwitchTo().ActiveElement();

                    var yes = Driver.Instance.FindElement(By.ClassName("ui-tag-delete_icon_inner"));
                    yes.Click();
                    break;

                case "":
                    break;
                default: throw new InvalidOperationException("Not valid input in the test.");
            }



            switch (desiredCommitment)
            {
                case "Full-time":
                    var comm = Driver.Instance.FindElement(By.Id("job_commitment")).FindElement(By.CssSelector("option[value='full_time']"));
                    comm.Click();
                    break;

                case "Part-time":
                    var comm1 = Driver.Instance.FindElement(By.Id("job_commitment")).FindElement(By.CssSelector("option[value='part_time']"));
                    comm1.Click();
                    break;

                case "Hourly":
                    var comm2 = Driver.Instance.FindElement(By.Id("job_commitment")).FindElement(By.CssSelector("option[value='hourly']"));
                    comm2.Click();
                    break;

                default: throw new InvalidOperationException("Not valid input for commitment in the test.");
            }

            switch (timeZone)
            {
                case "Pacific Time":
                    var time = Driver.Instance.FindElement(By.Id("job_time_zone_name")).FindElement(By.CssSelector("option[value='Pacific Time (US & Canada)']"));
                    time.Click();
                    break;

                case "Central America":
                    var time1 = Driver.Instance.FindElement(By.Id("job_time_zone_name")).FindElement(By.CssSelector("option[value='Central America']"));
                    time1.Click();
                    break;

                case "Eastern Time":
                    var time2 = Driver.Instance.FindElement(By.Id("job_time_zone_name")).FindElement(By.CssSelector("option[value='Eastern Time (US & Canada)']"));
                    time2.Click();
                    break;

                case "":
                    break;

                default: throw new InvalidOperationException("Not valid input for time zone in the test.");
            }


            switch (hoursOverlap)
            {
                case "No preference":
                    var h = Driver.Instance.FindElement(By.Id("job_hours_overlap")).FindElement(By.CssSelector("option[value='']"));
                    h.Click();
                    break;

                case "1":
                    var h1 = Driver.Instance.FindElement(By.Id("job_hours_overlap")).FindElement(By.CssSelector("option[value='1']"));
                    h1.Click();
                    break;

                case "2":
                    var h2 = Driver.Instance.FindElement(By.Id("job_hours_overlap")).FindElement(By.CssSelector("option[value='2']"));
                    h2.Click();
                    break;

                case "3":
                    var h3 = Driver.Instance.FindElement(By.Id("job_hours_overlap")).FindElement(By.CssSelector("option[value='3']"));
                    h3.Click();
                    break;

                case "4":
                    var h4 = Driver.Instance.FindElement(By.Id("job_hours_overlap")).FindElement(By.CssSelector("option[value='4']"));
                    h4.Click();
                    break;

                case "5":
                    var h5 = Driver.Instance.FindElement(By.Id("job_hours_overlap")).FindElement(By.CssSelector("option[value='5']"));
                    h5.Click();
                    break;

                case "6":
                    var h6 = Driver.Instance.FindElement(By.Id("job_hours_overlap")).FindElement(By.CssSelector("option[value='6']"));
                    h6.Click();
                    break;

                case "7":
                    var h7 = Driver.Instance.FindElement(By.Id("job_hours_overlap")).FindElement(By.CssSelector("option[value='7']"));
                    h7.Click();
                    break;

                case "8":
                    var h8 = Driver.Instance.FindElement(By.Id("job_hours_overlap")).FindElement(By.CssSelector("option[value='8']"));
                    h8.Click();
                    break;

                case "9":
                    var h9 = Driver.Instance.FindElement(By.Id("job_hours_overlap")).FindElement(By.CssSelector("option[value='9']"));
                    h9.Click();
                    break;

                case "10":
                    var h10 = Driver.Instance.FindElement(By.Id("job_hours_overlap")).FindElement(By.CssSelector("option[value='10']"));
                    h10.Click();
                    break;

                case "11":
                    var h11 = Driver.Instance.FindElement(By.Id("job_hours_overlap")).FindElement(By.CssSelector("option[value='11']"));
                    h11.Click();
                    break;

                case "12":
                    var h12 = Driver.Instance.FindElement(By.Id("job_hours_overlap")).FindElement(By.CssSelector("option[value='12']"));
                    h12.Click();
                    break;

                case "":
                    break;

                default: throw new InvalidOperationException("Not valid input for hours in the test.");
            }

            switch (estimatedLength)
            {
                case "":
                    var h = Driver.Instance.FindElement(By.Id("job_estimated_length")).FindElement(By.CssSelector("option[value='']"));
                    h.Click();
                    break;

                case "1-2 weeks":
                    var h1 = Driver.Instance.FindElement(By.Id("job_estimated_length")).FindElement(By.CssSelector("option[value='0']"));
                    h1.Click();
                    break;

                case "2-4 weeks":
                    var h2 = Driver.Instance.FindElement(By.Id("job_estimated_length")).FindElement(By.CssSelector("option[value='1']"));
                    h2.Click();
                    break;

                case "4-8 weeks":
                    var h3 = Driver.Instance.FindElement(By.Id("job_estimated_length")).FindElement(By.CssSelector("option[value='2']"));
                    h3.Click();
                    break;

                case "2-3 months":
                    var h4 = Driver.Instance.FindElement(By.Id("job_estimated_length")).FindElement(By.CssSelector("option[value='3']"));
                    h4.Click();
                    break;

                case "3-6 months":
                    var h5 = Driver.Instance.FindElement(By.Id("job_estimated_length")).FindElement(By.CssSelector("option[value='4']"));
                    h5.Click();
                    break;

                case "6-12 months":
                    var h6 = Driver.Instance.FindElement(By.Id("job_estimated_length")).FindElement(By.CssSelector("option[value='5']"));
                    h6.Click();
                    break;

                case "12+ months":
                    var h7 = Driver.Instance.FindElement(By.Id("job_estimated_length")).FindElement(By.CssSelector("option[value='6']"));
                    h7.Click();
                    break;

                case "Unknown":
                    var h8 = Driver.Instance.FindElement(By.Id("job_estimated_length")).FindElement(By.CssSelector("option[value='7']"));
                    h8.Click();
                    break;

                default: throw new InvalidOperationException("Not valid input for estimated length in the test.");
            }

            var next = Driver.Instance.FindElement(By.XPath(".//*[@id='new_job--step_details']/div/div[2]/div[2]/button"));                      
            next.Click();           
        }
    }
}

