using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobCreationWizzardAutomation;


namespace JobCreationWizzardTests
{
    [TestClass]
    public class NewJobTestsSkills : JobCreationWizzardTest
    {
        [TestMethod]
        public void Proceed_Job_Skills_Validation()
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

            NewJobPageSkills.Required("").Next();

            Assert.AreEqual(NewJobPageSkills.Validation_Message_One_Skill_Required, "You need to specify at least one skill", "Error");
        }

        [TestMethod]
        public void Correct_Position_Job_Skills_Validation()
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

            NewJobPageSkills.Required("Django").Populate();

            Assert.AreEqual(NewJobPageSkills.Validation_Correct_Position, "Django", "Error");
        }

        [TestMethod]
        public void Proceed_One_Language_Skill_Expert()
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

            NewJobPageSkills.Required("C#").LevelSelector("Expert").Level();

            Assert.AreEqual(NewJobPageSkills.Correct_Level, "Expert", "Error");
        }

        [TestMethod]
        public void Proceed_To_Confirmation()
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

            NewJobPageSkills.Required("Ruby").Populate();
            NewJobPageSkills.Required("Ruby on Rails").LevelSelector("").Next();

            Assert.AreEqual(NewJobPageConfirm.IsAt, "I understand that Toptal will review this application, talk with me about it, and then start assembling a team to identify the best candidates for this position.", "Error");
        }
        }
    }

