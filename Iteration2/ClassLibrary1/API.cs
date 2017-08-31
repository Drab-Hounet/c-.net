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
        private IRequest mRequest;
        private bool mOffline;

        public static String adressApiTransports = "http://data.metromobilite.fr/api/linesNear/json?x=";
        public static String adressApiLines = "https://data.metromobilite.fr/api/routers/default/index/routes?codes=";

        public Boolean OffLine
        {
            get
            {
                return mOffline;
            }

            set
            {
                if (value != mOffline)
                {
                    mOffline = value;
                    mRequest = GetRequestProvider();
                }                
            }
        }

        public API()
        {
            OffLine = false;
            mRequest = GetRequestProvider();
        }

        internal API(IRequest request)
        {
            mRequest = request;
        }
        
        public List<TransportComplete> GetAllTransportFromJson(Double lng, Double lat, Double dist)
        {
            String latString = lat.ToString(CultureInfo.InvariantCulture);
            String lngString = lng.ToString(CultureInfo.InvariantCulture);
            String json = mRequest.DoRequest((adressApiTransports + latString + "&y=" + lngString + "&dist=" + dist + "&details=true"));
            List<Transport> transports = JsonConvert.DeserializeObject<List<Transport>>(json);
            Utils util = new Utils();
            List<TransportComplete> nameStations = util.getUniqueStationAndAllLines(mRequest, transports);

            return nameStations;
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
