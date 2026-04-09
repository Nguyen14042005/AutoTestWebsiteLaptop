using LaptopAutoTestSelenium.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Tests
{
    public class RegisterTests : BaseTest
    {
        RegisterPage register;

        [SetUp]
        public void Init()
        {
            register = new RegisterPage(driver);
        }

        [Test]
        public void TC01_Register_Success()
        {
            register.OpenRegisterForm();

            register.Register(
                "test1@gmail.com",
                "0123456789",
                "user123",
                "123456",
                "123456",
                "Nguyen Van A",
                "HCM"
            );

            // 🔥 wait 1 chút cho server xử lý
            System.Threading.Thread.Sleep(2000);

            Assert.That(register.IsRegisterSuccess());
        }

        [Test]
        public void TC02_Email_Exists()
        {
            register.OpenRegisterForm();

            register.Register(
                "nnguyenn2005@gmail.com", // email đã tồn tại
                "0123456789",
                "user1234",
                "123456",
                "123456",
                "Nguyen Van A",
                "HCM"
            );

            System.Threading.Thread.Sleep(2000);

            Assert.That(register.GetErrorMessage().Contains("tồn tại"));
        }
    }
}
