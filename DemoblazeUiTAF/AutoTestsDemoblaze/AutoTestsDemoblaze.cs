using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;

namespace DemoblazeUiTAF.AutoTestsDemoblaze
{
    [TestFixture]
    internal class AutoTestsDemoblaze
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.demoblaze.com");
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }


        [Test]
        public void ShouldCreateNewUser_WhenDataIsValid()
        {
            string userName = "Anna" + DateTime.Now.Ticks;

            IWebElement signUpBtn = _driver.FindElement(By.Id("signin2"));
            signUpBtn.Click();

            IWebElement userNameTextField = _driver.FindElement(By.Id("sign-username"));
            userNameTextField.SendKeys(userName);

            IWebElement passwordTextField = _driver.FindElement(By.Id("sign-password"));
            passwordTextField.SendKeys("qwerty67");

            IWebElement signUpOnPopUpBtn = _driver.FindElement(By.XPath("//button[text() = 'Sign up']"));
            signUpOnPopUpBtn.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string actualAlertText = alert.Text;
            string expectedAlertText = "Sign up successful.";
            alert.Accept();

            Assert.That(actualAlertText.Equals(expectedAlertText));
        }

        [Test]
        public void Registration_ShouldFail_WhenUsernameAndPasswordAreEmpty()
        {
            string userName = "";
            string password = "";

            IWebElement signUpBtn = _driver.FindElement(By.Id("signin2"));
            signUpBtn.Click();

            IWebElement userNameTextField = _driver.FindElement(By.Id("sign-username"));
            userNameTextField.SendKeys(userName);

            IWebElement passwordTextField = _driver.FindElement(By.Id("sign-password"));
            passwordTextField.SendKeys(password);

            IWebElement signUpOnPopUpBtn = _driver.FindElement(By.XPath("//button[text() = 'Sign up']"));
            signUpOnPopUpBtn.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string actualAlertText = alert.Text;
            string expectedAlertText = "Please fill out Username and Password.";
            alert.Accept();

            Assert.That(actualAlertText.Equals(expectedAlertText));
        }

        [Test]
        public void ShouldAddProductToCart_Succeds()
        {
            IWebElement productNameTitle = _driver.FindElement(By.XPath("//*[@id='tbodyid']/div[4]/div/div/h4/a"));
            productNameTitle.Click();

            IWebElement addToCartBtn = _driver.FindElement(By.XPath("//*[@id='tbodyid']/div[2]/div/a"));
            addToCartBtn.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string actualAlertText = alert.Text;
            string expectedAlertText = "Product added";
            alert.Accept();

            Assert.That(actualAlertText.Equals(expectedAlertText));

            IWebElement cartBtn = _driver.FindElement(By.Id("cartur"));
            cartBtn.Click();
        }

        [Test]
        public void ShouldDeleteProductFromCart()
        {
            IWebElement productNameTitle = _driver.FindElement(By.XPath("//*[@id='tbodyid']/div[4]/div/div/h4/a"));
            productNameTitle.Click();

            IWebElement addToCartBtn = _driver.FindElement(By.XPath("//*[@id='tbodyid']/div[2]/div/a"));
            addToCartBtn.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string actualAlertText = alert.Text;
            string expectedAlertText = "Product added";
            alert.Accept();

            Assert.That(actualAlertText.Equals(expectedAlertText));

            IWebElement cartBtn = _driver.FindElement(By.Id("cartur"));
            cartBtn.Click();

            IWebElement deleteFromCartBtn = _driver.FindElement(By.XPath("(//a[text() = 'Delete'])[1]"));
            deleteFromCartBtn.Click();

            wait.Until(driver => GetCartProducts().Length == 0);
        }

        public IWebElement[] GetCartProducts()
        {
            var cartProducts = _driver.FindElements(By.XPath("//*[@id='tbodyid']/tr"));
            return cartProducts.ToArray();
        }

        [Test]
        public void CanMakeOrderSuccessfully()
        {
            string userName = "Anna" + DateTime.Now.Ticks;
            IWebElement signUpBtn = _driver.FindElement(By.Id("signin2"));
            signUpBtn.Click();

            IWebElement userNameTextField = _driver.FindElement(By.Id("sign-username"));
            userNameTextField.SendKeys(userName);

            IWebElement passwordTextField = _driver.FindElement(By.Id("sign-password"));
            passwordTextField.SendKeys("qwerty67");

            IWebElement signUpOnPopUpBtn = _driver.FindElement(By.XPath("//button[text() = 'Sign up']"));
            signUpOnPopUpBtn.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string actualAlertText = alert.Text;
            string expectedAlertText = "Sign up successful.";
            alert.Accept();

            Assert.That(actualAlertText.Equals(expectedAlertText));

            IWebElement productNameTitle = _driver.FindElement(By.XPath("//*[@id='tbodyid']/div[4]/div/div/h4/a"));
            productNameTitle.Click();

            IWebElement addToCartBtn = _driver.FindElement(By.XPath("//*[@id='tbodyid']/div[2]/div/a"));
            addToCartBtn.Click();

            WebDriverWait wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IAlert alert1 = wait1.Until(ExpectedConditions.AlertIsPresent());

            string actualAlertText1 = alert1.Text;
            string expectedAlertText1 = "Product added";
            alert1.Accept();

            Assert.That(actualAlertText1.Equals(expectedAlertText1));

            IWebElement cartBtn = _driver.FindElement(By.Id("cartur"));
            cartBtn.Click();

            IWebElement placeOrderBtn = _driver.FindElement(By.XPath("//button[text() = 'Place Order']"));
            placeOrderBtn.Click();

            IWebElement nameTextField = _driver.FindElement(By.Id("name"));
            nameTextField.SendKeys("Anna");

            IWebElement countryTextField = _driver.FindElement(By.Id("country"));
            countryTextField.SendKeys("Poland");

            IWebElement creditCardTextField = _driver.FindElement(By.Id("card"));
            creditCardTextField.SendKeys("12345678911");

            IWebElement monthTextField = _driver.FindElement(By.Id("month"));
            monthTextField.SendKeys("12");

            IWebElement yearTextField = _driver.FindElement(By.Id("year"));
            yearTextField.SendKeys("29");

            IWebElement purchaseBtn = _driver.FindElement(By.XPath("//button[text() = 'Purchase']"));
            purchaseBtn.Click();


            WebDriverWait wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            IWebElement confirmationPopup = wait2.Until(driver =>
            driver.FindElement(By.XPath("//h2[text() = 'Thank you for your purchase!']"))
            );
            Assert.That(confirmationPopup.Displayed, Is.True);

            IWebElement okBtn = wait2.Until(driver => driver.FindElement(By.XPath("//button[text() = 'OK']")));
            okBtn.Click();
        }

    }
}
