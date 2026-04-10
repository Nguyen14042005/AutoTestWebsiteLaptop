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

          
            System.Threading.Thread.Sleep(2000);

            Assert.That(register.IsRegisterSuccess());
        }

        [Test]
        public void TC02_Email_Exists()
        {
            register.OpenRegisterForm();

            register.Register(
                "nnguyenn2005@gmail.com", 
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

        [Test]
        public void TC03_Email_Invalid()
        {
            register.OpenRegisterForm();

            register.Register(
                "abcgmail.com",
                "0123456789",
                "user1234",
                "123456",
                "123456",
                "Nguyen Van A",
                "HCM"
            );

            System.Threading.Thread.Sleep(2000);

            Assert.That(register.GetErrorMessage().Contains("email"));
        }

        [Test]
        public void TC04_Password_Short()
        {
            register.OpenRegisterForm();

            register.Register(
                "new123@gmail.com",
                "0123456789",
                "user1234",
                "123",
                "123",
                "Nguyen Van A",
                "HCM"
            );

            System.Threading.Thread.Sleep(2000);

            Assert.That(register.GetErrorMessage().Contains("password"));
        }



        [Test]
        public void TC05_Confirm_Wrong()
        {
            register.OpenRegisterForm();

            register.Register(
                "new456@gmail.com",
                "0123456789",
                "user1234",
                "123456",
                "654321", 
                "Nguyen Van A",
                "HCM"
            );

            System.Threading.Thread.Sleep(2000);

            Assert.That(register.GetErrorMessage().Contains("khớp"));
        }
    }
}
