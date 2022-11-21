using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AppSelenium.Configuration
{
    public class SeleniumCustom : IDisposable
    {
        public IWebDriver webDriver;
        private readonly SeleniumConfig config = new();
        public WebDriverWait wait;
        public SeleniumCustom(Browser browser)
        {
            webDriver = WebDriverFactory.CreateWebDriver(browser, config.Url, config.Headless);
            webDriver.Manage().Window.Maximize();
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
        }

        public void GoToUrl(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public string GetUrl()
        {
            return webDriver.Url;
        }

        public IWebElement GetByClass(string className)
        {
            var elem = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className)));
            return elem;
        }

        public bool ExistElement(By by)
        {
            try
            {
                IWebElement elem = webDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        public IWebElement GetByXpath(string xpath)
        {
            IWebElement elem = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            return elem;
        }

        public IWebElement GetById(string id)
        {
            IWebElement elem = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            return elem;
        }

        public IWebElement GetByLinkText(string linkText)
        {
            IWebElement elem = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(linkText)));
            return elem;
        }

        public void Dispose()
        {
            webDriver.Quit();
            webDriver.Dispose();
        }
    }
}
