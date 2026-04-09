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

        By email = By.Id("email");
        By password = By.Id("password");
        By btnLogin = By.Id("loginBtn");
        By error = By.Id("error");

        public void Login(string mail, string pass)
        {
            SendKey(email, mail);
            SendKey(password, pass);
            Click(btnLogin);
        }

        public string GetError()
        {
            return WaitElement(error).Text;
        }
    }
}
