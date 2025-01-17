using DemoblazeUiTAF.AutoTestsDemoblazePOM.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Pages
{
    public class LoginPage : PageBase
    { 
        private IWebElement LoginBtn => Driver.FindElement(By.Id("login2"));
        private IWebElement UserNameTextField => Driver.FindElement(By.Id("loginusername"));
        private IWebElement PasswordTextField => Driver.FindElement(By.Id("loginpassword"));
        private IWebElement LoginPopUpBtn => Driver.FindElement(By.XPath("//button[text() = 'Log in']"));


        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickLoginButton() => LoginBtn.Click();
        public void EnterUserName(string username) => UserNameTextField.SendKeys(username);
        public void EnterPassword(string password) => PasswordTextField.SendKeys(password);
        public void ClickLoginPopUpButton() => LoginPopUpBtn.Click();

        public string GetWelcomeMessageText(string nameofuser)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            IWebElement welcomeLable = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nameofuser")));
            return welcomeLable.Text;
        }
    }
}
