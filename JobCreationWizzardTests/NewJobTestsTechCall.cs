using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobCreationWizzardAutomation;

namespace JobCreationWizzardTests
{
    [TestClass]
    public class NewJobTestsTechCall : NewJobTestsConfirmation
    {
        [TestMethod]
        public void Jump_to_Job()
        {
            Schedule_With_All_Confirmation();
            NewJobPageTechCall.Jump();
            Assert.AreEqual(Jobs.IsAt, "Pending claim", "Error");
        }
    }
}
