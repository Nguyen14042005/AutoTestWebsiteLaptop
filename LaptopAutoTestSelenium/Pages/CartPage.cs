using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        // 🔥 PRODUCT
        By firstProduct = By.ClassName("product-item");

        // 🔥 DETAIL
        By btnAddToCart = By.XPath("//button[contains(text(),'Thêm vào giỏ')]");

        // 🔥 CART
        By cartIcon = By.XPath("//a[contains(@href,'cart')]");
        By quantity = By.XPath("//input[@type='number']");
        By btnUpdate = By.XPath("//button[contains(text(),'Cập nhật')]");
        By btnDelete = By.XPath("//a[contains(text(),'Xóa')]");
        By btnClear = By.XPath("//a[contains(text(),'Xóa tất cả')]");
        By btnContinue = By.XPath("//a[contains(text(),'Tiếp tục')]");

        public void OpenFirstProduct()
        {
            driver.FindElements(firstProduct)[0].Click();
        }

        public void AddToCart()
        {
            Click(btnAddToCart);
        }

        public void OpenCart()
        {
            Click(cartIcon);
        }

        public void UpdateQuantity(string value)
        {
            SendKey(quantity, value);
            Click(btnUpdate);
        }

        public void DeleteItem()
        {
            Click(btnDelete);
        }

        public void ClearCart()
        {
            Click(btnClear);
        }

        public void ContinueShopping()
        {
            Click(btnContinue);
        }

        public string GetPageText()
        {
            return driver.PageSource;
        }
    }
}
