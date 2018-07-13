using BusBoard.Api;
using System;
using System.Collections.Generic;

namespace BusBoard.Web.ViewModels
{
    public class BusInfo
    {
        public BusInfo(string postCode)
        {
            PostCode = postCode;

            string[] Location = API.GetLocation(PostCode);
            string latitude = Location[0];
            string longitude = Location[1];
            List<BusStop> nearest_stops = API.GetNearestStop(latitude, longitude);
            output_info = new List<string>();
            Data = new List<List<BusData>>();
            printable_data = new List<string>();
            foreach (var stop in nearest_stops)
            {
                List<BusData> BusList = API.GetData(stop.stopId);
                string bus_info_message = BusList[0].StationName + " is " + Math.Round(stop.distance, 0) + "m away";
                output_info.Add(bus_info_message);
                BusList = API.SortByTime(BusList);
                Data.Add(BusList);
                foreach (var bus in BusList)
                {
                    string bus_info_data = bus.DataToString();
                    printable_data.Add(bus_info_data);
                }
            }


        }

        public string PostCode { get; set; }
        public List<string> output_info;
        public List<List<BusData>> Data;
        public List<string> printable_data;
    }
}