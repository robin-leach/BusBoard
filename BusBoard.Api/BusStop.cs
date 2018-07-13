

namespace BusBoard.Api
{
    public class BusStop
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
