using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Transport
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public List<string> Lines { get; set; }

        public String DisplayAll()
        {
            String detailTransport = 
                "\nNAME : " + Name +
                "\nCOORDONNEE : " + Lon + " - " + Lat + 
                "\nLIGNE : ";

            foreach (String line in Lines)
            {
                API api1 = new API("https://data.metromobilite.fr/api/routers/default/index/routes?codes=" + line);
                List<Line> lines = api1.GetJSonFromApiLine();
                Line lineObject = lines.First();

                detailTransport += "\n" + lineObject.longName +  "\n" +
                                   lineObject.mode + "\n" + 
                                   lineObject.type + "\n" + 
                                   "-------------------\n";
            }
            return detailTransport;

        }
    }
}
