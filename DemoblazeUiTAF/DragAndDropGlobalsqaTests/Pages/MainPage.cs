using DemoblazeUiTAF.DragAndDropGlobalsqaTests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;

namespace DemoblazeUiTAF.DragAndDropGlobalsqaTests.Pages
{
    internal class MainPage : PageBase
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        private By PhotoManagerLocator = By.XPath("//div[@rel-title='Photo Manager']//iframe");
        private IWebElement TrashIcon => Driver.FindElement(By.XPath("//*[@id='gallery']/li[1]/a[2]"));
        private IWebElement RecycleIcon => Driver.FindElement(By.XPath("//*[@id='trash']/ul/li/a[2]"));
        private IWebElement SourceElement => Driver.FindElement(By.XPath("//*[@id='gallery']/li[2]/h5"));
        private IWebElement TargetElementTrash => Driver.FindElement(By.Id("trash"));
        private IWebElement ZoomIcon => Driver.FindElement(By.XPath("//*[@id='gallery']/li[3]/a[1]"));
        private IWebElement ExitIcon => Driver.FindElement(By.XPath("/html/body/div[3]/div[1]/button/span[1]"));
        private IWebElement ConsestButton => Driver.FindElement(By.XPath("//p[text()='Consent']"));
        private IWebElement[] PhotoGalleryElements => Driver.FindElements(By.XPath("//ul[@id='gallery']/li/h5")).ToArray();

        private IWebElement[] TrashElements => Driver.FindElements(By.XPath("//div[@id = 'trash']")).ToArray();

        public string[] Photoname => PhotoGalleryElements.Select(element => element.Text).ToArray();

        public void ClickTrashIcon() => TrashIcon.Click();
        public void ClickRecycleIcon() => RecycleIcon.Click();
        public void ClickZoomIcon() => ZoomIcon.Click();
        public void ClickExitIcon() => ExitIcon.Click();
        public void AcceptCookieConsent()
        {
            ConsestButton.Click();
        }

        public void SwitchToPhotoManagerFrame()
        {
            SwitchToFrame(PhotoManagerLocator);
        }

        public void DragAndDropElement(string name)
        {
            IWebElement element = PhotoGalleryElements.Single(i => i.Text == name);

            Actions action = new Actions(Driver);
            action.DragAndDrop(element, TargetElementTrash).Perform();

        }

       public bool IsElementInTrash(string photoName)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            try
            {
                string xpath = $"//h5[contains(text(), '{photoName}')]";
                wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
                return true;
            }
            catch(TimeoutException) 
            {
                return false;
            }
        }

        public bool IsElementInPhotoMAnager(string photoName)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//h5[contains(text(), '{photoName}')]")));
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }

        public IReadOnlyCollection<IWebElement> GetAllPhotoElements()
        {
            return Driver.FindElements(By.XPath("//ul[@id='gallery']/li/h5"));
        }

    }
}
