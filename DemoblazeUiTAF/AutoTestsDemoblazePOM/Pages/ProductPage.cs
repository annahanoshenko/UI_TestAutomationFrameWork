using DemoblazeUiTAF.AutoTestsDemoblazePOM.Base;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Pages
{
    public class ProductPage : PageBase
    {
        private IWebElement ProductNameTitle => Driver.FindElement(By.XPath("//*[@id='tbodyid']/div[4]/div/div/h4/a"));
        private IWebElement AddToCartBtn => Driver.FindElement(By.XPath("//*[@id='tbodyid']/div[2]/div/a"));

        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickProductNameTitle() => ProductNameTitle.Click();
        public void ClickAddToCartButton() => AddToCartBtn.Click();

        public void WaitForTheProductToBeNotStale()
        {
            wait.Until(ExpectedConditions.StalenessOf(ProductNameTitle));
        }
    }
}
