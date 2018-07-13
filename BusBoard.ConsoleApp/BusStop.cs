using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    class BusStop
    {
        public string stopId;
        public double distance;

        public BusStop(string ID, double dist)
        {
            stopId = ID;
            distance = dist;
        }
    }
}
