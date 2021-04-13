using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HospitalRun.DOMs
{
    class PopupWindow
    {
        private By modalContent = By.CssSelector(".modal-content");
        private By dialogHeader = By.CssSelector(".modal-content .modal-header");
        private By closeIcon = By.CssSelector(".modal-content .octicon");
        private By okButton = By.CssSelector(".modal-content .btn-primary");

        public WebElement OkBtn => new WebElement(okButton);

        public WebElement CloseIcon => new WebElement(closeIcon);

        public WebElement DialogHeader => new WebElement(dialogHeader);

        public PopupWindow()
        {

        }
    }
}
