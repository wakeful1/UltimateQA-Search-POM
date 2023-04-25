using NavigateToComplexPageViaSaerch.Page_Objects;
using OpenQA.Selenium.Firefox;

namespace NavigateToComplexPageViaSaerch.Tests
{
    [TestClass]
    public class UnitTests
    {
        private readonly IWebDriver driver = new FirefoxDriver();
        const string COMPLICATEDPAGE = "complicated page";

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void NavigateToStartPage()
        {
            StartPage startPage = new StartPage(driver);
            startPage.Open();
            //Verify that we have opened the start page
            Assert.AreEqual(startPage.Url, driver.Url);
        }

        [TestMethod]
        public void SearchFromStartPage()
        {
            StartPage startPage = new StartPage(driver);
            SearchPage searchPage = new SearchPage(driver, COMPLICATEDPAGE);
            startPage.Open();
            //Search for complicated page. Doesn't work!!! Need to wait for page to load
            startPage.Search(COMPLICATEDPAGE);
            //Verify we have navigated to the correct search page
            Assert.AreEqual(searchPage.Url, driver.Url);
            //Verify the page we are expecting is in the results
            Assert.IsTrue(searchPage.HasResult(COMPLICATEDPAGE));
        }

        [TestMethod]
        public void OpenComplicatedPageFromSearchResults()
        {
            SearchPage searchPage = new SearchPage(driver, COMPLICATEDPAGE);
            ComplicatedPage compPage = new ComplicatedPage(driver);
            searchPage.Open();
            //Check that the search has results
            Assert.IsTrue(searchPage.HasResults());
            //Click on on complicated page, which we expect to be in the search results
            searchPage.OpenSpecificResult(COMPLICATEDPAGE);
            //Verify that we have navigated to Complicated Page's URL
            Assert.AreEqual(compPage.Url, driver.Url);
        }

        [TestMethod]
        public void SearchForNonexistentPage()
        {
            //This string, when searched, should produce no results
            string invalidQuery = "asdf";
            SearchPage searchPage = new SearchPage(driver, invalidQuery);
            searchPage.Open();
            //We should not have any search results
            Assert.IsFalse(searchPage.HasResults());
            //The search page should show the "not found" page
            Assert.IsTrue(searchPage.OnNotFoundPage());
        }
    }
}