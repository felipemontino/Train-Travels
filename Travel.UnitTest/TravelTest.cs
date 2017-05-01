using Travel.BLL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.UnitTest
{
    [TestFixture]
    public class TravelTest
    {
        private Travel travel;
        private List<string> graphRoute;

        [SetUp]
        private void SetUpRouteTest()
        {
            this.travel = new Travel();

            this.graphRoute = new List<string>();
            this.graphRoute.Add("AB5");
            this.graphRoute.Add("BC4");
            this.graphRoute.Add("CD8");
        }

        [Test]
        public void MustCalculateCorrectTravel()
        {
            var routeTravel = this.travel.CalculateDistance(this.graphRoute, "ABC");

            Assert.AreEqual(routeTravel.Distance, 9);
            Assert.AreEqual(routeTravel.Name, "ABC");
        }

        [Test]
        public void MustNotCalculateTravel()
        {
            Assert.Throws<ArgumentException>(
                 new TestDelegate(() =>
                 {
                     this.travel.CalculateDistance(this.graphRoute, string.Empty);
                 }));
        }

        [Test]
        public void MustCreateCorrectGraph()
        {
            var graphRoute = this.travel.GetGraph(this.graphRoute);

            Assert.AreEqual(graphRoute[0].Name, "AB");
            Assert.AreEqual(graphRoute[0].Distance, 5);
            
            Assert.AreEqual(graphRoute[2].Name, "CD");
            Assert.AreEqual(graphRoute[2].Distance, 8);
        }

        [Test]
        public void MustNotCreateGraph()
        {
            var graphRoute = this.travel.GetGraph(new List<string>());

            Assert.AreEqual(graphRoute.Count(), 0);
        }

        [Test]
        public void MustNotCalculateTravelRouteNotExists()
        {
            Assert.Throws<ArgumentException>(
                new TestDelegate(() =>
                {
                    this.travel.CalculateDistance(this.graphRoute, "ABZ");
                }));
        }
    }
}
