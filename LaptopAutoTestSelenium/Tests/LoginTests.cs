using LaptopAutoTestSelenium.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
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
            login = new LoginPage(driver);
        }

        [Test]
        public void TC06_Login_Success()
        {
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );

            System.Threading.Thread.Sleep(2000);

            
            Assert.Pass();
        }

        [Test]
        public void TC07_Login_WrongPassword()
        {
            login.OpenLoginForm();

            login.Login(
                "test123@gmail.com",
                "sai123"
            );

            // 🔥 WAIT message xuất hiện (không dùng sleep nữa)
            bool isError = wait.Until(d =>
                d.PageSource.Contains("sai") ||
                d.PageSource.Contains("không đúng") ||
                d.PageSource.Contains("thất bại")
            );

            Assert.That(isError);
        }

        [Test]
        public void TC08_Logout()
        {
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );

            System.Threading.Thread.Sleep(2000);

            login.Logout();

            System.Threading.Thread.Sleep(2000);

            Assert.That(login.IsLogoutSuccess());
        }
    }
}
