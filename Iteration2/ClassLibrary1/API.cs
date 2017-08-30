using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Globalization;
using Library.Providers;

namespace Library
{
    public class API
    {
        public API()
        {
            OffLine = true;
        }

        public static String adressApiTransports = "http://data.metromobilite.fr/api/linesNear/json?x=";
        public static String adressApiLines = "https://data.metromobilite.fr/api/routers/default/index/routes?codes=";

        public Boolean OffLine { get; set; }

        public List<TransportComplete> GetAllTransportFromJson(Double lng, Double lat, Double dist)
        {
            String latString = lat.ToString(CultureInfo.InvariantCulture);
            String lngString = lng.ToString(CultureInfo.InvariantCulture);
            String json = GetRequestProvider().DoRequest((adressApiTransports + latString + "&y=" + lngString + "&dist=" + dist + "&details=true"));
            List<Transport> transports = JsonConvert.DeserializeObject<List<Transport>>(json);
            Utils util = new Utils();
            List<TransportComplete> nameStations = util.getUniqueStationAndAllLines(transports);

            return nameStations;
        }

        public Line GetAllLineFromJson(String line)
        {
            IRequest request = GetRequestProvider();
            String json = request.DoRequest(adressApiLines + line);
            List<Line> lineObject = JsonConvert.DeserializeObject<List<Line>>(json);
            return lineObject.First();
        }     
        
        private IRequest GetRequestProvider()
        {
            if (OffLine)
            {
                return new FakeRequest();
            }
            else
            {
                return new Request();
            }
        }
    }
}
