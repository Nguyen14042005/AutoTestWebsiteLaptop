using LaptopAutoTestSelenium.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Tests
{
    public class CartTests : BaseTest
    {
        [Test]
        public void TC17_AddToCart()
        {
            CartPage cart = new CartPage(driver);

            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );

            System.Threading.Thread.Sleep(2000);

            cart.OpenFirstProduct();
            System.Threading.Thread.Sleep(2000);

            cart.AddToCart();
            System.Threading.Thread.Sleep(2000);

            cart.OpenCart();

            Assert.That(cart.GetPageText().Contains("1"));
            
        }

        [Test]
        public void TC18_AddSameProduct()
        {
            CartPage cart = new CartPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            cart.OpenFirstProduct();
            cart.AddToCart();
            cart.AddToCart();

            cart.OpenCart();

            Assert.That(cart.GetPageText().Contains("2"));
            
        }

        [Test]
        public void TC19_UpdateQuantity()
        {
            CartPage cart = new CartPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            cart.OpenCart();
            cart.UpdateQuantity("5");

            System.Threading.Thread.Sleep(2000);

            Assert.That(cart.GetPageText().Contains("5"));
            
        }
        [Test]
        public void TC20_DeleteItem()
        {
            CartPage cart = new CartPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            cart.OpenCart();
            cart.DeleteItem();

            System.Threading.Thread.Sleep(2000);

            Assert.That(cart.GetPageText().Contains("Giỏ trống"));
            
        }
        [Test]
        public void TC21_EmptyCart()
        {
            CartPage cart = new CartPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            cart.OpenCart();

            Assert.That(cart.GetPageText().Contains("Giỏ trống"));
            
        }

        [Test]
        public void TC22_ClearCart()
        {
            CartPage cart = new CartPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            cart.OpenCart();
            cart.ClearCart();

            System.Threading.Thread.Sleep(2000);

            Assert.That(cart.GetPageText().Contains("Giỏ trống"));
        }

        [Test]
        public void TC23_InvalidQuantity_Negative()
        {
            CartPage cart = new CartPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            cart.OpenCart();
            cart.UpdateQuantity("-1");

            System.Threading.Thread.Sleep(2000);

            Assert.That(cart.GetPageText().Contains("lỗi")
                       || cart.GetPageText().Contains("không hợp lệ"));
     
        }

        [Test]
        public void TC24_Quantity_Exceed()
        {
            CartPage cart = new CartPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            cart.OpenCart();
            cart.UpdateQuantity("999");

            System.Threading.Thread.Sleep(2000);

            Assert.That(cart.GetPageText().Contains("vượt")
                       || cart.GetPageText().Contains("không đủ"));
            
        }

        [Test]
        public void TC25_ContinueShopping()
        {
            CartPage cart = new CartPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            cart.OpenCart();
            cart.ContinueShopping();

            System.Threading.Thread.Sleep(2000);

            Assert.That(driver.Url.Contains("san-pham")
                       || driver.PageSource.Contains("Sản phẩm"));
        }


        [Test]
        public void TC26_CheckTotal()
        {
            CartPage cart = new CartPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            cart.OpenCart();

            Assert.That(cart.GetPageText().Contains("Tổng"));
           
        }
    }
}
