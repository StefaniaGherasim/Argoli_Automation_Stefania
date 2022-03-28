using Argoli_Automation_Stefania.Utilities;
using NUnit.Framework;
using Argoli_Automation_Stefania.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Argoli_Automation_Stefania.Tests.Authentication
{
    public class AuthenticationTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test]
        public void AuthenticationPositive()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
        }

    }
}
