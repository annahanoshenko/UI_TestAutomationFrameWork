using DemoblazeUiTAF.AutoTestsDemoblazePOM.Base;
using OpenQA.Selenium;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Pages
{
    internal class SignUpPage : PageBase
    {
        private IWebElement SignUpBtn => Driver.FindElement(By.Id("signin2"));
        private IWebElement UserNameTextField => Driver.FindElement(By.Id("sign-username"));
        private IWebElement PasswordTextField => Driver.FindElement(By.Id("sign-password"));
        private IWebElement SignUpOnPopUpBtn => Driver.FindElement(By.XPath("//button[text() = 'Sign up']"));

        public SignUpPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickSignUpButton() => SignUpBtn.Click();
        public void EnterUserName(string username) => UserNameTextField.SendKeys(username);
        public void EnterPassword(string password) => PasswordTextField.SendKeys(password);
        public void ClickSignUpOnPopUpButton() => SignUpOnPopUpBtn.Click();
    }
}
