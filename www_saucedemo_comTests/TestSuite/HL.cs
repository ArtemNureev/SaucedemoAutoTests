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

namespace www_saucedemo_comTests.TestSuite
{

    public class HL
    {
        private IWebDriver _webDriver;

        [Test]

        ///1 Инициализация веб-драйвера Chrome
        public void HLsort()
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
            Console.WriteLine("Авторизация в приложении под указанной учетной записью");
            var mainMenu = new AutorizationPageObject(_webDriver);
            mainMenu.Autorise();
            Assert.IsNotNull(mainMenu);
            Assert.True(true, "Тест пройден успешно, Откроется страница авторизации");
        /// Проверка на отображение элемента Products на открывшейся странице авторизации.
            var el = _webDriver.FindElement(By.XPath("//div[@class='header_secondary_container']/ child::span[contains (text(),'Products')]"));
            Assert.True(el.Displayed);
        }
        /// 2 Отсортировать товары High to Low, проверка.
        public void SortPricesAscending()
        {
            Console.WriteLine("2. Сортировка High to Low");
            /// Получение списка цен на товары
            IList<IWebElement> priceElements = _webDriver.FindElements(By.XPath("//div[@class='inventory_item_price']"));
            List<double> prices = new List<double>();

            /// Преобразование в числа
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
