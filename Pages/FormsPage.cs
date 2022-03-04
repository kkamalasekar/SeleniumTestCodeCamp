using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    internal class FormsPage
    {
        private IWebDriver driver;

        public IWebElement Name_Input => driver.FindElement(By.Id("name"));
        public IWebElement Email_Input => driver.FindElement(By.Id("email"));
        public IWebElement State_Input => driver.FindElement(By.Id("state"));
        public IWebElement Agree_CheckBox => driver.FindElement(By.ClassName("v-input--selection-controls__ripple"));
        public IWebElement Submit_Button => driver.FindElement(By.XPath("//span[contains(text(),'submit')]"));
        public IWebElement PopUp => driver.FindElement(By.CssSelector(".popup-message"));

        public FormsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void SetName(string name)
        {
            Name_Input.SendKeys(name);
        }

        internal void ClickAgree()
        {
            Agree_CheckBox.Click();
        }

        internal void SetState(State state)
        {
            State_Input.SendKeys(state.ToString());
        }

        internal void SubmitForm()
        {
            Submit_Button.Click();
        }

        internal void SetEmail(string email)
        {
            Email_Input.SendKeys(email);
        }

        internal string GetFeedBackMessage()
        {
            IsPopupDisplayed();
            return PopUp.Text;
        }
        internal bool IsPopupDisplayed()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => PopUp.Displayed);
        }
    }
}