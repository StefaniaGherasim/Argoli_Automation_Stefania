using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Argoli_Automation_Stefania.Utilities
{
    public class Browser // methoda statica  Browser static   -ocupa mai putin memorie, e accesat mai repede, va fi shared ca info intre toate testele, 
    {

        public static IWebDriver GetDriver(WebBrowsers browserType)//ca sa nu instantiem de fiecaredata un obiect browser, browserul sa fie static
        {
            switch (browserType)
            {
                //instantiaza Chrome driver 
                case WebBrowsers.Chrome:
                    {
                        var options = new ChromeOptions();
                        //optiuni entru driver in functie de FrameworkConstants
                        if (FrameworkConstants.startMaximized)
                        {
                            options.AddArgument("--start-maximized"); //va porni browserul direct maximizat
                        }
                        if (FrameworkConstants.startHeadless)
                        {
                            options.AddArgument("headless");//browserul va pornii headless
                        }
                        if (FrameworkConstants.ignoreCertErr)
                        {
                            options.AddArgument("ignore-certificate-errors");
                        }
                        //proxy def.
                        var proxy = new Proxy
                        {
                            HttpProxy = FrameworkConstants.browserProxy,
                            IsAutoDetect = false
                        };
                        if (FrameworkConstants.useProxy)
                        {
                            options.Proxy = proxy;
                        }
                        //initialiate Chrome driver with options
                        return new ChromeDriver(options);
                    }
                //instantiaza Firefox driver 
                case WebBrowsers.Firefox:
                    {
                        //definire optiuni firefox bazate pe FrameworkConstants
                        var firefoxOptions = new FirefoxOptions();
                        List<string> optionList = new List<string>();


                        if (FrameworkConstants.startHeadless)
                        {
                            optionList.Add("--headless");
                        }
                        if (FrameworkConstants.ignoreCertErr)
                        {
                            optionList.Add("--ignore-certificate-errors");
                        }
                        firefoxOptions.AddArguments(optionList);
                        FirefoxProfile fProfile = new FirefoxProfile();
                        if (FrameworkConstants.startWithExtension)
                        {
                            fProfile.AddExtension(FrameworkConstants.GetExtensionName(browserType));

                        }
                        firefoxOptions.Profile = fProfile;
                        return new FirefoxDriver(firefoxOptions);
                    }
                //instantiaza Edge driver 
                case WebBrowsers.Edge:
                    {
                        var edgeOptions = new EdgeOptions();
                        if (FrameworkConstants.startMaximized)
                        {
                            edgeOptions.AddArguments("['--start-maximized']");
                        }
                        if (FrameworkConstants.startHeadless)
                        {
                            edgeOptions.AddArguments("headless");
                        }
                        if (FrameworkConstants.startWithExtension)
                        {
                            edgeOptions.AddExtension(FrameworkConstants.GetExtensionName(browserType));
                        }
                        return new EdgeDriver(edgeOptions);
                    }
                default:
                    {//driverul specificat nu este implementat (diferit de cele secificate mai sus)
                        throw new BrowserTypeException(browserType.ToString());
                    }

            }
        }
   

    // This method will provide a driver, based on the config file browser attribute
    public static IWebDriver GetDriver()
    {
        WebBrowsers cfgBrowser;
        switch (FrameworkConstants.configBrowser.ToUpper())
        {
            case "FIREFOX":
                {
                    cfgBrowser = WebBrowsers.Firefox;
                    break;
                }
            case "CHROME":
                {
                    cfgBrowser = WebBrowsers.Chrome;
                    break;
                }
            case "EDGE":
                {
                    cfgBrowser = WebBrowsers.Edge;
                    break;
                }
            default:
                {
                    throw new BrowserTypeException(String.Format("Browser {0} not supported", FrameworkConstants.configBrowser));
                }
        }

        return GetDriver(cfgBrowser);
    }
}



public enum WebBrowsers //lista de valori -- se poate face si intr'un fisier separat 
    {
        Chrome,
        Firefox,
        Edge
    }

}
