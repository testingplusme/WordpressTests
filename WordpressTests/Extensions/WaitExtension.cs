using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace WordpressTests.Extensions
{
    public static class WaitExtension
    {
        public static WebDriverWait Wait(this IWebDriver driver,TypeOfWait type)
        {
            TimeSpan timeSpan;
            switch (type)
            {
                case TypeOfWait.TenSeconds:
                    timeSpan=TimeSpan.FromSeconds(10);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return new WebDriverWait(driver, timeSpan);
        }

        public static void WaitForClickable(this IWebDriver driver, By by, TypeOfWait type = TypeOfWait.TenSeconds)
        {
            driver.Wait(type).Until(x => x.FindElement(by).Displayed);
        }
    }
}
