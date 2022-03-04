using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.Models;

namespace SeleniumTest
{
    [TestClass]
    public class PlanetsTest
    {
        ChromeDriver driver;
        WebDriverWait wait;

        [TestMethod]
        public void VerifyPlanetsFeedBackMessage()
        {
            //Arrange
            PlanetsPage planetsPage = new PlanetsPage(driver);
            Toolbar toolbarPage = new Toolbar(driver);
            string PlanetName = "Earth";

            //Act
            toolbarPage.NavigateToPlanetsPage();
            Planet Earth = planetsPage.GetPlanet(p => p.PlanetName == PlanetName);
            planetsPage.ClickExploreButton(Earth);

            //Assert
            Assert.AreEqual(expected: $"Exploring {PlanetName}",
                            actual: planetsPage.GetPopupMessage());
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
