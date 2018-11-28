using BoDi;
using OpenQA.Selenium;
using WordpressTests.TestSettings;

namespace WordpressTests.Pages
{
    public class BasePage
    {
        protected IObjectContainer container;
        protected IWebDriver Driver => container.Resolve<IWebDriver>();
        protected ScenarioContextHelper scenarioContextHelper => container.Resolve<ScenarioContextHelper>();
        public BasePage(IObjectContainer container)
        {
            this.container = container;
        }
    }
}