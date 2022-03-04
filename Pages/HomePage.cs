using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    internal class HomePage
    {
        public IWebDriver driver;


        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement SubmitButton => driver.FindElement(By.Id("submit"));

        public IWebElement ForeName_Input => driver.FindElement(By.Id("forename"));

        public IWebElement PopUp => driver.FindElement(By.CssSelector(".popup-message"));


        internal void SubmitForeName(string name)
        {
            ForeName_Input.SendKeys(name);
            SubmitButton.Click();
        }

        internal string GetPopUpText()
        {
            IsPopupDisplayed();
            return PopUp.Text;
        }

        internal bool IsPopupDisplayed()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(d => PopUp.Displayed);
        }
    }
}