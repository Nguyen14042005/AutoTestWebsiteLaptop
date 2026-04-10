using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Pages
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver driver) : base(driver) { }

 
        By menuUser = By.ClassName("header-top__login");
        By btnRegister = By.CssSelector("a[onclick*='DangKyTK']");

     
        By email = By.XPath("//input[@placeholder='Email...']");
        By phone = By.XPath("//input[@placeholder='Số điện thoại']");
        By username = By.XPath("//input[@placeholder='Tài khoản']");
        By password = By.XPath("//input[@placeholder='Mật khẩu từ 6 đến 32 ký tự']");
        By confirm = By.XPath("(//input[@placeholder='Mật khẩu từ 6 đến 32 ký tự'])[2]");
        By fullname = By.XPath("//input[@placeholder='Nhập họ tên']");

     
        By dob = By.XPath("//label[contains(text(),'NGÀY SINH')]/following::input[1]");

        By address = By.XPath("//textarea");

        By btnSubmit = By.XPath("//button[contains(text(),'Đăng ký')]");

        public void OpenRegisterForm()
        {
            Hover(menuUser);
            System.Threading.Thread.Sleep(1000);

            WaitVisible(btnRegister);

            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", driver.FindElement(btnRegister));

            System.Threading.Thread.Sleep(1500);

            WaitVisible(email);
        }

        public void Register(string mail, string phoneNum, string user,
                             string pass, string cf, string name, string addr)
        {
            SendKey(email, mail);
            SendKey(phone, phoneNum);
            SendKey(username, user);
            SendKey(password, pass);
            SendKey(confirm, cf);
            SendKey(fullname, name);

            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].value='01/01/2000';", driver.FindElement(dob));

            SendKey(address, addr);

            Click(btnSubmit);
        }

        public bool IsRegisterSuccess()
        {
            return driver.PageSource.Contains("thành công")
                || driver.PageSource.Contains("Đăng ký thành công");
        }

        public string GetErrorMessage()
        {
            return driver.PageSource;
        }
    }
}
