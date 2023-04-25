using NavigateToComplexPageViaSaerch.Page_Objects;

namespace NavigateToComplexPageViaSaerch.Tests
{
    internal class SearchPage : Page
    {
        private readonly IWebDriver driver;
        ReadOnlyCollection<IWebElement> results;

        internal SearchPage(IWebDriver driver, string query) : base(driver)
        {
            SetTitle(query);
            SetUrl(query);
            this.driver = driver;
            IList<IWebElement> list = new List<IWebElement>();
            results = new ReadOnlyCollection<IWebElement>(list);
        }

        private void SetTitle(string query)
        {
            string titleStart = "You searched for ";
            string titleEnd = " - Ultimate QA";
            this.Title = titleStart + query + titleEnd;
        }

        private void SetUrl(string query)
        {
            string urlStart = "https://ultimateqa.com/?s=";
            string urlEnd = "&et_pb_searchform_submit=et_search_proccess&et_pb_include_posts=yes&et_pb_include_pages=yes";
            string encodedQuery = query.Replace(" ", "+"); //This would need to handle special chars better in prod
            this.Url = urlStart + encodedQuery + urlEnd;
        }

        internal bool HasResults()
        {
            string resultsXPath = "//*/div[@id=\"left-area\"]/*/h2/a";
            results = driver.FindElements(By.XPath(resultsXPath));
            return (results.Count > 0);
        }

        internal bool OnNotFoundPage()
        {
            try
            {
                driver.FindElement(By.ClassName("not-found-title"));
                return true;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }

        internal void OpenSpecificResult(string resultText)
        {
            IWebElement? result = GetResult(resultText);
            if(result == null)
            {
                throw new NoSuchElementException();
            }
            else
            {
                result.Click();
            }
        }

        private IWebElement? GetResult(string resultName)
        {
            foreach (IWebElement element in results)
            {
                if (element.Text.ToLower() == resultName.ToLower())
                {
                    return element;
                }
            }
            return null;
        }

        internal bool HasResult(string resultName)
        {
            return (GetResult(resultName) == null);
        }
    }
}