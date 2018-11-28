using System.Collections.Generic;
using BoDi;
using Shouldly;
using WordpressTests.Data;
using WordpressTests.Extensions;
using WordpressTests.TestSettings;

namespace WordpressTests.Pages
{
    public class HomePage:BasePage
    {
        private HomePageLocators homePageLocators;
        public HomePage(IObjectContainer container,HomePageLocators homePageLocators) : base(container)
        {
            this.homePageLocators = homePageLocators;
        }


        public void LeaveComment(IEnumerable<Comment> comments)
        {

            foreach (var comment in comments)
            {
                if (comment.Email=="RandomMail")
                    //Place where you should change end of the email
                    comment.Email = $"{RandomExtension.RandomString(5)}{"@putYourFakeDomain.me"}";

                if (comment.Content=="RandomText")
                    comment.Content = RandomExtension.RandomString(10);

                if (comment.Author == "RandomText")
                    comment.Author = RandomExtension.RandomString(10);

                Driver.ClickOnElement(homePageLocators.LeaveComment);
                Driver.WaitForClickable(homePageLocators.CommentTextBox);
                Driver.FindElement(homePageLocators.CommentTextBox).SendKeys(comment.Content);
                Driver.WaitForClickable(homePageLocators.Author);
                Driver.FindElement(homePageLocators.Author).SendKeys(comment.Author);
                Driver.WaitForClickable(homePageLocators.Email);
                Driver.FindElement(homePageLocators.Email).SendKeys(comment.Email);
                Driver.ClickOnElement(homePageLocators.PostComment);

            }
            
        }

        public void CheckInvalidMail(string text)
        {
            Driver.Wait(TypeOfWait.TenSeconds).Until(x => homePageLocators.ValidationInvalidMail);
            Driver.FindElement(homePageLocators.ValidationInvalidMail).Text.ShouldBe(text);
        }

        public void OpenPage()
        {
            Driver.Navigate().GoToUrl(TestConfiguration.HomePageUrl);
        }

        public HomePage CloseCookiePopup()
        {
            if (Driver.ReturnDisplayStatusBySelector(homePageLocators.CookiePopup))
                Driver.ClickOnElement(homePageLocators.CookiePopup);
            return this;
        }

        public void CheckComment(string text)
        {
            Driver.WaitForClickable(homePageLocators.CommentAwaitingModeration);
            Driver.FindElement(homePageLocators.CommentAwaitingModeration).Text.ShouldBe(text);
        }
    }
}
