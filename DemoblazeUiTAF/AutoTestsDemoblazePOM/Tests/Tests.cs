using DemoblazeUiTAF.AutoTestsDemoblazePOM.Base;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Entities;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Pages;
using NUnit.Framework;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test]
        public void ShouldCteateNewUser_WhenDataIsValid()
        {
            UserEntity user = new UserEntity("Anna", "qwerty67");

            SignUpPage signUpPage = new SignUpPage(Driver);

            signUpPage.ClickSignUpButton();
            signUpPage.EnterUserName(user.UserName);
            signUpPage.EnterPassword(user.Password);
            signUpPage.ClickSignUpOnPopUpButton();

            string actualAlertText = signUpPage.GetAlertTextWithWait();
            string expectedAlertText = "Sign up successful.";
            signUpPage.AcceptAlert();

            Assert.That(actualAlertText.Equals(expectedAlertText));
        }

        [Test]
        public void Registration_ShouldFail_WhenUsernameAndPasswordFieldsAreEmpty()
        {
            UserEntity user = new UserEntity("", "");

            SignUpPage signUpPage = new SignUpPage(Driver);

            signUpPage.ClickSignUpButton();
            signUpPage.EnterUserName(user.UserName);
            signUpPage.EnterPassword(user.Password);
            signUpPage.ClickSignUpOnPopUpButton();

            string actualAlertText = signUpPage.GetAlertTextWithWait();
            string expectedAlertText = "Please fill out Username and Password.";
            signUpPage.AcceptAlert();

            Assert.That(actualAlertText.Equals(expectedAlertText));
        }

        [Test]
        public void ShouldloginExistingUser_WhenDataIsValid()
        {
            UserEntity user = new UserEntity("Anna14", "qwerty67");

            LoginPage loginPage = new LoginPage(Driver);

            loginPage.ClickLoginButton();
            loginPage.EnterUserName(user.UserName);
            loginPage.EnterPassword(user.Password);
            loginPage.ClickLoginPopUpButton();
        }

        [Test]
        public void ShouldDisplayWelcomeLable_AfterLogin()
        {
            UserEntity user = new UserEntity("Anna14", "qwerty67");

            LoginPage loginPage = new LoginPage(Driver);

            loginPage.ClickLoginButton();
            loginPage.EnterUserName(user.UserName);
            loginPage.EnterPassword(user.Password);
            loginPage.ClickLoginPopUpButton();

            string actualWelcomeLable = loginPage.GetWelcomeMessageText(user.UserName);
            string expectedWelcomeLablel = ($"Welcome {user.UserName}");

            Assert.That(actualWelcomeLable.Equals(expectedWelcomeLablel));
        }

        [Test]
        public void LoginShouldFail_WhenUsernameAndPasswordFieldsAreEmpty()
        {
            UserEntity user = new UserEntity("", "");

            LoginPage loginPage = new LoginPage(Driver);

            loginPage.ClickLoginButton();
            loginPage.EnterUserName(user.UserName);
            loginPage.EnterPassword(user.Password);
            loginPage.ClickLoginPopUpButton();

            string actualAlertText = loginPage.GetAlertTextWithWait();
            string expectedAlertText = "Please fill out Username and Password.";
            loginPage.AcceptAlert();

            Assert.That(actualAlertText.Equals(expectedAlertText));
        }
        [Test]
        public void ShouldAddProductToCart_Succeds()
        {
            ProductPage productPage = new ProductPage(Driver);
            CartPage cartPage = new CartPage(Driver);

            productPage.ClickProductNameTitle();
            productPage.ClickAddToCartButton();

            string actualAlertText = productPage.GetAlertTextWithWait();
            string expectedAlertText = "Product added";
            productPage.AcceptAlert();

            Assert.That(actualAlertText.Equals(expectedAlertText));

            cartPage.ClickCartButton();
        }
        [Test]
        public void ShouldDeleteProductFromCart_Succeds()
        {
            ProductPage productPage = new ProductPage(Driver);
            CartPage cartPage = new CartPage(Driver);

            productPage.ClickProductNameTitle();
            productPage.ClickAddToCartButton();

            string actualAlertText = productPage.GetAlertTextWithWait();
            string expectedAlertText = "Product added";
            productPage.AcceptAlert();

            Assert.That(actualAlertText.Equals(expectedAlertText));

            cartPage.ClickCartButton();
            cartPage.ClickDeleteProductBtn();
            cartPage.WaitUntilCartIsEmpty();
        }

        [Test]
        public void CanMakeOrderSuccessfully_WhenDataIsValid()
        {
            UserEntity user = new UserEntity("Anna14", "qwerty67");
            OrderEntity order = new OrderEntity("Anna", "USA", "New York", "123456789", "12", "122029");


            LoginPage loginPage = new LoginPage(Driver);
            ProductPage productPage = new ProductPage(Driver);
            CartPage cartPage = new CartPage(Driver);
            OrderPage orderPage = new OrderPage(Driver);

            // Login
            loginPage.ClickLoginButton();
            loginPage.EnterUserName(user.UserName);
            loginPage.EnterPassword(user.Password);
            loginPage.ClickLoginPopUpButton();

            // Add product to cart
            productPage.WaitForTheProductToBeNotStale();
            productPage.ClickProductNameTitle();
            productPage.ClickAddToCartButton();
    
            // Place order
            cartPage.ClickCartButton();
            cartPage.ClickPlaceOrderButton();
            orderPage.EnterName(order.Name);
            orderPage.EnterCountry(order.Country);
            orderPage.EnterCountry(order.City);
            orderPage.EnterCreditCard(order.CreditCard);
            orderPage.EnterCardMonth(order.Month);
            orderPage.EnterCardYear(order.Year);
            orderPage.ClickPurchaseButton();

            // Verify confirmation
            string confirmationMessage = orderPage.GetConfirmationMessage();
            Assert.That(confirmationMessage, Is.EqualTo("Thank you for your purchase!"));
            orderPage.ClickOkButton();
        }
        [Test]
        public void MakeOrderShouldFail_WhenOrderNameAndCardFieldsAreEmpty()
        {
            UserEntity user = new UserEntity("Anna14", "qwerty67");
            OrderEntity order = new OrderEntity("", "USA", "New York", "", "12", "122029");

            LoginPage loginPage = new LoginPage(Driver);
            ProductPage productPage = new ProductPage(Driver);
            CartPage cartPage = new CartPage(Driver);
            OrderPage orderPage = new OrderPage(Driver);

            loginPage.ClickLoginButton();
            loginPage.EnterUserName(user.UserName);
            loginPage.EnterPassword(user.Password);
            loginPage.ClickLoginPopUpButton();

            productPage.WaitForTheProductToBeNotStale();
            productPage.ClickProductNameTitle();
            productPage.ClickAddToCartButton();

            cartPage.ClickCartButton();
            cartPage.ClickPlaceOrderButton();
           
            orderPage.EnterName(order.Name);
            orderPage.EnterCountry(order.Country);
            orderPage.EnterCountry(order.City);
            orderPage.EnterCreditCard(order.CreditCard);
            orderPage.EnterCardMonth(order.Month);
            orderPage.EnterCardYear(order.Year);
            orderPage.ClickPurchaseButton();

            string actualAlertText = orderPage.GetAlertTextWithWait();
            string expectedAlertText = "Please fill out Name and Creditcard.";
            productPage.AcceptAlert();

            Assert.That(actualAlertText.Equals(expectedAlertText));
        }

        [Test]
        public void MakeOrderWithEmptyCart_Succeds()
        {
            UserEntity user = new UserEntity("Anna14", "qwerty67");
            OrderEntity order = new OrderEntity("Anna", "USA", "New York", "123456789", "12", "122029");
         
            LoginPage loginPage = new LoginPage(Driver);
            ProductPage productPage = new ProductPage(Driver);
            CartPage cartPage = new CartPage(Driver);
            OrderPage orderPage = new OrderPage(Driver);
           
            loginPage.ClickLoginButton();
            loginPage.EnterUserName(user.UserName);
            loginPage.EnterPassword(user.Password);
            loginPage.ClickLoginPopUpButton();

            productPage.ClickProductNameTitle();
            productPage.ClickAddToCartButton();

            cartPage.ClickCartButton();
            cartPage.ClickDeleteProductBtn();
            cartPage.WaitUntilCartIsEmpty();

            cartPage.ClickPlaceOrderButton();
            orderPage.EnterName(order.Name);
            orderPage.EnterCountry(order.Country);
            orderPage.EnterCountry(order.City);
            orderPage.EnterCreditCard(order.CreditCard);
            orderPage.EnterCardMonth(order.Month);
            orderPage.EnterCardYear(order.Year);
            orderPage.ClickPurchaseButton();

            string confirmationMessage = orderPage.GetConfirmationMessage();
            Assert.That(confirmationMessage, Is.EqualTo("Thank you for your purchase!"));
            orderPage.ClickOkButton();
        }

    }
}
