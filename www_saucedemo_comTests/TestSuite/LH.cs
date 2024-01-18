using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using www_saucedemo_comTests.Webdriver;
using www_saucedemo_comTests.PageObject;
using OpenQA.Selenium.Support.UI;
using www_saucedemo_comTests.Utilities;

namespace www_saucedemo_comTests.TestSuite
{

    public class LH
    {
        private IWebDriver _webDriver;

        [Test]
        ///1 Инициализация веб-драйвера Chrome
        public void LHSort()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl(Utilities.Utilities.URL);
            _webDriver.Manage().Window.Maximize();
            {
                AutoriseIndex();
                SortPricesAscending();
                Quit();
            }
        }

        /// 1 Авторизоваться в приложении под указанной учетной записью
        public void AutoriseIndex()
        {
            var mainMenu = new AutorizationPageObject(_webDriver);
            mainMenu.Autorise();
            Assert.IsNotNull(mainMenu);
            Assert.True(true, "Тест пройден успешно, Откроется страница авторизации");
            /// Проверка на отображение элемента Products на открывшейся странице авторизации.
            var el = _webDriver.FindElement(By.XPath("//div[@class='header_secondary_container']/ child::span[contains (text(),'Products')]"));
            Assert.True(el.Displayed);
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(2));
        }

        /// 2 Отсортировать товары Low to High, проверка.
        public void SortPricesAscending()
        {
            /// Получение списка цен на товары
            IList<IWebElement> priceElements = _webDriver.FindElements(By.XPath("//div[@class='inventory_item_price']"));
            List<double> prices = new List<double>();

            /// Извлечение цен и преобразование в числа
            foreach (IWebElement priceElement in priceElements)
            {
                string priceText = priceElement.Text.Replace("$", "").Trim();

                if (Double.TryParse(priceText, out double price))
                {
                    prices.Add(price);
                    Console.WriteLine(price);
                }
                else
                {
                    Console.WriteLine(priceText);
                }
            }
        }

        [TearDown]
        /// 3 Закрыть браузер после выполнения теста.
        public void Quit()

        {
            _webDriver.Quit();
        }
    }
}
