﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration2
{
    class Transport
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public List<string> Lines { get; set; }

        public void DisplayAll()
        {
            Console.WriteLine("ID : " + Id);
            Console.WriteLine("NAME : " + Name);
            Console.WriteLine("COORDONNEE : " + Lon + " - " + Lat);
            Console.WriteLine("LINES : ");

            foreach (String line in Lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
