using NUnit.Framework;
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
using System.Xml.Linq;
using www_saucedemo_comTests.PageObject;

namespace www_saucedemo_comTests.Webdriver
{
    public class WebDriver
    {
        public ChromeDriver _webdriver { get; set; }
        public WebDriver()
        {
            this._webdriver = new ChromeDriver();
        }
    }
}