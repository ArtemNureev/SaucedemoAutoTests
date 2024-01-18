using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using www_saucedemo_comTests.PageObject;
using www_saucedemo_comTests.Webpage;
using Microsoft.VisualStudio.CodeCoverage;
using OpenQA.Selenium.Support.UI;
using static System.Net.Mime.MediaTypeNames;

namespace www_saucedemo_comTests.TestSuite
{
    public class CardBoxPageObjectTests
    {

        private IWebDriver _webDriver;

        [Test]
        public void Post_the_Cart_into_the_Cart()
        /// 0 Инициализация драйвера
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl(Utilities.Utilities.URL);
            {
                AutoriseIndex();
                DoItemsToCart1();
                DoPress_CartButton();
                CartBOXbuttonContinue();
                DoItemsToCard2();
                DoPress_CartButton2();
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
            

        }

        /// 2 Добавить товар Sauce Labs Fleece Jacket в корзину (нажать кнопку ADD TO CART)
        public void DoItemsToCart1()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu.Add_to_CartButton1();
            Assert.IsNotNull(mainMenu);
            Assert.True(true, "Кнопка ADD TO CART изменится на REMOVE");
        /// Проверка на отображение элемента. Кнопка REMOVE
            var el = _webDriver.FindElement(By.XPath("//div[@class=\"pricebar\"]/descendant::button[@id=\"remove-sauce-labs-fleece-jacket\"]"));
            Assert.True(el.Displayed);
      
        }

        /// 3  Перейти в корзину нажатием кнопки сверху в правом углу в виде корзины
        public void DoPress_CartButton()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu.Press_CartButton();
            Assert.IsNotNull(mainMenu);
            Assert.True(true, "Откроется окно с добавленным товаром");
        /// Проверка на отображение элемента. Товар 'Sauce labs bolt t-shirt' находится в корзине.
            var el = _webDriver.FindElement(By.XPath("//div[@class=\"cart_item_label\"]/descendant::div[contains (text(),'Sauce Labs Fleece Jacket')]"));
            Assert.True(el.Displayed);
           
        }

        /// 4    Нажать кнопку CONTINUE SHOPPING
        public void CartBOXbuttonContinue()
        {
            var mainMenu = new CardBoxPageObject(_webDriver);
            mainMenu.ContinueShoping();
            Assert.IsNotNull(mainMenu);
        /// Проверка на отображение элемента Products на открывшейся странице авторизации.;
            var el = _webDriver.FindElement(By.XPath("//div[@class='header_secondary_container']/ child::span[contains (text(),'Products')]"));
            Assert.True(el.Displayed);
           
        }

        /// 5 Добавить товар Sauce Labs Bolt T-Shirt в корзину (нажать кнопку ADD TO CART)
        public void DoItemsToCard2()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu.Add_to_CartButton2();
            Assert.IsNotNull(mainMenu);
        /// Проверка на отображение элемента. Товар 'Sauce labs bolt t-shirt' находится в корзине.
            var el = _webDriver.FindElement(By.XPath("//div[@class=\"pricebar\"]/descendant::button[@id=\"remove-sauce-labs-bolt-t-shirt\"]"));
            Assert.True(el.Displayed);
           
        }
        
        /// 6 Перейти в корзину нажатием кнопки сверху в правом углу в виде корзины
        public void DoPress_CartButton2()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu.Press_CartButton();
            Assert.IsNotNull(mainMenu);
        /// Проверки на отображение элемента. Товары 'Sauce Labs Fleece Jacket','Sauce labs bolt t-shirt' находится в корзине.
            var el1 = _webDriver.FindElement(By.XPath("//div[@class=\"cart_item_label\"]/descendant::div[contains (text(),'Sauce Labs Fleece Jacket')]"));
            Assert.That(el1.Displayed);
            var el2 = _webDriver.FindElement(By.XPath("//div[@class=\"cart_item_label\"]/descendant::div[contains (text(),'Sauce Labs Bolt T-Shirt')]"));
            Assert.True(el2.Displayed);
            

        }

        /// 7 Закрыть браузер после выполнения теста
        [TearDown]
        public void Quit()
        {    
            _webDriver.Quit();
        }
    }
}


