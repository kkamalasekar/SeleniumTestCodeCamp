using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    internal class Toolbar
    {
        private IWebDriver driver;

        public Toolbar(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ToolBar => driver.FindElement(By.ClassName("v-toolbar__items"));

        internal void NavigateToPage(string PageName)
        {
            try
            {
                IWebElement Page = ToolBar.FindElement(By.CssSelector($"[aria-label=\"{PageName}\"]"));
                _ = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => Page.Displayed);
                Page.Click();
            }
            catch(NoSuchElementException) 
            {
                throw new NotFoundException($"Page {PageName} not found");
            }
        }
    }
}