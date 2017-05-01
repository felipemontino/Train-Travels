using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.BLL
{
    public class Travel
    {
        public List<Route> GetGraph(List<string> strGraphs)
        {
            var graphRoutes = new List<Route>();
            var route = new Route();

            foreach(var graph in strGraphs)
            {
                var routeGraph = route.GetRouteDetail(graph);

                graphRoutes.Add(routeGraph);
            }

            return graphRoutes;
        }

        public Route CalculateDistance(List<string> strGraphs, string trainTravel)
        {
            var route = new Route();

            var graphRoutes = this.GetGraph(strGraphs);

            if(String.IsNullOrWhiteSpace(trainTravel))
            {
                throw new ArgumentException("The train travel was not encountered");
            }

            var trainTravelRoutes = route.IdentifyRoutes(trainTravel);

            foreach(var routeTravel in trainTravelRoutes)
            {
                var routeGrafh = graphRoutes.FirstOrDefault(gr => gr.Name.ToLower().Equals(routeTravel.Name.ToLower()));

                if(routeGrafh != null)
                {
                    routeTravel.Distance = routeGrafh.Distance;
                }
                else
                {
                    Console.WriteLine("NO SUCH ROUTE");
                    throw new ArgumentException("NO SUCH ROUTE");
                }
            }

            return new Route()
            {
                Name = trainTravel,
                Distance = trainTravelRoutes.Sum(ttr => ttr.Distance)
            };
        }
    }
}
