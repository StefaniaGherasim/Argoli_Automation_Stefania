using Argoli_Automation_Stefania.PageModels;
using Argoli_Automation_Stefania.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Argoli_Automation_Stefania.Tests.RecoveryPassword
{
    public class RecoveryPasswordTest : BaseTest
    {
        string url = FrameworkConstants.GetUrl() + "/recovery";

        [Test]
        public void RecoverPasswordWithoutData()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
           


        }
    }
}
