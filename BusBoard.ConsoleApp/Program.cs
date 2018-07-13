using System;
using System.Collections.Generic;
using System.Net;
using BusBoard.Api;


namespace BusBoard.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string userInput;

            do
            {
                Console.WriteLine("Please enter a postcode; to end, type 'End'");
                userInput = Console.ReadLine();
                string[] Location = API.GetLocation(userInput);
                string latitude = Location[0];
                string longitude = Location[1];
                List<BusStop> nearest_stops = API.GetNearestStop(latitude, longitude);
                foreach(var stop in nearest_stops)
                {
                    List<BusData> BusList = API.GetData(stop.stopId);
                    Console.WriteLine(BusList[0].StationName + " is " + Math.Round(stop.distance,2) + "m away");
                    API.SortPrint(BusList);
                }


            }
            while (userInput != "End");


            Console.ReadLine();

        }
    }
}
