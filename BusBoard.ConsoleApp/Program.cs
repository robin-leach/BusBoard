using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string userInput;
            /*
            do
            {
                Console.WriteLine("Please enter a stop code; to end, type 'End'");
                userInput = Console.ReadLine();
                List < BusData > BusList = GetData(userInput);
                SortPrint(BusList);
            }
            while (userInput != "End"); */

            do
            {
                Console.WriteLine("Please enter a postcode; to end, type 'End'");
                userInput = Console.ReadLine();
                string[] Location = GetLocation(userInput);
                Console.WriteLine("Latitude: " + Location[0] + ", longitude: " + Location[1]);
            }
            while (userInput != "End");


            Console.ReadLine();

        }

        static List<BusData> GetData(string stopCode)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.tfl.gov.uk");
            client.Authenticator = new SimpleAuthenticator("app_id", "48fc64da", "app_key", "13b3e4935f4929c443b2391efe204741");
            var request = new RestRequest();
            request.Resource = "StopPoint/" + stopCode + "/Arrivals";
            IRestResponse response = client.Execute(request);
            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            List<BusData> BusList = deserial.Deserialize<List<BusData>>(response);
            return BusList;
        }

        static string[] GetLocation(string postCode)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://api.postcodes.io/");
            var request = new RestRequest();
            request.Resource = "postcodes/" + postCode;
            IRestResponse response = client.Execute(request);
            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var result = JObject.Parse(response.Content);
            string longitude = result["result"]["longitude"].ToString();
            string latitude = result["result"]["latitude"].ToString();
            string[] final_result = { latitude, longitude };
            return final_result;
        }

        static void SortPrint(List<BusData> BusList)
        {
            BusList = BusList.OrderBy(o => o.TimeToStation).ToList();
            int count = 0;
            foreach(var bus in BusList)
            {
                bus.print();
                count++;
                if (count == 5)
                    break;
            }
        }
    }
}
