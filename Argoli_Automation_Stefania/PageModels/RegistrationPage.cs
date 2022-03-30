using Argoli_Automation_Stefania.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Argoli_Automation_Stefania.PageModels
{
    public class RegistrationPage : BasePage
    {
        const string creazaContLabelSelector = "#signForm > div.text-left.mb-3 > h5";//css
        const string completeazadateleLabelSelector = "#signForm > div.text-left.mb-3 > span";//css
        const string nameLabelSelector = "#signForm > div:nth-child(2) > label";//css
        const string nameInputSelector = "nume";//id
        const string prenumeLabelSelector = "#signForm > div:nth-child(3) > label";//css
        const string prenumeInputSelector = "prenume";//id
        const string emailLabelSelector = "#signForm > div:nth-child(4) > label";//css
        const string emailInputSelector = "email";//id
        const string telLabelSelector = "#signForm > div:nth-child(5) > label";//css
        const string telInputSelector = "telefon";//id
        const string parolaLabelSelector = "#signForm > div:nth-child(6) > label";//css
        const string parolaInputSelector = "password";//id
        const string confirmaparolaLableSelector = "#signForm > div:nth-child(7) > label";//css
        const string confirmaparolaInputSelector = "confirmPassword";//id
        const string inregistrareButtonSelector = "#signForm > div.text-right > button";//css
        const string errmessagenullinregLabelSelector = "#msjEroare > div > span";//css
        const string closeerrmessageButtonSelector = "#msjEroare > div > button";//css


        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public string CreazaContLabel()
        {
            return driver.FindElement(By.CssSelector(creazaContLabelSelector)).Text;
        }

        public string CompleteazaLabel()
        {
            return driver.FindElement(By.CssSelector(completeazadateleLabelSelector)).Text;
        }

        public string CheckNameLabel()
        {
            return driver.FindElement(By.CssSelector(nameLabelSelector)).Text;
        }

        public string CheckprenumeLabel()
        {
            return driver.FindElement(By.CssSelector(prenumeLabelSelector)).Text;
        }

        public string CheckemailLabel()
        {
            return driver.FindElement(By.CssSelector(emailLabelSelector)).Text;
        }
        public string ChecktelLabel()
        {
            return driver.FindElement(By.CssSelector(telLabelSelector)).Text;
        }
        public string CheckparolaLabel()
        {
            return driver.FindElement(By.CssSelector(parolaLabelSelector)).Text;
        }
        public string CheckconfirmaparolaLable()
        {
            return driver.FindElement(By.CssSelector(confirmaparolaLableSelector)).Text;
        }

        public string CheckerrmessagenullinregLabel()
        {
            return driver.FindElement(By.CssSelector(errmessagenullinregLabelSelector)).Text;
        }

        public void PushInregistrare()
        {
            var inregistrareButtonErr = driver.FindElement(By.CssSelector(inregistrareButtonSelector));
            inregistrareButtonErr.Click();
            var select = Utils.WaitForElementClickable(driver, 10, (By.CssSelector(errmessagenullinregLabelSelector)));
            select.Click();
        }

        public void CloseErr()
        {
            var closeerrmessageButtonErr = driver.FindElement(By.CssSelector(closeerrmessageButtonSelector));
            closeerrmessageButtonErr.Click();
        }

        public void RegisterUser (string Nume, string Prenume, string Email, string Telefon, string Parola)
        {
            var nameInput = driver.FindElement(By.Id(nameInputSelector));
            nameInput.Clear();
            nameInput.SendKeys(Nume);

            var prenumeInput = driver.FindElement(By.Id(prenumeInputSelector));
            prenumeInput.Clear();
            prenumeInput.SendKeys(Prenume);

            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            emailInput.Clear();
            emailInput.SendKeys(Email);

            var telefonInput = driver.FindElement(By.Id(telInputSelector));
            telefonInput.Clear();
            telefonInput.SendKeys(Telefon);

            var parolaInput = driver.FindElement(By.Id(parolaInputSelector));
            parolaInput.Clear();
            parolaInput.SendKeys(Parola);

            var confirmaparolaInput = driver.FindElement(By.Id(confirmaparolaInputSelector));
            confirmaparolaInput.Clear();
            confirmaparolaInput.SendKeys(Parola);

            var inregistrareButton = driver.FindElement(By.CssSelector(inregistrareButtonSelector));
            inregistrareButton.Click();


        }
    }
}
