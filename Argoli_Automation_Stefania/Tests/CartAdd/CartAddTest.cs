using Argoli_Automation_Stefania.PageModels;
using Argoli_Automation_Stefania.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Argoli_Automation_Stefania.Tests.CartAdd
{
    class CartAddTest : BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv2()
        {
            foreach (var values in Utils.GetGenericData("TestData\\AuthenticationData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test, Order(11), TestCaseSource("GetCredentialsDataCsv2")]
        public void AddToCard(string email, string password)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.MoveToLoginPage();

            LoginPage lp = new LoginPage(_driver);
            lp.Login2(email, password);

            CartAddPage cp = new CartAddPage(_driver);
            Assert.AreEqual("Produse recent adăugate", cp.CheckProduseAdaugateLabel());
            //cp.CheckProduseAdaugateLabel("Produse recent adăugate");//(inlocuim cu assert)
            // Assert.IsTrue(cp.CheckProduseAdaugateLabel("Produse recent adăugate"));
            cp.AdaugaInCos();
            Thread.Sleep(5000);//doar pentru a verifica adaugarea produsului in cos

        }

    }
}
