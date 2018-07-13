using System;


namespace BusBoard.Api
{
    public class BusData
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

        public string DataToString()
        {
            string output = $"Bus {LineId} ending at {DestinationName} arriving in {TimeToStation / 60:0} mins";
            return output;
        }

    }
}
