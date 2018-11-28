using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace WordpressTests.Extensions
{
    public static class SeleniumExtension
    {
        public static void Maximize(this IWebDriver driver)
        {
            driver.Manage().Window.Size=new Size(1920,1080);
        }

        public static void ClickOnElement(this IWebDriver driver, By by)
        {
            driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", driver.FindElement(by));
            driver.WaitForClickable(by);
            driver.FindElement(by).Click();
        }

        public static bool ReturnDisplayStatusBySelector(this IWebDriver driver,By by)
        {
            try
            {
                driver.Wait(TypeOfWait.TenSeconds).Until(x => driver.FindElement(by).Displayed);
                return driver.FindElement(by).Displayed;
            }
            catch (TimeoutException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
       
        }
    }
}
