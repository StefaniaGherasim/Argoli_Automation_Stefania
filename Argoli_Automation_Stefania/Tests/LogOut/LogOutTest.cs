using Argoli_Automation_Stefania.PageModels;
using Argoli_Automation_Stefania.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Argoli_Automation_Stefania.Tests.LogOut
{
    public class LogOutTest : BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv2()
        {
            foreach (var values in Utils.GetGenericData("TestData\\AuthenticationData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test, Order(13), TestCaseSource("GetCredentialsDataCsv2")]
        public void LogOutUserTest(string email, string password)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.MoveToLoginPage();

            LoginPage lp = new LoginPage(_driver);
            lp.Login2(email, password);

            LogOutPage lo = new LogOutPage(_driver);
            Assert.AreEqual("Aron Gherasim", lo.NameAccountLabel());
            lo.EnterNameAccount();
            Assert.AreEqual("Deconectare", lo.LogOutLabel());
            lo.LogOutUserAccount();
            Thread.Sleep(1000);
            Assert.AreEqual("Contul meu", lo.MyAccountLabel());
        }
    }
}
