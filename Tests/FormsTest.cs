using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    [TestClass]
    public class FormsTest
    {
        ChromeDriver driver;
        WebDriverWait wait;

        [TestMethod]
        public void VerifyFeedBackMessage()
        {
            //Arrange
            string Name = "Karthik";
            string Email = "Karthik@gmail.com";
            State State = State.SA;

            FormsPage formsPage = new FormsPage(driver);
            Toolbar toolbarPage = new Toolbar(driver);

            //Act
            toolbarPage.NavigateToPage("forms");
            formsPage.SetName(Name);
            formsPage.SetEmail(Email);
            formsPage.SetState(State);
            formsPage.ClickAgree();
            formsPage.SubmitForm();

            //Assert
            Assert.AreEqual(expected: $"Thanks for your feedback {Name}", actual: formsPage.GetFeedBackMessage());
        }

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://d18u5zoaatmpxx.cloudfront.net/#/");
        }
        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
