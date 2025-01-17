using DemoblazeUiTAF.AutoTestsDemoblazePOM.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Pages
{
    public class CartPage : PageBase
    {
        private IWebElement CartButton => Driver.FindElement(By.Id("cartur"));
        private IWebElement DeleteFromCartBtn => Driver.FindElement(By.XPath("(//a[text() = 'Delete'])[1]"));
        private IWebElement PlaceOrderButton => Driver.FindElement(By.XPath("//button[text() = 'Place Order']"));

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement[] GetCartProducts() =>
            Driver.FindElements(By.XPath("//*[@id='tbodyid']/tr")).ToArray();

        public void WaitUntilCartIsEmpty()
        {
            wait.Until(driver => GetCartProducts().Length == 0);
        }

        public void ClickCartButton() => CartButton.Click();
        public void ClickDeleteProductBtn() => DeleteFromCartBtn.Click();
        public void ClickPlaceOrderButton() => PlaceOrderButton.Click();

    }
}
