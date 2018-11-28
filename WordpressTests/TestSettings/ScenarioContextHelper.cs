using BoDi;
using TechTalk.SpecFlow;

namespace WordpressTests.TestSettings
{
    public class ScenarioContextHelper
    {
        private IObjectContainer container;

        public ScenarioContext ScenarioContext => container.Resolve<ScenarioContext>();
        public ScenarioContextHelper(IObjectContainer container)
        {
            this.container = container;
        }
    }
}
