using NavigateToComplexPageViaSaerch.Page_Objects;
using OpenQA.Selenium.Support.Extensions;
using System.Diagnostics;

namespace NavigateToComplexPageViaSaerch
{
    internal class StartPage : Page
    {
        const string URL = "https://ultimateqa.com/";
        const string TITLE = "Homepage - Ultimate QA";
        private readonly IWebDriver driver;

        internal StartPage(IWebDriver driver) : base(driver, TITLE, URL)
        {
            this.driver = driver;
        }

        internal void Search(string query)
        {
            string searchBoxXPath = "//*/input[@placeholder=\"Search\"]";
            IWebElement searchBox = driver.FindElement(By.XPath(searchBoxXPath));
            searchBox.SendKeys(query);
            searchBox.SendKeys(Keys.Return);
        }
    }
}
