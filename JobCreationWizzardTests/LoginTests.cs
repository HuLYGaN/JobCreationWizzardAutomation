using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobCreationWizzardAutomation;

namespace JobCreationWizzardTests
{
    [TestClass]
    public class LoginTests : JobCreationWizzardTest
    {

        [TestMethod]
        public void User_Can_Login()
        {
            Assert.IsTrue(DahsboardPage.IsAt, "Failed to login."); 
        }
    }
}

