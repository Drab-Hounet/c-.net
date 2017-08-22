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
    }
}
