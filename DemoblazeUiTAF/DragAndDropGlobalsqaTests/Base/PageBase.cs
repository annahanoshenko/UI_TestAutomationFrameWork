using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace DemoblazeUiTAF.DragAndDropGlobalsqaTests.Base
{
    internal class PageBase
    {
        public IWebDriver Driver;
        protected WebDriverWait wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

        public PageBase(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement FindElement (By by)
        {
            return Driver.FindElement(by);
        }

        protected void SwitchToFrame(By locator)
        {
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(locator));
        }
    }
}
