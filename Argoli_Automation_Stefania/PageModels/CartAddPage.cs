using Argoli_Automation_Stefania.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Argoli_Automation_Stefania.PageModels
{
    public class CartAddPage : BasePage
    {
        const string adaugaInCosButtonSelector = "#UNT > div > button";// css

        const string produseRecentAddSelector = "body > div:nth-child(6) > div > div > span";//css    

        const string bascketSelector = "#navbar-navigation > ul.nav.navbar-nav.ml-xl-auto > li:nth-child(4) > a > i";//css

        const string checkBascketPageSelector = "#produse > div > div.col-md-8 > div.card > div.card-header > h2";//css

        public CartAddPage(IWebDriver driver) : base(driver)
        {

        }

        public string CheckProduseAdaugateLabel()
        {

            return driver.FindElement(By.CssSelector(produseRecentAddSelector)).Text;
         
        }

        public string CheckBascketPageLabel()
        {
            return driver.FindElement(By.CssSelector(checkBascketPageSelector)).Text;
        }

        /* public Boolean CheckProduseAdaugateLabel(string label) //- nu imi gaseste selectorul
          {
             return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(produseRecentAddSelector)).Text.ToLower());
          }
         */

        public void AdaugaInCos ()
        {
            driver.FindElement(By.CssSelector(adaugaInCosButtonSelector)).Click();
            var select = Utils.WaitForElementClickable(driver, 1000, (By.CssSelector(produseRecentAddSelector)));
            select.Click();
        }

        public void MoveToBascket()
        {
            driver.FindElement(By.CssSelector(bascketSelector)).Click();
            var select = Utils.WaitForElementClickable(driver, 1000, (By.CssSelector(checkBascketPageSelector)));
            select.Click();
        }




    }
}
