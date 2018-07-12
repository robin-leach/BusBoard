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
        /*
        public BusData (string stationName, string lineId, string direction, string destinationName, DateTime timestamp, double timeToStation)
        {
            this.StationName = stationName;
            this.lineId = lineId;
            this.direction = direction;
            this.destinationName = destinationName;
            this.timestamp = timestamp;
            this.timeToStation = timeToStation;

        }*/

        public void print()
        {
            Console.WriteLine(StationName + LineId + Direction + DestinationName + Timestamp + TimeToStation);
        }
    }
}
