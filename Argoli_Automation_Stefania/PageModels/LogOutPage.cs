using Argoli_Automation_Stefania.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Argoli_Automation_Stefania.PageModels
{
    public class LogOutPage : BasePage
    {

        const string nameAccountSelector = "#navbar-navigation > ul.nav.navbar-nav.ml-xl-auto > li.nav-item.dropdown.dropdown-user > a > span";//css  
        const string logOutSelector = "#navbar-navigation > ul.nav.navbar-nav.ml-xl-auto > li.nav-item.dropdown.dropdown-user.show > div > a:nth-child(4)";//css
        const string myAccountSeletor = "#navbar-navigation > ul.nav.navbar-nav.ml-xl-auto > li:nth-child(3) > a";//css


        public LogOutPage(IWebDriver driver) : base(driver)
        {

        }

        public string NameAccountLabel()
        {

            return driver.FindElement(By.CssSelector(nameAccountSelector)).Text;

        }

        public void EnterNameAccount()
        {
            driver.FindElement(By.CssSelector(nameAccountSelector)).Click();

        }

        public string LogOutLabel()
        {

            return driver.FindElement(By.CssSelector(logOutSelector)).Text;

        }
        public string MyAccountLabel()
        {

            return driver.FindElement(By.CssSelector(myAccountSeletor)).Text;

        }

        public void LogOutUserAccount()
        {
            driver.FindElement(By.CssSelector(logOutSelector)).Click();
            var select = Utils.WaitForElementClickable(driver, 1000, (By.CssSelector(myAccountSeletor)));
            select.Click();
        }


    }
}
