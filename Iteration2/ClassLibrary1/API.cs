using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Globalization;

namespace Library
{
    public class API
    {
        public String adressApi { get; set; }

        public String adressApiTransports = "http://data.metromobilite.fr/api/linesNear/json?x=";
        public String adressApiLines =      "https://data.metromobilite.fr/api/routers/default/index/routes?codes=";

        public List<TransportComplete> GetAllTransportFromJson(Double lng, Double lat, Double dist)
        {

            String latString = lat.ToString(CultureInfo.InvariantCulture);
            String lngString = lng.ToString(CultureInfo.InvariantCulture);
            String json = getJson(adressApiTransports + latString + "&y=" + lngString + "&dist=" + dist + "&details=true");

            List <Transport> transports = JsonConvert.DeserializeObject<List<Transport>>(json);
            Utils util = new Utils();
            List<TransportComplete> nameStations = util.getUniqueStationAndAllLines(transports);

            return nameStations;
        }

        public Line GetAllLineFromJson(String line)
        {
            String json = getJson(adressApiLines + line);
            List<Line> lineObject = JsonConvert.DeserializeObject<List<Line>>(json);
            return lineObject.First();
        }

        private String getJson(String adressApi)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            WebRequest request = WebRequest.Create(adressApi);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String json = reader.ReadToEnd();
            reader.Close();
            response.Close();
            
            return json;
        }
    }
}
