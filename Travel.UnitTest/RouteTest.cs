using Travel.BLL;
using NUnit.Framework;
using System;

namespace Travel.UnitTest
{
    [TestFixture]
    public class RouteTest
    {
        private Route route;

        [SetUp]
        private void SetUpRouteTest()
        {
            this.route = new Route();
        }

        [Test]
        public void MustCreateCorrectRoute()
        {
            var route = this.route.GetRouteDetail("AB5");

            Assert.AreEqual(route.Name, "AB");
            Assert.AreEqual(route.Distance, "5");
        }

        [Test]
        public void MustNotCreateCorrectRoute()
        {
            Assert.Throws<ArgumentException>(
                  new TestDelegate(() => 
                  {
                      this.route.GetRouteDetail("DE"); 
                  }));
        }

        [Test]
        public void MustIdentify2Routes()
        {
            var routes = this.route.IdentifyRoutes("EDF");

            Assert.AreEqual(routes[0].Name, "ED");
            Assert.AreEqual(routes[1].Name, "DF");
        }

        [Test]
        public void MustNotIdentifyAnyRoute()
        {
            var routes = this.route.IdentifyRoutes(string.Empty);

            Assert.AreEqual(routes.Count, 0);
        }
    }
}
