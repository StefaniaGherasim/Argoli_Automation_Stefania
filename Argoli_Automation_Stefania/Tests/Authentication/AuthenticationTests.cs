using Argoli_Automation_Stefania.Utilities;
using NUnit.Framework;
using Argoli_Automation_Stefania.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using Argoli_Automation_Stefania.PageModels;
using System.Threading;

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
            MainPage mp = new MainPage(_driver);
            mp.MoveToLoginPage();
            Thread.Sleep(1000);//waith?

            LoginPage lp = new LoginPage(_driver);
            Assert.AreEqual("Nu ai încă cont?", lp.CheckPage());
            Assert.AreEqual("By continuing, you're confirming that you've read our Terms & Conditions and Cookie Policy", lp.CheckPage2());
           
            lp.Login("sss@ddd.com", "pass");
            Thread.Sleep(1000);
            Assert.AreEqual("email sau parolă incorectă", lp.CheckErrorMessage());
        }



    }
}
