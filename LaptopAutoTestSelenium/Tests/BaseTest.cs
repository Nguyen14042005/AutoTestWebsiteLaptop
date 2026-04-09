using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Khởi tạo Chrome
            driver = new ChromeDriver();

            // Mở web localhost của bạn
            driver.Navigate().GoToUrl("https://localhost:44311/");

            // Max màn hình
            driver.Manage().Window.Maximize();

            // Wait ngầm (tránh lỗi find element)
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown()
        {
            // Đóng browser sau mỗi test
            driver.Quit();
        }
    }
}
