using Argoli_Automation_Stefania.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Argoli_Automation_Stefania.PageModels
{
    public class RecoveryPasswordPage : BasePage
    {

        const string emailLabelSelector = "body > div.recovery > div > div.col-md-4 > div.form-group.mb-0 > label";//css
        const string emailInputSelector = "emailRecovery";//id
        const string errMessageLabelSelector = "#messageArea > h5";//css
        const string errMsg2LabelSelector = "#messageArea > h5:nth-child(1)";//css
        const string trimiteButtonSelector = "body > div.recovery > div > div.col-md-4 > button";//css
        const string mesajSuccesLabelSelector = "#messageArea > h5:nth-child(1)";//css

        public RecoveryPasswordPage(IWebDriver driver) : base(driver)
        {
        }

        public string CheckEmailLabel()
        {
            return driver.FindElement(By.CssSelector(emailLabelSelector)).Text;
        }

        public string EmailInputLabel()
        {
            return driver.FindElement(By.Id(emailInputSelector)).Text;
        }

        public string ErrMsgLabel()
        {
            return driver.FindElement(By.CssSelector(errMessageLabelSelector)).Text;
        }

        public string ErrMsg2Label()
        {
            return driver.FindElement(By.CssSelector(errMsg2LabelSelector)).Text;
        }

        public string SuccesMessageLabel()
        {
            return driver.FindElement(By.CssSelector(mesajSuccesLabelSelector)).Text;
        }

        public void TrimiteButton()
        {
            var trimiteButton = driver.FindElement(By.CssSelector(trimiteButtonSelector));
            trimiteButton.Click();
            var select = Utils.WaitForElementClickable(driver, 10, (By.CssSelector(errMsg2LabelSelector)));
            select.Click();
        }

        public void EmailRecoveryPassword(string email)
        {
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
        }
    }
}
