using Travel.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel
{
    class Program
    {
        static void Main(string[] args)
        {
            var graphRoute = new List<string>();

            graphRoute.Add("AB5");
            graphRoute.Add("BC4");
            graphRoute.Add("CD8");
            graphRoute.Add("DC8");
            graphRoute.Add("DE6");
            graphRoute.Add("AD5");
            graphRoute.Add("CE2");
            graphRoute.Add("EB3");
            graphRoute.Add("AE7");
            
            var trainTravel = Console.ReadLine();

            var routeTravel = new Travel().CalculateDistance(graphRoute, trainTravel);

            Console.WriteLine(string.Format("Travel: {0} - Distance {1}", routeTravel.Name, routeTravel.Distance));

            Console.ReadKey();
        }
    }
}
