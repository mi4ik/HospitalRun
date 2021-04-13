using HospitalRun.DOMs;
using OpenQA.Selenium;
using System;

namespace HospitalRun
{
    class PageBase<T> where T : IPage
    {
        private static IWebDriver _driver;

        public string getTitle => _driver.Title;

        public PopupWindow PopupDialog => new PopupWindow();

        public static T Navigate(string url)
        {
            _driver = WebDriver.Get;
            _driver.Navigate().GoToUrl(url);

            return Go;
        }

        public static T Go
        {
            get
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }

        public WebElement _(By by)
        { 
            return new WebElement(by);
        }

        public bool Exists(By by)
        {
            bool exists = false;
            try
            {
                _(by);
                exists = true;
            }
            catch (Exception)
            {
                exists = false;
            }

            return exists;
        }
    }
}
