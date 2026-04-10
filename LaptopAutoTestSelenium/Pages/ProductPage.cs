using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        // 🔥 SEARCH
        By txtSearch = By.XPath("//input[@type='text']");
        By productList = By.ClassName("product-item");

        // 🔥 FILTER / SORT (có thể phải chỉnh lại theo web bạn)
        By filterApple = By.XPath("//a[contains(text(),'Apple')]");
        By sortPriceDesc = By.XPath("//a[contains(text(),'Giá giảm dần')]");

        public void Search(string keyword)
        {
            SendKey(txtSearch, keyword);
            driver.FindElement(txtSearch).SendKeys(Keys.Enter);
        }

        public bool IsSearchResultDisplayed(string keyword)
        {
            return driver.PageSource.ToLower().Contains(keyword.ToLower());
        }

        public bool IsNoResult()
        {
            return driver.PageSource.Contains("Không tìm thấy");
        }

        public void FilterApple()
        {
            Click(filterApple);
        }

        public void SortPriceDesc()
        {
            Click(sortPriceDesc);
        }
    }
}
