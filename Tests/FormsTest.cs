using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    [TestClass]
    public class FormsTest
    {
        IWebDriver driver;
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
            //driver = new ChromeDriver();
            DriverOptions Options = new ChromeOptions();
            driver = new RemoteWebDriver(remoteAddress: new Uri("http://localhost:4444/wd/hub"), Options);
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
