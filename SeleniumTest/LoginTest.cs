using AppSelenium.Configuration;
using AppSelenium.PagesTest;
using Xunit;

namespace SeleniumTest
{
    public class LoginTest
    {
        private readonly SeleniumCustom _seleniumCustom;
        private readonly LoginPage _loginPage;
        public LoginTest()
        {
            _seleniumCustom = new SeleniumCustom(Browser.Chrome);
            _loginPage = new LoginPage(_seleniumCustom);
        }

        [Fact(DisplayName = "Login Correto")]
        public void RightLogin_Should_Success()
        {
            //arrange
            _loginPage.GoToLoginPage();
            _loginPage.SetUsernameInput("admin");
            _loginPage.SetPasswordInput("admin");

            //act
            _loginPage.EnterLogin();

            //assert
            Assert.True(_loginPage.HasMessageSuccess());
            _seleniumCustom.Dispose();
        }

        [Fact(DisplayName = "Login Não encontrado")]
        public void WrongLogin_Should_Fail()
        {
            //arrange
            _loginPage.GoToLoginPage();
            _loginPage.SetUsernameInput("teste");
            _loginPage.SetPasswordInput("teste");

            //act
            _loginPage.EnterLogin();

            //assert
            Assert.True(_loginPage.HasMessageDanger());
            _seleniumCustom.Dispose();
        }
    }
}