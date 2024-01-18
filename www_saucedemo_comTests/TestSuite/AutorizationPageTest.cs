using NUnit.Framework;
using www_saucedemo_comTests.Webdriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using www_saucedemo_comTests.Utilities;
using OpenQA.Selenium.Internal;
using www_saucedemo_comTests.PageObject;
using System.Xml.Linq;

namespace www_saucedemo_comTests.TestSuite
{
    public class AutorizationPageTest
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl(Utilities.Utilities.URL);
        }

        [Test]
        public void AutorizePerformance_glitch_user()
        {
            Console.WriteLine("Авторизация в приложении под указанной учетной записью");
            var mainMenu = new AutorizationPageObject(_webDriver);
            mainMenu
            .Autorise();

            Assert.IsNotNull(mainMenu);
         }


        [TearDown]
        public void Quit()
        {
            /// Закрыть браузер после выполнения теста
            _webDriver.Quit();
        }


    }
}

    
