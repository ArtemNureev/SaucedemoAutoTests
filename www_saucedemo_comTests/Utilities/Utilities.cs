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
using static System.Net.Mime.MediaTypeNames;

namespace www_saucedemo_comTests.Utilities
{
    public static class Utilities
    {
        
        public const string URL = "https://www.saucedemo.com/";
        public const string login = "performance_glitch_user";
        public const string password = "secret_sauce";
    
    }
}