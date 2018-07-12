using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    class BusData
    {
        private string stationName, lineId, direction, destinationName;
        private DateTime timestamp;
        private double timeToStation;

        public BusData (string stationName, string lineId, string direction, string destinationName, DateTime timestamp, double timeToStation)
        {
            this.stationName = stationName;
            this.lineId = lineId;
            this.direction = direction;
            this.destinationName = destinationName;
            this.timestamp = timestamp;
            this.timeToStation = timeToStation;

        }

    }
}
