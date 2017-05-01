using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.BLL
{
    public class Route
    {
        public string Name { get; set; }

        public int Distance { get; set; }

        public Route GetRouteDetail(string routeInformation)
        {
            string nameRoute = routeInformation.Substring(0, 2);
            string distanceTextRoute = routeInformation.Substring(2, 1);

            var route = new Route();

            int distance = 0;
            if(int.TryParse(distanceTextRoute, out distance))
            {
                route.Name = nameRoute;
                route.Distance = distance;

                return route;
            }
            else
            {
                throw new ArgumentException("The route does not have the distance information");
            }
        }

        public List<Route> IdentifyRoutes(string trainTravel)
        {
            var routes = new List<Route>();

            int routeCount = 0;
            while(routeCount < trainTravel.Length - 1)
            {
                var route = new Route();

                route.Name = string.Concat(trainTravel[routeCount], trainTravel[routeCount + 1]);

                routes.Add(route);

                routeCount++;
            }

            return routes;
        }
    }
}
