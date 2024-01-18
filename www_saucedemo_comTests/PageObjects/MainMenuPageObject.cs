using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static System.Net.Mime.MediaTypeNames;

namespace www_saucedemo_comTests.PageObject
{
    class MainMenuPageObject
    {
        private IWebDriver _webDriver;
        private readonly By _submitAdd_toCartButton1 = By.XPath("//button[@name='add-to-cart-sauce-labs-fleece-jacket']");
        private readonly By _submitAdd_toCartButton2 = By.XPath("//button[@name='add-to-cart-sauce-labs-bolt-t-shirt']");
        private readonly By _submitCardButton = By.XPath("//*[@class=\"shopping_cart_link\"]");
       

    public MainMenuPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainMenuPageObject Add_to_CartButton1()
        /// Добавление товара sauce-labs-fleece-jacket в корзину
        {

            _webDriver.FindElement(_submitAdd_toCartButton1).Click();
            return new MainMenuPageObject(_webDriver);
        }

        public MainMenuPageObject Press_CartButton()
        /// Нажатие кнопку "Корзина"
        {
            _webDriver.FindElement(_submitCardButton).Click();
            return new MainMenuPageObject(_webDriver);
        }

        public MainMenuPageObject Add_to_CartButton2()
        /// Добавление товара sauce-labs-bolt-t-shirt в корзину 
        {
            _webDriver.FindElement(_submitAdd_toCartButton2).Click();
            return new MainMenuPageObject(_webDriver);
        }
       
    }
}


