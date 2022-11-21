using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AppSelenium.Configuration
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(Browser browser, string url, bool headless)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case Browser.Chrome:
                    var chromeOptions = new ChromeOptions();
                    if (headless)
                        chromeOptions.AddArgument("--headless");
                    webDriver = new ChromeDriver(url, chromeOptions);
                    break;

                case Browser.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    if (headless)
                        firefoxOptions.AddArgument("--headless");
                    webDriver = new FirefoxDriver(url, firefoxOptions);

                    break;
            }

            return webDriver;
        }
    }
}
