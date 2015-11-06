using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobCreationWizzardAutomation;

namespace JobCreationWizzardTests
{
    [TestClass]
    public class NewJobTestsDetails : JobCreationWizzardTest
    {
        [TestMethod]
        public void Proceed_Job_Details_No_Input()
        {
            NewJobPage.Job("QA Engineer Test Job").JobDescription("This is descriptions for QA Engineer Test Job").Next();
            NewJobPage.Language("")
                .DesiredCommitment("Full-time")
                .ZonePreferences("Yes")
                .TimeZone("")
                .HoursOverlap("")
                .StartDate("")
                .EstimatedLength("")
                .RemoveEnglish("Yes")
                .Next();

            Assert.AreEqual(NewJobPageDetails.Validation_Message_One_First_Iteration, "You can't leave this empty", "No message displayed.");
            Assert.AreEqual(NewJobPageDetails.Validation_Message_Two_First_Iteration, "You can't leave this empty", "No message displayed.");
            Assert.AreEqual(NewJobPageDetails.Validation_Message_Three_First_Iteration, "You can't leave this empty", "No message displayed.");
            Assert.AreEqual(NewJobPageDetails.Validation_Message_Language, "Languages: You can't leave this empty", "No message displayed.");
        }

        [TestMethod]
        public void Proceed_Job_Details_Start_Date_String_Input()
        {
            NewJobPage.Job("QA Engineer Test Job").JobDescription("This is descriptions for QA Engineer Test Job").Next();
            NewJobPage.Language("")
                .DesiredCommitment("Full-time")
                .ZonePreferences("No")
                .TimeZone("")
                .HoursOverlap("")
                .StartDate("This is a string input for a start date")
                .EstimatedLength("2-4 weeks")
                .RemoveEnglish("")
                .Next();

            Assert.AreEqual(NewJobPageDetails.Validation_Message_Invalid_Date_Format, "Invalid date format", "No message displayed.");
        }

        [TestMethod]
        public void Proceed_Job_Details_All()
        {
            NewJobPage.Job("QA Engineer Test Job").JobDescription("This is descriptions for QA Engineer Test Job").Next();
            NewJobPage.Language("Chinese")
                .DesiredCommitment("Full-time")
                .ZonePreferences("Yes")
                .TimeZone("Pacific Time")
                .HoursOverlap("2")
                .StartDate("2015-12-06")
                .EstimatedLength("2-4 weeks")
                .RemoveEnglish("Yes")
                .Next();

            Assert.AreEqual(NewJobPageSkills.IsAt, "Enter all of the skills and technologies required for this position.", "Error");
        }

    }
}
