using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard.Api
{
    public class API
    {

        public static List<BusData> GetData(string stopCode)
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

        public static string[] GetLocation(string postCode)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://api.postcodes.io/");
            var request = new RestRequest();
            request.Resource = "postcodes/" + postCode;
            IRestResponse response = client.Execute(request);
            var result = JObject.Parse(response.Content);
            string longitude = result["result"]["longitude"].ToString();
            string latitude = result["result"]["latitude"].ToString();
            string[] final_result = { latitude, longitude };
            return final_result;
        }

        public static List<BusStop> GetNearestStop(string latitude, string longitude)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.tfl.gov.uk");
            client.Authenticator = new SimpleAuthenticator("app_id", "48fc64da", "app_key", "13b3e4935f4929c443b2391efe204741");
            var request = new RestRequest();
            request.Resource = "StopPoint?stopTypes=NaptanPublicBusCoachTram&radius=200&lat=" + latitude + "&lon=" + longitude;
            IRestResponse response = client.Execute(request);
            var result = JObject.Parse(response.Content);
            var address = result["stopPoints"];
            string stopId_1 = address[0]["naptanId"].ToString();
            string stopDistance_1 = address[0]["distance"].ToString();

            string stopId_2 = address[1]["naptanId"].ToString();
            string stopDistance_2 = address[1]["distance"].ToString();

            List<BusStop> nearest_stops = new List<BusStop>();
            nearest_stops.Add(new BusStop(stopId_1, Convert.ToDouble(stopDistance_1)));
            nearest_stops.Add(new BusStop(stopId_2, Convert.ToDouble(stopDistance_2)));

            return nearest_stops;
        }


        public static List<BusData> SortByTime(List<BusData> BusList)
        {
            BusList = BusList.OrderBy(o => o.TimeToStation).ToList();
            return BusList;
        }
    }
}
