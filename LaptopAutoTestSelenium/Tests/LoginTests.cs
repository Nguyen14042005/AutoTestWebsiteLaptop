using LaptopAutoTestSelenium.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Tests
{
    public class LoginTests : BaseTest
    {
        LoginPage login;

        [SetUp]
        public void Init()
        {
            driver.Navigate().GoToUrl("https://localhost:44311/");
            login = new LoginPage(driver);
        }

        [Test]
        public void TC06_Login_Success()
        {
            login.Login("nguyen", "123456");

            Assert.That(driver.Url, Does.Contain("home"));
        }

        [Test]
        public void TC07_Login_Fail()
        {
            login.Login("test@gmail.com", "sai123");

            Assert.That(login.GetError(), Does.Contain("sai"));
        }
    }
}
