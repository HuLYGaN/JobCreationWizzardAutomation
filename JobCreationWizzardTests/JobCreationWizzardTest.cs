using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobCreationWizzardAutomation;

namespace JobCreationWizzardTests
{
    public class JobCreationWizzardTest
    {
 
            [TestInitialize]
            public void Init()
            {
                Driver.Initialize();
                HomePage.GoTo();
                LoginPage.LoginAs("slava.connectpal.com@toptal.io").WithPassword("password").Login();
                DahsboardPage.Add_New_Job();
            }

            [TestCleanup]
            public void Cleanup()
            {
                Driver.Close();
            }
        }
    }

