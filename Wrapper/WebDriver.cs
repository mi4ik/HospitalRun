using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
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
                _driver.Quit();
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

        public static bool WaitForAlert(bool accept)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            bool _catch = false;

            try
            {
                wait.Until(ExpectedConditions.AlertIsPresent());
                if (accept)
                {
                    _driver.SwitchTo().Alert().Accept();
                    _catch = true;
                }
                else
                {
                    _driver.SwitchTo().Alert().Dismiss();
                }
            }
            catch (WebDriverTimeoutException)
            {
                _catch = false;
            }

            return _catch;
        }
    }
}
