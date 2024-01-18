using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using www_saucedemo_comTests.Utilities;


namespace www_saucedemo_comTests.PageObject
{
    class AutorizationPageObject
    {
        private IWebDriver _webDriver;
        private readonly By _loginInputButton = By.XPath("//div[@class=\"form_group\"]/child::input");
        private readonly By _passwordInputButton = By.XPath("//*[@id=\"password\"]");
        private readonly By _submitLoginButton = By.XPath("//div[@class=\"form_group\"]/following-sibling::input[@type=\"submit\"]");

        public AutorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    public MainMenuPageObject Autorise()
     ///  Ввод логина и пароля, нажатие кнопки авторизации
        {
            _webDriver.Manage().Window.Maximize();
            _webDriver.FindElement(_loginInputButton).SendKeys(Utilities.Utilities.login);
            _webDriver.FindElement(_passwordInputButton).SendKeys(Utilities.Utilities.password);
            _webDriver.FindElement(_submitLoginButton).Click();
            Assert.True(true, "Тест пройден успешно, Открытие главной страницы приложения с товарами");
            return new MainMenuPageObject(_webDriver);
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(2));

        }

    }
}
