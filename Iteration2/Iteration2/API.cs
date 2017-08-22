using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace Iteration2
{
    class API
    {
        public string adressApi { get; set; }

        public API(String adressApi)
        {
            this.adressApi = adressApi;
        }

        public List<Transport> GetJSonFromApiTransport()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            WebRequest request = WebRequest.Create(adressApi);

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string json = reader.ReadToEnd();
            reader.Close();
            response.Close();

            List<Transport> transports = JsonConvert.DeserializeObject<List<Transport>>(json);

            return transports;
        }

        public List<Line> GetJSonFromApiLine()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            WebRequest request = WebRequest.Create(adressApi);

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string json = reader.ReadToEnd();
            reader.Close();
            response.Close();

            List<Line> line = JsonConvert.DeserializeObject<List<Line>>(json);

            return line;
        }
    }
}
