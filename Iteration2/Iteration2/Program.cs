using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Iteration2
{
    class Program
    {
        static void Main(string[] args)
        {
            API api = new API("http://data.metromobilite.fr/api/linesNear/json?x=5.726763010025024&y=45.18528852941346&dist=700&details=true");
            List<Transport> transports = api.GetJSonFromApi();

            Utils util = new Utils();

            List<Transport> nameStations = util.getUniqueStationAndAllLines(transports);

            foreach(Transport transport in nameStations)
            {
                Console.WriteLine(transport.DisplayAll());
            }
        }
    }
}
