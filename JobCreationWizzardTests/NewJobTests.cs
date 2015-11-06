using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobCreationWizzardAutomation;

namespace JobCreationWizzardTests
{
    [TestClass]
    public class NewJobTests : JobCreationWizzardTest
    {
        [TestMethod]
        public void Proceed_Job_Basic_No_Input()
        {
            NewJobPage.Job("").JobDescription("").Next();

            Assert.AreEqual(NewJobPage.Validation_Message_One_First_Iteration, "You can't leave this empty", "No message displayed.");
            Assert.AreEqual(NewJobPage.Validation_Message_Two_First_Iteration, "You can't leave this empty", "No message displayed.");
        }

        [TestMethod]
        public void Proceed_Job_Basic_No_Job_Description()
        {
            NewJobPage.Job("QA Engineer Test Job").JobDescription("").Next();

            Assert.AreEqual(NewJobPage.Validation_Message_Second_Iteration, "You can't leave this empty", "No message displayed.");
        }

        [TestMethod]
        public void Proceed_Job_Basic_No_Job_Title()
        {
            NewJobPage.Job("").JobDescription("QA Engineer Test Job").Next();

            Assert.AreEqual(NewJobPage.Validation_Message_Second_Iteration, "You can't leave this empty", "No message displayed.");
        }

        [TestMethod]
        public void Proceed_Job_Basic_Populate_All()
        {
            NewJobPage.Job("QA Engineer Test Job").JobDescription("This is descriptions for QA Engineer Test Job").Next();

            Assert.AreEqual(NewJobPage.Note_Text, "Please provide the details you require for your Developer job.", "No match");
        }

       
    }
}
