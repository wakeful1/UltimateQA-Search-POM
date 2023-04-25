namespace NavigateToComplexPageViaSaerch.Page_Objects
{
    internal class ComplicatedPage : Page
    {
        const string TITLE = "Complicated Page - Ultimate QA";
        const string URL = "https://ultimateqa.com/complicated-page/";
        private readonly IWebDriver driver;

        internal ComplicatedPage(IWebDriver driver) : base(driver, TITLE, URL)
        {
            this.driver = driver;
        }
    }
}
