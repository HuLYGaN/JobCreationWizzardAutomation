using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobCreationWizzardAutomation;


namespace JobCreationWizzardTests
{
    [TestClass]
    public class DashboardTests : JobCreationWizzardTest
    {

        [TestMethod]
        public void User_Can_Click_Add_New_Job()
        {          
            Assert.AreEqual(NewJobPage.Panel_Text, "Follow these steps to add a new job", "No match");
        }
    }
}