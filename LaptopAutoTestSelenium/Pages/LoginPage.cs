using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        // 🔥 MENU
        By menuUser = By.ClassName("header-top__login");
        By btnLogin = By.XPath("//a[contains(text(),'Đăng nhập')]");

        // 🔥 FORM LOGIN
        By email = By.Id("txtTenDangNhap");
        By password = By.Id("txtMatKhau");
        By btnSubmit = By.XPath("//button[contains(text(),'Đăng nhập')]");
        By errorMessage = By.XPath("//*[contains(text(),'sai') or contains(text(),'không đúng')]");

        By btnLogout = By.XPath("//a[contains(text(),'Đăng xuất') or contains(text(),'Logout')]");
        By btnLoginText = By.Id("TaiKhoanDangNhap"); // text hiển thị "Đăng nhập"

        public void OpenLoginForm()
        {
            Hover(menuUser);
            System.Threading.Thread.Sleep(1000);

            WaitVisible(btnLogin);

            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", driver.FindElement(btnLogin));

            System.Threading.Thread.Sleep(1500);

            WaitVisible(email);
        }

        public void Login(string mail, string pass)
        {
            WaitVisible(email);

            // 🔥 click vào ô trước khi nhập
            Click(email);
            SendKey(email, mail);

            Click(password);
            SendKey(password, pass);

            Click(btnSubmit);
        }

        public string GetMessage()
        {
            return driver.PageSource;
        }

        public bool IsLoginFail()
        {
            try
            {
                return driver.FindElement(errorMessage).Displayed;
            }
            catch
            {
                return false;
            }
        }


        public void Logout()
        {
            Hover(menuUser);
            System.Threading.Thread.Sleep(1000);

            WaitVisible(btnLogout);

            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", driver.FindElement(btnLogout));
        }

        public bool IsLogoutSuccess()
        {
            return driver.FindElement(btnLoginText).Text.Contains("Đăng nhập");
        }
    }
}
