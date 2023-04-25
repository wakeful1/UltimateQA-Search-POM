namespace NavigateToComplexPageViaSaerch.Page_Objects
{
    internal class Page
    {
        internal string Title { get; set; }
        internal string Url { get; set; }

        private readonly IWebDriver driver;

        internal Page(IWebDriver driver, string title = "", string url = "")
        {
            this.driver = driver;
            Title = title;
            Url = url;
        }

        internal void Open()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
