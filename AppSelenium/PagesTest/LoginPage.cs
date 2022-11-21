using AppSelenium.Configuration;
using OpenQA.Selenium;

namespace AppSelenium.PagesTest
{
    public class LoginPage
    {
        public SeleniumCustom _seleniumCustom;
        private readonly SeleniumConfig config = new();

        public LoginPage(SeleniumCustom seleniumCustom)
        {
            _seleniumCustom = seleniumCustom;
        }

        public void GoToLoginPage()
        {
            _seleniumCustom.GoToUrl(config.Url);
        }

        public void SetUsernameInput(string username)
        {
            var elem = _seleniumCustom.GetById("usernameInput");
            elem.SendKeys(username);
        }

        public void SetPasswordInput(string password)
        {
            var elem = _seleniumCustom.GetById("passwordInput");
            elem.SendKeys(password);
        }

        public void EnterLogin()
        {
            _seleniumCustom.GetById("btnLogin").Click();
        }

        public bool HasMessageSuccess()
        {
            return _seleniumCustom.ExistElement(By.ClassName("alert-success"));
        }

        public bool HasMessageDanger()
        {
            return _seleniumCustom.ExistElement(By.ClassName("alert-danger"));
        }
    }
}
