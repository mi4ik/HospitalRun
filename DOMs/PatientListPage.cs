using HospitalRun.DOMs;
using OpenQA.Selenium;
using System.Linq;

namespace HospitalRun
{
    class PatientListPage : PageBase<PatientListPage>, IPage
    {
        private By viewTitle = By.CssSelector(".view-current-title");

        private By settingsTrigger = By.CssSelector(".settings-trigger");
        private By settingsMenu = By.CssSelector(".settings-nav");
        private By settingsOptions = By.CssSelector(".settings-nav a");

        private By primaryMenu = By.CssSelector(".primary-nav");
        private By menuItem = By.CssSelector(".primary-nav-item");
        private By menuSubItem = By.CssSelector(".category-sub-item");

        public NewRequest PatientRequest => new NewRequest();

        private void SelectElementByName(By parent, By child, string value)
        {            
            var options = _(parent).FindElements(child);

            options.First(x => x.Text == value).Click();
        }

        public string getViewTitle => _(viewTitle).Text;

        public HomePage LogOut()
        {
            _(settingsTrigger).Click();
            SelectElementByName(settingsMenu, settingsOptions, "Logout");

            return PageBase<HomePage>.Go;
        }

        public PatientListPage SelectMenuItem(string value)
        {
            SelectElementByName(primaryMenu, menuItem, value);

            return this;
        }

        public IPage SelectMenuSubItem(string value)
        {
            SelectElementByName(primaryMenu, menuSubItem, value);

            switch (value)
            {
                case "New Request": return PageBase<NewRequest>.Go;
            }

            return this;
        }

        public IWebElement[] getMenuItems()
        {
            return _(primaryMenu).FindElements(menuItem).ToArray();
        }

        public IWebElement[] getMenuSubItems()
        {
            return _(primaryMenu).FindElements(menuSubItem).ToArray();
        }
    }
}
