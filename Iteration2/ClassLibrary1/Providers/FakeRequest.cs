using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Providers
{
    class FakeRequest : IRequest
    {
        public string DoRequest(string adressApi)
        {
            if (adressApi.Contains(API.adressApiLines))
            {
                return @"[{""id"": ""SEM: 12"",""shortName"": ""12"",""longName"": ""Fontanil Cornillon"", ""color"": ""00868b"",""textColor"": ""FFFFFF"",""mode"": ""BUS"",""type"": ""PROXIMO""}]";
            }
            else if (adressApi.Contains(API.adressApiTransports))
            {
                return @"[{id: ""C38: 12818"",name: ""GRENOBLE, Drab STATION"",lon: 5.71403,lat: 45.17338,lines: [""C38: EXP3""]}]";
            }

            return string.Empty;
        }
    }
}
