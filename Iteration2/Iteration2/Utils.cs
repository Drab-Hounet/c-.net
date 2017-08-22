using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration2
{
    class Utils
    {
        public List<Transport> getUniqueStation(List<Transport> transports)
        {
            List<Transport> nameStations = new List<Transport>();
            foreach (Transport transport in transports)
            {
                Boolean alreadyPresent = false;
                foreach (Transport nameStation in nameStations)
                {
                    if (transport.Name.Equals(nameStation.Name))
                    {
                        alreadyPresent = true;
                    }
                }
                if (!alreadyPresent)
                {
                    nameStations.Add(transport);
                }
            }
            return nameStations;
        }

        public List<Transport> getUniqueStationAndAllLines(List<Transport> transports)
        {
            List<Transport> listOrderByStation = new List<Transport>();
            List<Transport> nameStations = getUniqueStation(transports);
            foreach (Transport nameStation in nameStations)
            {
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
            return listOrderByStation;
        }
    }
}
