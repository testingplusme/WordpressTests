using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WordpressTests.Data;
using WordpressTests.Pages;

namespace WordpressTests.Steps
{
    [Binding]
    public sealed class WordPressCommentSteps:BaseSteps
    {
        private HomePage homePage;
        public WordPressCommentSteps(ScenarioContext scenarioContext, HomePage homePage) : base(scenarioContext)
        {
            this.homePage = homePage;
        }
        [Given(@"I enter to home page")]
        public void EnterToHomePage()
        {
            homePage.OpenPage();
            homePage.CloseCookiePopup();
        }

        [When(@"I leave comment for first post:")]
        public void LeaveCommentForFirstPost(Table table)
        {
           var comment = table.CreateSet<Comment>();
           homePage.LeaveComment(comment);
        }

        [Then(@"I see ""(.*)""")]
        public void SeeText(string comment)
        {
            homePage.CheckComment(comment);
        }

        [Then(@"I see information about invalid mail ""(.*)""")]
        public void SeeInformationAboutInvalidMail(string text)
        {
            homePage.CheckInvalidMail(text);
        }


    }
}
