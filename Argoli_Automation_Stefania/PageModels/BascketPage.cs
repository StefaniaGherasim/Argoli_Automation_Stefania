using Argoli_Automation_Stefania.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Argoli_Automation_Stefania.PageModels
{
    public class BascketPage : BasePage
    {
        const string DeletButtonSelector = "#card-produs-63 > div > div > button";//css
        const string TotalCostSelector = "#costTotal";//css

        public BascketPage(IWebDriver driver) : base(driver)
        {

        }

        public void DeletProduct()
        {
            driver.FindElement(By.CssSelector(DeletButtonSelector)).Click();
            

        }

        public string TotalCost()
        {
            return driver.FindElement(By.CssSelector(TotalCostSelector)).Text;
        }


    }
}
