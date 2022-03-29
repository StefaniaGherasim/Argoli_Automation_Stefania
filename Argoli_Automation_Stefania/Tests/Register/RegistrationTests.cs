﻿using Argoli_Automation_Stefania.PageModels;
using Argoli_Automation_Stefania.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Argoli_Automation_Stefania.Tests.Register
{
    class RegistrationTests :BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test]
        public void RegisterTest()
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.MoveToLoginPage();
            Thread.Sleep(1000);
            LoginPage lp = new LoginPage(_driver);
            lp.MoveToCreareCont();

            RegistrationPage rp = new RegistrationPage(_driver);
            Assert.AreEqual("Creează cont", rp.CreazaContLabel());
            Assert.AreEqual("completează datele contului", rp.CompleteazaLabel());
            Assert.AreEqual("Name:", rp.CheckNameLabel());
            Assert.AreEqual("Prenume:", rp.CheckprenumeLabel());
            Assert.AreEqual("Email:", rp.CheckemailLabel());
            Assert.AreEqual("Telefon:", rp.ChecktelLabel());
            Assert.AreEqual("Parola:", rp.CheckparolaLabel());
            Assert.AreEqual("Confirmă parola:", rp.CheckconfirmaparolaLable());

            rp.PushInregistrare();
            Thread.Sleep(1000);
            Assert.AreEqual("Parola trebuie sa conțină între 6-20 de caractere", rp.CheckerrmessagenullinregLabel());
            rp.CloseErr();
        }
    }
}
