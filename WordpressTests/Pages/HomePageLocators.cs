using OpenQA.Selenium;

namespace WordpressTests.Pages
{
    public class HomePageLocators
    { 
        public By LeaveComment => By.CssSelector(".comments-link");
        public By CommentTextBox => By.CssSelector("#comment");
        public By Email => By.CssSelector("#email");
        public By Author => By.CssSelector("#author");
        public By PostComment => By.CssSelector(".form-submit");
        public By ValidationInvalidMail => By.CssSelector(".comment-form-email .nopublish");
        public By CookiePopup => By.CssSelector(".accept");
        public By CommentAwaitingModeration => By.CssSelector(".comment-awaiting-moderation");
    }
}
