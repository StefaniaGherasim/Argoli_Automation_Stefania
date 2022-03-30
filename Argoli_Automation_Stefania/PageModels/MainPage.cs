using Argoli_Automation_Stefania.PageModels;
using Argoli_Automation_Stefania.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Argoli_Automation_Stefania.PageModels
{
    class MainPage : BasePage

        
    {
        const string contulMeuSelector = "//*[@id='navbar-navigation']/ul[2]/li[3]/a"; // xpath (togle ????)
        const string checkPageSelector = "#loginForm > div.form-group.text-center.text-muted.content-divider";//css

        public MainPage(IWebDriver driver) : base(driver)//constructior pentru MainPage driver
        {

        }

        public void MoveToLoginPage()
        {
           
            driver.FindElement(By.XPath(contulMeuSelector)).Click();
            var select = Utils.WaitForElementClickable(driver, 10, (By.CssSelector(checkPageSelector)));
            select.Click();
        }
    }
}
