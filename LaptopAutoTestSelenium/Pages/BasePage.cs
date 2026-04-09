using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace LaptopAutoTestSelenium.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver _driver)
        {
            driver = _driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement WaitElement(By by)
        {
            return wait.Until(d => d.FindElement(by));
        }

        // 🔥 FIX CLICK (tránh bị che / overlay)
        protected void Click(By by)
        {
            var element = WaitElement(by);

            wait.Until(d => element.Displayed && element.Enabled);

            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", element);
        }

        // 🔥 FIX NHẬP LIỆU (QUAN TRỌNG NHẤT)
        protected void SendKey(By by, string text)
        {
            var element = wait.Until(d =>
            {
                var e = d.FindElement(by);
                return (e.Displayed && e.Enabled) ? e : null;
            });

            element.Click();   // focus vào input
            element.Clear();

            try
            {
                element.SendKeys(text);
            }
            catch
            {
                // fallback nếu SendKeys fail (popup/web động)
                ((IJavaScriptExecutor)driver)
                    .ExecuteScript("arguments[0].value='" + text + "';", element);
            }
        }

        // 🔥 HOVER (cho dropdown menu)
        protected void Hover(By by)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(WaitElement(by)).Perform();
        }

        // 🔥 WAIT HIỆN
        protected void WaitVisible(By by)
        {
            wait.Until(d => d.FindElement(by).Displayed);
        }
    }
}
