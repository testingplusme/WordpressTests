using System;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using WordpressTests.Extensions;

namespace WordpressTests.TestSettings
{
    [Binding]
    public sealed class SeleniumHooks
    {
        private IObjectContainer container;
        private ScenarioContext scenarioContext;
        private AllureReportHelper allureReport;

        public SeleniumHooks(IObjectContainer container, ScenarioContext scenarioContext, AllureReportHelper allureReport)
        {
            this.container = container;
            this.scenarioContext = scenarioContext;
            this.allureReport = allureReport;
          
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = new WebDriverFactory().ReturnWebDriver(Browsers.FirefoxRemote);
            container.RegisterInstanceAs<IWebDriver>(driver);
            driver.Maximize();           
        }

        [AfterStep]
        public void AfterStep()
        {
            if (scenarioContext.TestError != null)
                allureReport.SaveScreenshot(Guid.NewGuid().ToString(),scenarioContext.StepContext.StepInfo.Text);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = container.Resolve<IWebDriver>() as RemoteWebDriver;
            if (scenarioContext.TestError!=null)
                allureReport.AddVideoToScenario(scenarioContext.ScenarioInfo.Title, driver.SessionId.ToString());      
            driver.Quit();
            container.Dispose();
        }
    }
}
