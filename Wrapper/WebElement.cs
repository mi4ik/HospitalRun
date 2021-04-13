using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace HospitalRun
{
    public class WebElement: IWebElement
    {
        private readonly IWebDriver _driver = WebDriver.Get;
        private WebDriverWait _wait;
        
        private IWebElement Wait(By by, int secWait, int msInterval)
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(secWait));
            _wait.PollingInterval = TimeSpan.FromMilliseconds(msInterval);

            try
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

        public WebElement(By by, int secWait = 10, int msInterval = 500)
        {
            webElement = Wait(by, secWait, msInterval);
        }

        public WebElement(string css, int secWait = 10, int msInterval = 500)
        {
            webElement = Wait(By.CssSelector(css), secWait, msInterval);
        }

        protected IWebElement webElement { get;  }

        public string TagName => webElement.TagName;

        public string Text => webElement.Text;

        public bool Enabled => webElement.Enabled;

        public bool Selected => webElement.Selected;

        public Point Location => webElement.Location;

        public Size Size => webElement.Size;

        public bool Displayed => webElement.Displayed;

        public void Clear()
        {
            webElement.Clear();
        }

        public void SendKeys(string text)
        {
            webElement.SendKeys(text);
        }

        public void Submit()
        {
            webElement.Submit();
        }

        public void Click()
        {
            webElement.Click();
        }

        public string GetAttribute(string attributeName)
        {
            return webElement.GetAttribute(attributeName);
        }

        public string GetProperty(string propertyName)
        {
            return webElement.GetProperty(propertyName);
        }

        public string GetCssValue(string propertyName)
        {
            return webElement.GetCssValue(propertyName);
        }

        public IWebElement FindElement(By by)
        {
            return webElement.FindElement(by);
        }

        public IWebElement Child(By by)
        {
            return webElement.FindElement(by);
        }

        public IWebElement Child(string css)
        {
            return webElement.FindElement(By.CssSelector(css));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return webElement.FindElements(by);
        }
    }
}
