using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace WordpressTests.TestSettings
{
    public class WebDriverFactory
    {
        public RemoteWebDriver ReturnWebDriver(Browsers browsers)
        {
            switch (browsers)
            {
                case Browsers.FirefoxLocal:
                    return new FirefoxDriver();
                case Browsers.FirefoxRemote:
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddAdditionalCapability("enableVNC", true, true);
                    firefoxOptions.AddAdditionalCapability("enableVideo", true, true);
                    //Place where you put url address to Selenoid
                    return new RemoteWebDriver(new Uri("http://addressToYourSelenoid:4444/wd/hub"), firefoxOptions);
                case Browsers.ChromeLocal:
                    return new ChromeDriver();
                case Browsers.ChromeRemote:
                    var options = new ChromeOptions();
                    options.BrowserVersion = "69.0";
                    options.AddAdditionalCapability("enableVNC",true,true);
                    options.AddAdditionalCapability("enableVideo",true,true);
                    //Place where you put url address to Selenoid
                    return new RemoteWebDriver(new Uri("http://addressToYourSelenoid:4444/wd/hub"), options);
                default:
                    throw new ArgumentOutOfRangeException(nameof(browsers), browsers, null);
            }
        }
    }
}