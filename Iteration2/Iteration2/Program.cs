using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            API api = new API();
            List<TransportComplete> transports = api.GetAllTransportFromJson(5.726763010025024, 45.18528852941346, 700);

            foreach(TransportComplete transport in transports)
            {
                Console.WriteLine(  "\nNAME : " + transport.Name +
                                    "\nCOORDONNEE : " + transport.Lon + " - " + transport.Lat +
                                    "\nLIGNE : ");

                foreach (Line line in transport.LinesDetails)
                {
                    Console.WriteLine(  line.longName + "\n" +
                                        line.mode + "\n" +
                                        line.type + "\n" +
                                        "-------------------\n");
                }
            }

            Console.ReadLine();
        }
    }
}
