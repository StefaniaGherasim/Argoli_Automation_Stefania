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
        const string nameLabel = "#signForm > div:nth-child(2) > label";//css
        const string nameInput = "nume";//id
        const string prenumeLabel = "#signForm > div:nth-child(3) > label";//css
        const string prenumeInput = "prenume";//id
        const string emailLabel = "#signForm > div:nth-child(4) > label";//css
        const string emailInput = "email";//id
        const string telLabel = "#signForm > div:nth-child(5) > label";//css
        const string telInput = "telefon";//id
        const string parolaLabel = "#signForm > div:nth-child(6) > label";//css
        const string parolaInput = "password";//id
        const string confirmaparolaLable = "#signForm > div:nth-child(7) > label";//css
        const string confirmaparolaInput = "confirmPassword";//id
        const string inregistrareButton = "#signForm > div.text-right > button";//css
        const string errmessagenullinregLabel = "#msjEroare > div > span";//css
        const string closeerrmessageButton = "#msjEroare > div > button";//css


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
            return driver.FindElement(By.CssSelector(nameLabel)).Text;
        }

        public string CheckprenumeLabel()
        {
            return driver.FindElement(By.CssSelector(prenumeLabel)).Text;
        }

        public string CheckemailLabel()
        {
            return driver.FindElement(By.CssSelector(emailLabel)).Text;
        }
        public string ChecktelLabel()
        {
            return driver.FindElement(By.CssSelector(telLabel)).Text;
        }
        public string CheckparolaLabel()
        {
            return driver.FindElement(By.CssSelector(parolaLabel)).Text;
        }
        public string CheckconfirmaparolaLable()
        {
            return driver.FindElement(By.CssSelector(confirmaparolaLable)).Text;
        }

        public string CheckerrmessagenullinregLabel()
        {
            return driver.FindElement(By.CssSelector(errmessagenullinregLabel)).Text;
        }

        public void PushInregistrare()
        {
            var inregistrareButtonErr = driver.FindElement(By.CssSelector(inregistrareButton));
            inregistrareButtonErr.Click();
        }

        public void CloseErr() 
        {
            var closeerrmessageButtonErr = driver.FindElement(By.CssSelector(closeerrmessageButton));
            closeerrmessageButtonErr.Click();
        }

    }
}
