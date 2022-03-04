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

        public IWebElement Forms { get => driver.FindElement(By.ClassName("v-toolbar__items")).FindElement(By.CssSelector("[aria-label=\"forms\"]")); }
        public IWebElement Planets { get => driver.FindElement(By.ClassName("v-toolbar__items")).FindElement(By.CssSelector("[aria-label=\"planets\"]")); }

        internal void NavigateToFormsPage()
        {
            _ = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => Forms.Displayed);
            Forms.Click();

        }internal void NavigateToPlanetsPage()
        {
            _ = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => Planets.Displayed);
            Planets.Click();
        }
    }
}