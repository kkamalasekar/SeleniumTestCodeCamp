using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumTest.Models
{
    class Planet
    {

        private IWebElement planet;

        public Planet(IWebElement planet)
        {
            this.planet = planet;
        }

        public string PlanetName => this.planet.FindElement(By.ClassName("name")).Text;
        public IWebElement ExploreButton => this.planet.FindElement(By.CssSelector("button[type='button']"));

        public long Distance
        {
            get
            {
                var DistanceText = planet.FindElement(By.ClassName("distance")).Text;
                long kms = DistanceToKms(DistanceText);
                return kms;
            }
        }

        private long DistanceToKms(string distanceText)
        {
            distanceText = distanceText.Split(" ")[0];
            return long.Parse(distanceText, style: NumberStyles.AllowThousands);
        }
    }
}
