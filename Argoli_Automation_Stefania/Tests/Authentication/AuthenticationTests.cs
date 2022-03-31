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

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv3()
        {
            foreach (var values in Utils.GetGenericData("TestData\\Authenticationdatan.csv"))
            {
                yield return new TestCaseData(values);
            }
        }


        [Test, Order(1), TestCaseSource("GetCredentialsDataCsv3")]
        public void AuthenticationNegativ(string email, string password)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.MoveToLoginPage();

            LoginPage lp = new LoginPage(_driver);


            Assert.AreEqual("Nu ai încă cont?", lp.CheckPage());
            Assert.AreEqual("By continuing, you're confirming that you've read our Terms & Conditions and Cookie Policy", lp.CheckPage2());

            lp.Login(email, password);
            Assert.AreEqual("email sau parolă incorectă", lp.CheckErrorMessage());

        }


        private static IEnumerable<TestCaseData> GetCredentialsDataCsv2()
        {
            foreach (var values in Utils.GetGenericData("TestData\\AuthenticationData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test, Order(10),TestCaseSource("GetCredentialsDataCsv2")]
        public void AuthenticationPositive(string email, string password)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.MoveToLoginPage();

            LoginPage lp = new LoginPage(_driver);
        }
        

        [Test, Order (2)]
        public void ForgotPassword()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.MoveToLoginPage();

            LoginPage lp = new LoginPage(_driver);
            lp.PushForgotPassword();
            //Thread.Sleep(100);// ruleaza prea repede --pentru a vedea functionalitatea butonului si pentru a vedea noua pagina deschisa

        }



    }
}
