using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using www_saucedemo_comTests.PageObject;

namespace www_saucedemo_comTests.Webpage
{
    class CardBoxPageObject
    {
        private IWebDriver _webdriver;
        private readonly By _submitContinueShopingButton = By.XPath("//div[@class=\"cart_footer\"]/child::button[@name=\"continue-shopping\"]");
        public CardBoxPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }
        public MainMenuPageObject ContinueShoping()
        //Нажатие кнопки "Продолжить покупки"
        {
            _webdriver.FindElement(_submitContinueShopingButton).Click();
            return new MainMenuPageObject(_webdriver);
        }
    }
}
