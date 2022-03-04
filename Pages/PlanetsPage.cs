using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.Models;

namespace SeleniumTest
{
    internal class PlanetsPage
    {
        private IWebDriver driver;

        public PlanetsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IEnumerable<IWebElement> Planets => driver.FindElements(By.ClassName("planet"));

        public IWebElement PopUp => driver.FindElement(By.CssSelector(".popup-message"));

        internal void ClickExploreButton(Planet planet)
        {
            planet.ExploreButton.Click();
        }
        public IEnumerable<Planet> GetPlanets()
        {
            foreach (var planet in Planets)
            {
                yield return new Planet(planet);
            }
        }

        /*public Planet GetPlanetOldCopy(string planetName)
        {
            foreach (var planet in GetPlanets())
            {
                if (planet.PlanetName == planetName)
                {
                    return planet;
                }
            }
            throw new NotFoundException($"{planetName} not found.");
        }*/

        public Planet GetPlanet(Predicate<Planet> matchStrategy)
        {
            foreach (var planet in GetPlanets())
            {
                if (matchStrategy.Invoke(planet))
                {
                    return planet;
                }
            }
            throw new NotFoundException($"Could not find Planet.");
        }

        internal string GetPopupMessage()
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