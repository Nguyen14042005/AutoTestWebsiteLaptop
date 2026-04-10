using LaptopAutoTestSelenium.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Tests
{
    public class CheckoutTests : BaseTest
    {
        [Test]
        public void TC27_Checkout_Success()
        {
            CartPage cart = new CartPage(driver);
            CheckoutPage checkout = new CheckoutPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            cart.OpenFirstProduct();
            cart.AddToCart();
            cart.OpenCart();

            checkout.OpenCheckout();
            checkout.FillInfo("0123456789", "HCM");

            checkout.Submit();

            System.Threading.Thread.Sleep(2000);

            Assert.That(checkout.IsCheckoutSuccess());
           
        }

        [Test]
        public void TC28_MissingPhone()
        {
            CheckoutPage checkout = new CheckoutPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            checkout.OpenCheckout();
            checkout.FillInfo("", "HCM");

            checkout.Submit();

            System.Threading.Thread.Sleep(2000);

            Assert.That(checkout.IsErrorMessage());
            
        }

        [Test]
        public void TC29_InvalidPhone()
        {
                CheckoutPage checkout = new CheckoutPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            checkout.OpenCheckout();
                checkout.FillInfo("abc123", "HCM");

                checkout.Submit();

                System.Threading.Thread.Sleep(2000);

                Assert.That(checkout.IsErrorMessage());
           
        }

        [Test]
        public void TC30_ApplyCoupon()
        {
            CheckoutPage checkout = new CheckoutPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            checkout.OpenCheckout();
            checkout.ApplyCoupon("LAPTOP10");

            System.Threading.Thread.Sleep(2000);

            Assert.That(checkout.IsCouponApplied());
        }

        [Test]
        public void TC31_CouponExpired()
        {
            CheckoutPage checkout = new CheckoutPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            checkout.OpenCheckout();
            checkout.ApplyCoupon("EXPIRED");

            System.Threading.Thread.Sleep(2000);

            Assert.That(checkout.IsErrorMessage());
        }

        [Test]
        public void TC32_ShippingFee()
        {
            CheckoutPage checkout = new CheckoutPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            checkout.OpenCheckout();
            checkout.FillInfo("0123456789", "Hà Nội");

            checkout.Submit();

            System.Threading.Thread.Sleep(2000);

            Assert.That(driver.PageSource.Contains("phí")
                       || driver.PageSource.Contains("ship"));
            
        }
    }
}
