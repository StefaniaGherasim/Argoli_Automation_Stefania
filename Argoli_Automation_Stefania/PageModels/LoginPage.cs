using Argoli_Automation_Stefania.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Argoli_Automation_Stefania.PageModels
{
    public class LoginPage : BasePage
    {
        
        const string emailSelector = "loginEmail"; //id
        const string passwordSelector = "loginPassword"; // id
        const string loginButtonSelector = "#formLogin > div:nth-child(5) > input";//css
        const string forgotPasswordSelector = "#loginForm > a";//css
        const string checkPageSelector = "#loginForm > div.form-group.text-center.text-muted.content-divider";//css
        const string creazaContSelector = "#loginForm > div:nth-child(4) > button";//css
        const string checkPageSelector2 = "//*[@id='loginForm']/span";//xpath
        const string termenisiconditiiSelector = "//*[@id='loginForm']/span/a[1]";//xpath
        const string CookiePolicySelector = "//*[@id='loginForm']/span/a[2]";//xpath
        const string errorIdmsgSelector = "msg";//id
        const string produseRecentAddSelector = "body > div:nth-child(6) > div > div > span";//css




        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public void PushForgotPassword()
        {
            var forgotPasswordButton = driver.FindElement(By.CssSelector(forgotPasswordSelector));
            forgotPasswordButton.Click();
        }

        public string CheckPage()//verificam daca suntem pe pagina
        {
            return driver.FindElement(By.CssSelector(checkPageSelector)).Text;
           //return String.Equals(label.ToLower(), driver.FindElement(By.XPath(checkPageSelector)).Text.ToLower());
        }

        public string CheckPage2()//verificam daca suntem pe pagina
        {
            return driver.FindElement(By.XPath(checkPageSelector2)).Text;
        }

        public string CheckErrorMessage()
        {
            return driver.FindElement(By.Id(errorIdmsgSelector)).Text;
        }

        public string CheckProduseAdaugateLabel()
        {

            return driver.FindElement(By.CssSelector(produseRecentAddSelector)).Text;

        }
        public void Login(string email, string password)
        {
            var emailInput = driver.FindElement(By.Id(emailSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var passwordInput = driver.FindElement(By.Id(passwordSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            var loginButton = driver.FindElement(By.CssSelector(loginButtonSelector));
            loginButton.Submit();
            var select = Utils.WaitForElementClickable(driver, 10, (By.Id(errorIdmsgSelector)));
            select.Click();

        }

        public void Login2(string email, string password)
        {
            var emailInput = driver.FindElement(By.Id(emailSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var passwordInput = driver.FindElement(By.Id(passwordSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            var loginButton = driver.FindElement(By.CssSelector(loginButtonSelector));
            loginButton.Submit();
            var select = Utils.WaitForElementClickable(driver, 1000, (By.CssSelector(produseRecentAddSelector)));
            select.Click();
        }

        public void MoveToCreareCont()
        {
            driver.FindElement(By.CssSelector(creazaContSelector)).Click();
        }


    }
}
