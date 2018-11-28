using TechTalk.SpecFlow;

namespace WordpressTests.Steps
{
    public class BaseSteps
    {
        protected ScenarioContext scenarioContext;
        public BaseSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext=scenarioContext;
        }
    }
}
