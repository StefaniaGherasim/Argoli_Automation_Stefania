using Argoli_Automation_Stefania.PageModels;
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

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv1()
        {
            foreach (var values in Utils.GetGenericData("TestData\\RegistrationData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test,TestCaseSource("GetCredentialsDataCsv1")] //inregistrare pozitiva cu date din CSV
        public void RegisterTest(string nume, string prenume, string email, string telefon, string parola)// (modifica csv -creaza cont nou)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.MoveToLoginPage();
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
            rp.RegisterUser(nume, prenume, email, telefon, parola);

        }

        [Test]
        public void RegisterTestWithRandomData() //inregistrare pozitiva cu date Random generate cu ajutorul functiei din Utils  
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.MoveToLoginPage();
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
            rp.RegisterUser(Utils.GenerateRandomStringCount(10), Utils.GenerateRandomStringCount(12), Utils.GenerateRandomStringCount(8) + "@email.test", "telefon", Utils.GenerateRandomStringCount(6));
        }

        [Test]
        public void RegisterTestWithoutData()//inregistrare fara date - verificare mesaj eroare
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.MoveToLoginPage();
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
            //Thread.Sleep(100);
            Assert.AreEqual("Parola trebuie sa conțină între 6-20 de caractere", rp.CheckerrmessagenullinregLabel());
            rp.CloseErr();
        }

        private static IEnumerable<TestCaseData> GetCredentialsDataCsvAlreadyExist()
        {
            foreach (var values in Utils.GetGenericData("TestData\\AlreadyExistRegisterData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test, TestCaseSource("GetCredentialsDataCsvAlreadyExist")]
        public void RegisterTestWithOlreadyRegisteredUser(string nume, string prenume, string email, string telefon, string parola) // inregistrare cu datele unui user deja existent - verificare mesaj eroare
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.MoveToLoginPage();
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

            
            rp.RegisterUser(nume, prenume, email, telefon, parola);
            rp.PushInregistrare();
            Assert.AreEqual("Adresa de mail este deja înregistrată", rp.ErrmessagealreadyexistuserLabel());
            rp.CloseErr2();
            rp.PushBackToLoginPage();
            Assert.AreEqual("Nu ai încă cont?", lp.CheckPage());//verifica ca suntem pe pagina de login
        }



    }
}
