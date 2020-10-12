using OpenQA.Selenium;

namespace SeleniumPractice.Pages
{
    public class BaseApplicationPage
    {
        public BaseApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebDriver Driver { get; set; }
    }
}