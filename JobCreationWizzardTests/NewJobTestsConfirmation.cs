using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobCreationWizzardAutomation;

namespace JobCreationWizzardTests
{
    [TestClass]
    public class NewJobTestsConfirmation : NewJobTestsSkills
    {
        [TestMethod]
        public void ScheduleACall()
        {
            Proceed_To_Confirmation();
            NewJobPageConfirm.Next();

            Assert.AreEqual(NewJobPageConfirm.ConfirmationOne, "You need to confirm this", "Error");
            Assert.AreEqual(NewJobPageConfirm.ConfirmationTwo, "You need to confirm this", "Error");
            Assert.AreEqual(NewJobPageConfirm.ConfirmationThree, "You need to confirm this", "Error");

            NewJobPageConfirm.Review(true).Do();
            NewJobPageConfirm.Next();
        }

        [TestMethod]
        public void Schedule_With_One_Confirmation()
        {
            Proceed_To_Confirmation();
            NewJobPageConfirm.Review(true).Do();
            NewJobPageConfirm.Next();

            Assert.AreEqual(NewJobPageConfirm.ConfirmationThree, "You need to confirm this", "Error");
            Assert.AreEqual(NewJobPageConfirm.ConfirmationOne, "You need to confirm this", "Error");
        }

        [TestMethod]
        public void Schedule_With_All_Confirmation()
        {
            Proceed_To_Confirmation();
            NewJobPageConfirm.Review(true).Days(true).Deposit(true).Do();
            NewJobPageConfirm.Next();

            Assert.AreEqual(NewJobPageTechCall.IsAt, "The next step is to schedule a tech call with Mario Mucalo, Director of Engineering. This will take 10-20 minutes, and here we will work with you to understand your definition of the perfect candidate.", "Error");
        }              
    }
}
