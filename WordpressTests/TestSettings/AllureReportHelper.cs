using System;
using System.IO;
using System.Linq;
using System.Text;
using Allure.Commons;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WordpressTests.Extensions;

namespace WordpressTests.TestSettings
{
    public class AllureReportHelper
    {
        private ScenarioContext scenarioContext;
        private IObjectContainer container;
        public IWebDriver Driver => container.Resolve<IWebDriver>();

        public AllureReportHelper(IObjectContainer container, ScenarioContext scenarioContext)
        {
            this.container = container;
            this.scenarioContext = scenarioContext;
        }

        private string CleanFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }
       
        public void SaveScreenshot(string title, string step)
        {
            try
            {
                var path = $"{TestConfiguration.DirectoryPath}\\{title}{DateTime.Now:HH}";
                Directory.CreateDirectory(path);
                var pathToFile = $"{path}\\{CleanFileName(DateTime.UtcNow.ToLongTimeString())}.png";
                if (scenarioContext.TestError != null)
                {
                    var errorPath = $"{path}\\errors\\";
                    Directory.CreateDirectory(errorPath);
                    pathToFile = $"{errorPath}{CleanFileName(DateTime.UtcNow.ToLongTimeString())}.png";
                }
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(pathToFile, ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment(pathToFile, step);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Taking a screenshot failed" + ex.Message);
            }        
        }

        public void AddVideoToScenario(string title, string sessionId)
        {
            if (sessionId == null) return;
            var bytes = Encoding.ASCII.GetBytes(VideoInHtml(sessionId));
            AllureLifecycle.Instance.AddAttachment(title, "text/html", bytes, ".html");
        }

        public string VideoInHtml(string sessionId)
        {
            //Place where you put url address to Selenoid
            var html = $"<html><body><video width=\'100%\' height=\'100%\' controls autoplay><source src=\'http://addressToYourSelenoid:4444/video/{sessionId}.mp4' type=\'video/mp4\'></video></body></html>";
            return html;
        }
    }

}
