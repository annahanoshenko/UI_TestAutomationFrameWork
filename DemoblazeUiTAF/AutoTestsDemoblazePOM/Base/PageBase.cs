using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Base
{
    public class PageBase
    {
        public IWebDriver Driver;
        protected WebDriverWait wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

        public PageBase(IWebDriver driver)
        {
            Driver = driver;
        }

        public IAlert GetAlertWithWait()
        {
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            return alert;
        }

        public string GetAlertTextWithWait()
        {
            IAlert alert = GetAlertWithWait();
            return alert.Text;
        }

        public void AcceptAlert()
        {
            IAlert alert = GetAlertWithWait();
            alert.Accept();
        }

    }
}
