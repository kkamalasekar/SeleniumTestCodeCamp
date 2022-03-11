using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.Models;

namespace SeleniumTest
{
    [TestClass]
    public class PlanetsTest
    {
        IWebDriver driver;
        WebDriverWait wait;
        [TestMethod]
        public void VerifyPlanetsFeedBackMessage()
        {
            //Arrange
            PlanetsPage planetsPage = new PlanetsPage(driver);
            Toolbar toolbarPage = new Toolbar(driver);
            string PlanetName = "Earth";

            //Act
            //toolbarPage.NavigateToPlanetsPage();
            toolbarPage.NavigateToPage("planets");
            Planet Earth = planetsPage.GetPlanet(p => p.PlanetName == PlanetName);
            planetsPage.ClickExploreButton(Earth);

            //Assert
            Assert.AreEqual(expected: $"Exploring {PlanetName}",
                            actual: planetsPage.GetPopupMessage());
        }
        [TestMethod]
        public void VerifyPlanetsDistance()
        {
            //Arrange
            PlanetsPage planetsPage = new PlanetsPage(driver);
            Toolbar toolbarPage = new Toolbar(driver);
            long PlanetDistance = 149600000;

            //Act
            //toolbarPage.NavigateToPlanetsPage();
            toolbarPage.NavigateToPage("planets");
            Planet Earth = planetsPage.GetPlanet(p => p.Distance == PlanetDistance);
            planetsPage.ClickExploreButton(Earth);

            //Assert
            Assert.AreEqual(expected: "Earth",
                            actual: Earth.PlanetName);
        }

        [TestInitialize]
        public void SetUp()
        {
            //driver = new ChromeDriver();
            DriverOptions Options = new ChromeOptions();
            if (OperatingSystem.IsWindows())
            {
                driver = new RemoteWebDriver(remoteAddress: new Uri("http://localhost:4444/wd/hub"), Options);
            }
            else if (OperatingSystem.IsOSPlatform("Linux"))
            {
                driver = new RemoteWebDriver(remoteAddress: new Uri("http://selenium-hub:4444/wd/hub"), Options);
            }
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
