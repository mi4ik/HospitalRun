using OpenQA.Selenium;

namespace HospitalRun
{
    class HomePage : PageBase<HomePage>, IPage
    {
        private By loginField = By.CssSelector("#identification");
        private By passwordField = By.CssSelector("#password");
        private By submit = By.CssSelector("button[type='submit']");
        private By errMessage = By.CssSelector(".alert");
        private By formSignin = By.CssSelector(".form-signin");

        public bool SigninFormIsVisible => _(formSignin).Displayed;

        public WebElement getErrMessage()
        {
            return _(errMessage);
        }

        public HomePage InputLogin(string value)
        {
            _(loginField).SendKeys(value);

            return this;
        }

        public HomePage InputPassword(string value)
        {
            _(passwordField).SendKeys(value);

            return this;
        }

        public PatientListPage SubmitLogin()
        {
            _(submit).Click();

            return PageBase<PatientListPage>.Go;
        }

        public PatientListPage Login(string user, string pwd)
        {
            return 
                InputLogin(user).
                InputPassword(pwd).
                SubmitLogin();
        }
    }
}
