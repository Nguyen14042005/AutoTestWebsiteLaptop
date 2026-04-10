using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Pages
{
    public class OrderPage : BasePage
    {
        public OrderPage(IWebDriver driver) : base(driver) { }

     
        By menuUser = By.ClassName("header-top__login");
        By btnMyOrders = By.XPath("//a[contains(text(),'Đơn hàng')]");

        
        By orderList = By.ClassName("order-item");

    
        By btnDetail = By.XPath("//a[contains(text(),'Chi tiết')]");

    
        By btnCancel = By.XPath("//a[contains(text(),'Hủy')]");

        
        By btnReOrder = By.XPath("//a[contains(text(),'Mua lại')]");

        public void OpenMyOrders()
        {
            Hover(menuUser);
            System.Threading.Thread.Sleep(1000);

            WaitVisible(btnMyOrders);

            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", driver.FindElement(btnMyOrders));

            System.Threading.Thread.Sleep(2000);
        }

        public bool HasOrders()
        {
            return driver.PageSource.Contains("Đơn hàng");
        }

        public void ClickDetail()
        {
            Click(btnDetail);
        }

        public void CancelOrder()
        {
            try
            {
                Click(btnCancel);
            }
            catch { }
        }

        public void ReOrder()
        {
            try
            {
                Click(btnReOrder);
            }
            catch { }
        }

        public string GetText()
        {
            return driver.PageSource;
        }
    }
}
