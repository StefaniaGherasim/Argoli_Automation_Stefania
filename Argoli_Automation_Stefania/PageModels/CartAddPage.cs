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

        public CartAddPage(IWebDriver driver) : base(driver)
        {

        }

        public string CheckProduseAdaugateLabel()
        {

            return driver.FindElement(By.CssSelector(produseRecentAddSelector)).Text;
         
        }
        /* public Boolean CheckProduseAdaugateLabel(string label) //- nu imi gaseste selectorul
          {
             return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(produseRecentAddSelector)).Text.ToLower());
          }
         */

        public void AdaugaInCos ()
        {
            driver.FindElement(By.CssSelector(adaugaInCosButtonSelector)).Click();

        }




    }
}
