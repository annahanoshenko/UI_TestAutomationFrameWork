using DemoblazeUiTAF.AutoTestsDemoblazePOM.Base;
using OpenQA.Selenium;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Pages
{
    public class MainPage : PageBase
    {
        private IWebElement SignUpBtn => Driver.FindElement(By.Id("signin2"));
        private IWebElement CartButton => Driver.FindElement(By.Id("cartur"));
        private IWebElement ProductNameTitle(int productIndex) => Driver.FindElement(By.XPath("//*[@id='tbodyid']/div[4]/div/div/h4/a"));
        private IWebElement LoginButton => Driver.FindElement(By.Id("login2"));

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickSignUpBtn() => SignUpBtn.Click();
        public void ClickCartButton() => CartButton.Click();
        public void ClickProductNameTitle(int productIndex) => ProductNameTitle(productIndex).Click();
        public void ClickLoginButton() => LoginButton.Click();
    }
}
