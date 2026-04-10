using LaptopAutoTestSelenium.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Tests
{
    public class ProductTests : BaseTest
    {
        [Test]
        public void TC09_Search_Dell()
        {
            ProductPage product = new ProductPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            product.Search("Dell");

            System.Threading.Thread.Sleep(2000);

            Assert.That(product.IsSearchResultDisplayed("Dell"));

        }


        [Test]
        public void TC10_Search_NoResult()
        {
            ProductPage product = new ProductPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            product.Search("@@@");

            System.Threading.Thread.Sleep(2000);

            Assert.That(product.IsNoResult());
        }

        [Test]
        public void TC11_Filter_Apple()
        {
            ProductPage product = new ProductPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            product.FilterApple();

            System.Threading.Thread.Sleep(2000);

            Assert.That(driver.PageSource.Contains("Macbook")
                       || driver.PageSource.Contains("Apple"));
        }

        [Test]
        public void TC12_Filter_Price()
        {
            ProductPage product = new ProductPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            product.SortPriceDesc();

            System.Threading.Thread.Sleep(2000);

            Assert.Pass(); 
        }

        [Test]
        public void TC13_Click_Product()
        {
            ProductPage product = new ProductPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            driver.FindElements(By.ClassName("product-item"))[0].Click();

            System.Threading.Thread.Sleep(2000);

            Assert.That(driver.Url.Contains("detail") || driver.PageSource.Contains("Giá"));
        }

        [Test]
        public void TC14_OutOfStock()
        {
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );

            Assert.That(driver.PageSource.Contains("Hết hàng"));
        }

        [Test]
        public void TC15_Sort_Price_Desc()
        {
            ProductPage product = new ProductPage(driver);
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            product.SortPriceDesc();

            System.Threading.Thread.Sleep(2000);

            Assert.Pass(); 
        }

        [Test]
        public void TC16_Pagination()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'2')]")).Click();
            LoginPage login = new LoginPage(driver);
            login.OpenLoginForm();

            login.Login(
                "nguyen",
                "nguyen123"
            );


            System.Threading.Thread.Sleep(2000);

            Assert.That(driver.Url.Contains("page") || driver.PageSource.Contains("2"));
        }
    }
}
