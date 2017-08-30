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
                return "";
            }
            else if (adressApi.Contains(API.adressApiTransports))
            {
                return @"[{id: ""C38: 12818"",name: ""GRENOBLE, ALLIES"",lon: 5.71403,lat: 45.17338,lines: [""C38: EXP3"",""C38: 4110"",""C38: 4100"",""C38: 4101"",""C38: 3000"",""C38: 4500""]}]";
            }

            return string.Empty;
        }
    }
}
