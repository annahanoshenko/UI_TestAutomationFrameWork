using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Base;
using SeleniumExtras.WaitHelpers;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Entities;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Pages
{
    internal class OrderPage : PageBase
    {
        private IWebElement NameTextField => Driver.FindElement(By.Id("name"));
        private IWebElement CountryTextField => Driver.FindElement(By.Id("country"));
        private IWebElement CreditCardTextField => Driver.FindElement(By.Id("card"));
        private IWebElement MonthTextField => Driver.FindElement(By.Id("month"));
        private IWebElement YearTextField => Driver.FindElement(By.Id("year"));
        private IWebElement PurchaseBtn => Driver.FindElement(By.XPath("//button[text() = 'Purchase']"));

        private By ConfirmationPopUpLocator = By.XPath("//h2[text() = 'Thank you for your purchase!']");
        private IWebElement ConfirmationPopUp => Driver.FindElement(ConfirmationPopUpLocator);
        private IWebElement OKBtn => Driver.FindElement(By.XPath("//button[text() = 'OK']"));

        public OrderPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterName(string name) => NameTextField.SendKeys(name);
        public void EnterCountry(string country) => CountryTextField.SendKeys(country);
        public void EnterCity(string city) => CountryTextField.SendKeys(city);
        public void EnterCreditCard(string card) => CreditCardTextField.SendKeys(card);
        public void EnterCardMonth(string month) => MonthTextField.SendKeys(month);
        public void EnterCardYear(string year) => YearTextField.SendKeys(year);
        public void ClickPurchaseButton() => PurchaseBtn.Click();
        public bool IsConfirmationPopUpIsDisplayed => ConfirmationPopUp.Displayed;
        public void ClickOkButton() => OKBtn.Click();

        public string GetConfirmationMessage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(ConfirmationPopUpLocator));
            return ConfirmationPopUp.Text;
        }

        public void FillingOrderFields(OrderEntity order)
        {
           EnterName(order.Name);
           EnterCountry(order.Country);
           EnterCity(order.City);
           EnterCreditCard(order.CreditCard);
           EnterCardMonth(order.Month);
           EnterCardYear(order.Year);
           ClickPurchaseButton();
        }
    }
}
