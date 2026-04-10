using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Pages
{
    public class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) : base(driver) { }

        
        By btnCheckout = By.XPath("//a[contains(text(),'Thanh toán')]");

        
        By phone = By.XPath("//input[@placeholder='Số điện thoại']");
        By address = By.XPath("//textarea");

        
        By txtCoupon = By.XPath("//input[contains(@placeholder,'coupon') or contains(@placeholder,'mã')]");
        By btnApply = By.XPath("//button[contains(text(),'Áp dụng')]");

        
        By btnSubmit = By.XPath("//button[contains(text(),'Đặt hàng')]");

        public void OpenCheckout()
        {
            Click(btnCheckout);
            System.Threading.Thread.Sleep(2000);
        }

        public void FillInfo(string phoneNum, string addr)
        {
            try
            {
                SendKey(phone, phoneNum);
                SendKey(address, addr);
            }
            catch { }
        }

        public void ApplyCoupon(string code)
        {
            try
            {
                SendKey(txtCoupon, code);
                Click(btnApply);
            }
            catch { }
        }

        public void Submit()
        {
            Click(btnSubmit);
        }

        public string GetText()
        {
            return driver.PageSource;
        }

        public bool IsCheckoutSuccess()
        {
            return driver.PageSource.Contains("thành công")
                || driver.PageSource.Contains("Đặt hàng thành công");
        }

        public bool IsErrorMessage()
        {
            return driver.PageSource.Contains("lỗi")
                || driver.PageSource.Contains("không hợp lệ")
                || driver.PageSource.Contains("bắt buộc");
        }

        public bool IsCouponApplied()
        {
            return driver.PageSource.Contains("giảm")
                || driver.PageSource.Contains("coupon");
        }
    }
}
