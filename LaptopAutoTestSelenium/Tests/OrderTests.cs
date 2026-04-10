using LaptopAutoTestSelenium.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Tests
{
    public class OrderTests : BaseTest
    {
        [Test]
        public void TC33_ViewOrders()
        {

            LoginPage login = new LoginPage(driver);
            OrderPage order = new OrderPage(driver);


            login.OpenLoginForm();
            login.Login("nguyen", "nguyen123");

            System.Threading.Thread.Sleep(2000);

            order.OpenMyOrders();

            Assert.That(order.HasOrders());
            
        }

        [Test]
        public void TC34_ViewOrderDetail()
        {
            LoginPage login = new LoginPage(driver);
            OrderPage order = new OrderPage(driver);

            login.OpenLoginForm();
            login.Login("nguyen", "nguyen123");

            System.Threading.Thread.Sleep(2000);

            order.OpenMyOrders();
            order.ClickDetail();

            System.Threading.Thread.Sleep(2000);

            Assert.That(order.GetText().Contains("Chi tiết")
                       || order.GetText().Contains("Sản phẩm"));
        }

        [Test]
        public void TC35_CancelOrder()
        {
            OrderPage order = new OrderPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            order.OpenMyOrders();
            order.CancelOrder();

            System.Threading.Thread.Sleep(2000);

            Assert.That(order.GetText().Contains("hủy")
                       || order.GetText().Contains("đã hủy"));
           
        }

        [Test]
        public void TC36_ReOrder()
        {
            OrderPage order = new OrderPage(driver);
            CartPage cart = new CartPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            order.OpenMyOrders();
            order.ReOrder();

            System.Threading.Thread.Sleep(2000);

            cart.OpenCart();

            Assert.That(driver.PageSource.Contains("1")
                       || driver.PageSource.Contains("Sản phẩm"));
        }
    }
}
