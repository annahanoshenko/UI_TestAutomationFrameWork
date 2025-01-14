using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static OpenQA.Selenium.BiDi.Modules.Script.RealmInfo;

namespace DemoblazeUiTAF
{
    [TestFixture]
    public class Class1
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.demoblaze.com");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void ShouldCreateNewUser_WhenDataIsValid()
        {
            string userName = "Anna" + DateTime.Now.Ticks;
            
            IWebElement signUpBtn = driver.FindElement(By.Id("signin2"));
            signUpBtn.Click();

            IWebElement userNameTextField = driver.FindElement(By.Id("sign-username"));
            userNameTextField.SendKeys(userName);

            IWebElement passwordTextField = driver.FindElement(By.Id("sign-password"));
            passwordTextField.SendKeys("qwerty67");

            IWebElement signUpOnPopUpBtn = driver.FindElement(By.XPath("//button[text() = 'Sign up']"));
            signUpOnPopUpBtn.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            
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

            IWebElement signUpBtn = driver.FindElement(By.Id("signin2"));
            signUpBtn.Click();

            IWebElement userNameTextField = driver.FindElement(By.Id("sign-username"));
            userNameTextField.SendKeys(userName);

            IWebElement passwordTextField = driver.FindElement(By.Id("sign-password"));
            passwordTextField.SendKeys(password);

            IWebElement signUpOnPopUpBtn = driver.FindElement(By.XPath("//button[text() = 'Sign up']"));
            signUpOnPopUpBtn.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string actualAlertText = alert.Text;
            string expectedAlertText = "Please fill out Username and Password.";
            alert.Accept();

            Assert.That(actualAlertText.Equals(expectedAlertText));
        }

        [Test]
        public void ShouldAddProductToCart_Succeds()
        {
            IWebElement productNameTitle = driver.FindElement(By.XPath("//*[@id='tbodyid']/div[4]/div/div/h4/a"));
            productNameTitle.Click();

            IWebElement addToCartBtn = driver.FindElement(By.XPath("//*[@id='tbodyid']/div[2]/div/a"));
            addToCartBtn.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string actualAlertText = alert.Text;
            string expectedAlertText = "Product added";
            alert.Accept();

            Assert.That(actualAlertText.Equals(expectedAlertText));

            IWebElement cartBtn = driver.FindElement(By.Id("cartur"));
            cartBtn.Click();
        }

        [Test]
        public void ShouldDeleteProductFromCart() 
        {
			IWebElement productNameTitle = driver.FindElement(By.XPath("//*[@id='tbodyid']/div[4]/div/div/h4/a"));
			productNameTitle.Click();

			IWebElement addToCartBtn = driver.FindElement(By.XPath("//*[@id='tbodyid']/div[2]/div/a"));
			addToCartBtn.Click();

			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

			string actualAlertText = alert.Text;
			string expectedAlertText = "Product added";
			alert.Accept();

			Assert.That(actualAlertText.Equals(expectedAlertText));

			IWebElement cartBtn = driver.FindElement(By.Id("cartur"));
            cartBtn.Click();

            IWebElement deleteFromCartBtn = driver.FindElement(By.XPath("(//a[text() = 'Delete'])[1]"));
            deleteFromCartBtn.Click();

            wait.Until(driver =>
            {
                var cartProducts = driver.FindElements(By.XPath("//*[@id='tbodyid']/tr"));
                return cartProducts.Count == 0;

            });

            var remainProducts = driver.FindElements(By.XPath("//*[@id='tbodyid']/tr"));
            Assert.That(remainProducts.Count, Is.EqualTo(0));
        }

        [Test]
        public void CanMakeOrderSuccessfully()
        {
            string userName = "Anna" + DateTime.Now.Ticks;
            IWebElement signUpBtn = driver.FindElement(By.Id("signin2"));
            signUpBtn.Click();

            IWebElement userNameTextField = driver.FindElement(By.Id("sign-username"));
            userNameTextField.SendKeys(userName);

            IWebElement passwordTextField = driver.FindElement(By.Id("sign-password"));
            passwordTextField.SendKeys("qwerty67");

            IWebElement signUpOnPopUpBtn = driver.FindElement(By.XPath("//button[text() = 'Sign up']"));
            signUpOnPopUpBtn.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string actualAlertText = alert.Text;
            string expectedAlertText = "Sign up successful.";
            alert.Accept();

            Assert.That(actualAlertText.Equals(expectedAlertText));

            IWebElement productNameTitle = driver.FindElement(By.XPath("//*[@id='tbodyid']/div[4]/div/div/h4/a"));
            productNameTitle.Click();

            IWebElement addToCartBtn = driver.FindElement(By.XPath("//*[@id='tbodyid']/div[2]/div/a"));
            addToCartBtn.Click();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IAlert alert1 = wait1.Until(ExpectedConditions.AlertIsPresent());

            string actualAlertText1 = alert1.Text;
            string expectedAlertText1 = "Product added";
            alert1.Accept();

            Assert.That(actualAlertText1.Equals(expectedAlertText1));

            IWebElement cartBtn = driver.FindElement(By.Id("cartur"));
            cartBtn.Click();

            IWebElement placeOrderBtn = driver.FindElement((By.XPath("//button[text() = 'Place Order']")));
            placeOrderBtn.Click();

			IWebElement nameTextField = driver.FindElement(By.Id("name"));
			nameTextField.SendKeys("Anna");

			IWebElement countryTextField = driver.FindElement(By.Id("country"));
			countryTextField.SendKeys("Poland");

			IWebElement creditCardTextField = driver.FindElement(By.Id("card"));
			creditCardTextField.SendKeys("12345678911");

			IWebElement monthTextField = driver.FindElement(By.Id("month"));
			monthTextField.SendKeys("12");

			IWebElement yearTextField = driver.FindElement(By.Id("year"));
			yearTextField.SendKeys("29");

			IWebElement purchaseBtn = driver.FindElement((By.XPath("//button[text() = 'Purchase']")));
			purchaseBtn.Click();


			WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			IWebElement confirmationPopup = wait2.Until(driver =>
		    driver.FindElement(By.XPath("//h2[text() = 'Thank you for your purchase!']"))
	        );
            Assert.That(confirmationPopup.Displayed, Is.True);
			
			IWebElement okBtn = wait2.Until(driver => driver.FindElement(By.XPath("//button[text() = 'OK']")));
			okBtn.Click();
		}


		public IWebElement[] GetCartProducts()
        {
            var cartProducts = driver.FindElements(By.XPath("//tbody[@id = 'tbodyid']/tr"));
            return cartProducts.ToArray();

        }

    }  
}
