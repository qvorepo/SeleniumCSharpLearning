using OpenQA.Selenium;

namespace SeleniumPractice.Pages
{
    public class SearchResultsPage :BaseApplicationPage
    {
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsLoaded => Driver.Url.Contains("?s");
    }
}