using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    class BusData
    {
        public string StationName { get; set; }
        public string LineId { get; set; }
        public string Direction { get; set; }
        public string DestinationName { get; set; }
        public DateTime Timestamp { get; set; }
        public double TimeToStation { get; set; }

        public BusData() {; }

        public void print()
        {
            Console.WriteLine("{0}: Bus {1} ending at {3} arriving in {4:0} mins", StationName, LineId, Direction, DestinationName, TimeToStation/60);
        }

    }
}
