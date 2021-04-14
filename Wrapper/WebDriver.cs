using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace HospitalRun
{
    public sealed class WebDriver
    {
        public enum BrowserType
        {
            Chrome,
            Firefox
        }

        private static IWebDriver _driver;

        public static IWebDriver Get => _driver;

        public static void Quit()
        {
            if (_driver != null)
                _driver.Dispose();
        }

        public static IWebDriver UseBrowser(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    {
                        _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
                        _driver.Manage().Window.Maximize();
                        return _driver;
                    }

                case BrowserType.Firefox:
                    {
                        _driver = new FirefoxDriver();
                        _driver.Manage().Window.Maximize();
                        return _driver;
                    }

                default:
                    return null;
            }
        }
    }
}
