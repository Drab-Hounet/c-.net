using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Utils
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

        public List<TransportComplete> getUniqueStationAndAllLines(List<Transport> transports)
        {
            List<TransportComplete> listOrderByStation = new List<TransportComplete>();
            List<Transport> nameStations = getUniqueStation(transports);
            foreach (Transport nameStation in nameStations)
            {
                List<String> lines = new List<string>();
                List<Line> linesDetails = new List<Line>();
                foreach (Transport transport in transports)
                {
                    if (transport.Name.Equals(nameStation.Name))
                    {
                        foreach (String line in transport.Lines)
                        {
                            if (!lines.Contains(line))
                            {
                                API apiLine = new API();
                                Line lineObject = apiLine.GetAllLineFromJson(line);
                                linesDetails.Add(lineObject);
                                lines.Add(line);
                            }
                        }
                    }
                }
                TransportComplete completeTransport = new TransportComplete();
                completeTransport.Id = nameStation.Id;
                completeTransport.Name = nameStation.Name;
                completeTransport.Lon = nameStation.Lon;
                completeTransport.Lat = nameStation.Lat;
                completeTransport.LinesDetails = linesDetails;

                listOrderByStation.Add(completeTransport);
            }
            return listOrderByStation;
        }

    }
}
