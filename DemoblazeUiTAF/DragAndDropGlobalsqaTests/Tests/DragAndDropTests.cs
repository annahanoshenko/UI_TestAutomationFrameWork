
using DemoblazeUiTAF.DragAndDropGlobalsqaTests.Base;
using DemoblazeUiTAF.DragAndDropGlobalsqaTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;


namespace DemoblazeUiTAF.DragAndDropGlobalsqaTests.Tests
{
    [TestFixture]
    internal class DragAndDropTests : BaseTest
    {
        [TestCase("High Tatras")]
        [TestCase("High Tatras 2")]
        [TestCase("High Tatras 3")]
        [TestCase("High Tatras 4")]
        public void ShouldDeleteImage_WhenDraggingToTheTrash(string photoName)
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.AcceptCookieConsent();
            mainPage.SwitchToPhotoManagerFrame();
            mainPage.DragAndDropElement(photoName);

            bool isElementInTrash = mainPage.IsElementInTrash(photoName);

            // Assert.IsTrue(isElementInTrash)
        }

        [TestCase("High Tatras")]
        [TestCase("High Tatras 2")]
        [TestCase("High Tatras 3")]
        [TestCase("High Tatras 4")]
        public void ShouldDeleteImage_WhenClickOnTheTrashIcon(string photoName)
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.AcceptCookieConsent();
            mainPage.SwitchToPhotoManagerFrame();
            mainPage.ClickTrashIcon();

            bool isElementInTrash = mainPage.IsElementInTrash(photoName);

        }

        [TestCase("High Tatras")]
        [TestCase("High Tatras 2")]
        [TestCase("High Tatras 3")]
        [TestCase("High Tatras 4")]
        public void ShouldRecycleImage_WhenDraggingToThePhotoMAnager(string photoName)
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.AcceptCookieConsent();
            mainPage.SwitchToPhotoManagerFrame();
            mainPage.ClickTrashIcon();
            mainPage.DragAndDropElement(photoName);

            bool isElementInPhotoMAnager = mainPage.IsElementInPhotoMAnager(photoName);

        }

        [TestCase("High Tatras")]
        [TestCase("High Tatras 2")]
        [TestCase("High Tatras 3")]
        [TestCase("High Tatras 4")]
        public void ShouldRecycleImage_WhenClickOnTheRecycleIcon(string photoName)
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.AcceptCookieConsent();
            mainPage.SwitchToPhotoManagerFrame();
            mainPage.ClickTrashIcon();
            mainPage.ClickRecycleIcon();

            bool isElementInPhotoMAnager = mainPage.IsElementInPhotoMAnager(photoName);

        }

        [TestCase("High Tatras")]
        [TestCase("High Tatras 2")]
        [TestCase("High Tatras 3")]
        [TestCase("High Tatras 4")]
        public void ShoulZoomImage_WhenClickOnTheZoomIcon(string photoName)
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.AcceptCookieConsent();
            mainPage.SwitchToPhotoManagerFrame();

            var allPhotos = mainPage.GetAllPhotoElements();
            foreach (var photo in allPhotos)
            {
                int initialWidth = photo.Size.Width;
                int initialHeight = photo.Size.Height;


                mainPage.ClickZoomIcon();

                int newWidth = photo.Size.Width;
                int newHeight = photo.Size.Height;

                Assert.That(newWidth > initialWidth);
                Assert.That(newHeight > initialHeight);
            }

        }

        [TestCase("High Tatras")]
        [TestCase("High Tatras 2")]
        [TestCase("High Tatras 3")]
        [TestCase("High Tatras 4")]
        public void ShouldCloseImage_WhenClickOnTheCloseIcon(string photoName)
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.AcceptCookieConsent();
            mainPage.SwitchToPhotoManagerFrame();
            mainPage.ClickZoomIcon();
            mainPage.ClickExitIcon();

            bool isElementInPhotoMAnager = mainPage.IsElementInPhotoMAnager(photoName);
        }

    }
}
