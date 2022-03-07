using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTest
{
    [TestClass]
    public class HomePageTest
    {
        IWebDriver driver;
        WebDriverWait wait;
        [Ignore]
        [TestMethod]
        public void VerifyHeaderText()
        {
            //Arrange

            //Act
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("submit")));
            var headerElements = driver.FindElements(By.TagName("h1"));

            IWebElement mainHeader = null;

            foreach (var headerElement in headerElements)
            {
                if (headerElement.Text == "Web Playground")
                {
                    mainHeader = headerElement;
                    break;
                }
            }

            //Assert
            Assert.IsTrue(mainHeader.Displayed);

        }

        [Ignore]
        [TestMethod]
        public void VerifyWelcomeText()
        {
            //Arrange
            const string Name = "Karthik";
            HomePage homePage = new HomePage(driver);

            //Act
            homePage.SubmitForeName(Name);
            

            //Assert
            Assert.AreEqual($"Hello {Name}", homePage.GetPopUpText());
        }

        [TestInitialize]
        public void SetUp()
        {
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
