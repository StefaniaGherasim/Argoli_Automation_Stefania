using Argoli_Automation_Stefania.PageModels;
using Argoli_Automation_Stefania.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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

            RecoveryPasswordPage rpp = new RecoveryPasswordPage(_driver);
            Assert.AreEqual("Email", rpp.CheckEmailLabel());
            rpp.TrimiteButton();
            Assert.AreEqual("Email-ul nu poate fi gol.", rpp.ErrMsgLabel());

        }

        private static IEnumerable<TestCaseData> GetCredentialsDataCsvWrongEmail()
        {
            foreach (var values in Utils.GetGenericData("TestData\\WrongEmail.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test, TestCaseSource("GetCredentialsDataCsvWrongEmail")]
        public void RecoverPasswordWIthWrongData(string email)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);

            RecoveryPasswordPage rpp = new RecoveryPasswordPage(_driver); 
            Assert.AreEqual("Email", rpp.CheckEmailLabel());
            rpp.EmailRecoveryPassword(email);
            rpp.TrimiteButton();
            Assert.AreEqual("Email-ul nu a fost gasit. Va rugam sa mai incercati", rpp.ErrMsg2Label());
        }

        private static IEnumerable<TestCaseData> GetCredentialsDataCsvEmail()
        {
            foreach (var values in Utils.GetGenericData("TestData\\EmailData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }


        [Test, TestCaseSource("GetCredentialsDataCsvEmail")]
        public void RecoverPasswordEmail(string email)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);

            RecoveryPasswordPage rpp = new RecoveryPasswordPage(_driver);
            Assert.AreEqual("Email", rpp.CheckEmailLabel());
            rpp.EmailRecoveryPassword(email);
            rpp.TrimiteButton();
            Assert.AreEqual("A fost trimis un email către adresa aarongherasim@gmail.com Acesați link-ul din email pentru a reseta parola.", rpp.SuccesMessageLabel());
        }

    }
}
