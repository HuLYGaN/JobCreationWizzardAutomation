using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobCreationWizzardAutomation;

namespace JobCreationWizzardTests
{
    [TestClass]
    public class HomePageTests : JobCreationWizzardTest
    {

        [TestMethod]
        public void User_Is_At_Login_Page()
        {
            Assert.IsTrue(LoginPage.IsAt, "Login page not displayed");
        }
    }
}