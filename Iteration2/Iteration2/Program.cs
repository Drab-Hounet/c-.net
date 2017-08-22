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
            string json = api.GetJSonFromApi();

            List<Transport> transports = JsonConvert.DeserializeObject<List<Transport>>(json);

            Utils util = new Utils();
            List<Transport> nameStations = util.getUniqueStation(transports);

            //foreach (Transport t in nameStations)
            //{
            //    Console.WriteLine(t.Name);
            //}


            //get namestation unique
            //foreach (Transport transport in transports)
            //{
            //    Boolean alreadyPresent = false;
            //    foreach (Transport nameStation in nameStations)
            //    {
            //        if (transport.Name.Equals(nameStation.Name))
            //        {
            //            alreadyPresent = true;
            //        }
            //    }
            //    if (!alreadyPresent)
            //    {
            //        nameStations.Add(transport);
            //    }
            //}

            List<Transport> listOrderByStation = new List<Transport>();
            List<List<Transport>> listAllDistinct = new List<List<Transport>>();

            foreach (Transport nameStation in nameStations)
            {
                Console.WriteLine(nameStation.Name);
                List<String> lines = new List<string>();
                foreach (Transport transport in transports)
                {
                    if (transport.Name.Equals(nameStation.Name))
                    {
                        foreach (String line in transport.Lines)
                        {
                            if (!lines.Contains(line))
                            {
                                lines.Add(line);
                            }
                        }
                    }
                }

                Transport completeTransport = new Transport();
                completeTransport.Id = nameStation.Id;
                completeTransport.Name = nameStation.Name;
                completeTransport.Lon = nameStation.Lon;
                completeTransport.Lat = nameStation.Lat;
                completeTransport.Lines = lines;

                listOrderByStation.Add(completeTransport);
            }

            foreach(Transport transport in listOrderByStation)
            {
                transport.DisplayAll();
            }

        }
    }
}
