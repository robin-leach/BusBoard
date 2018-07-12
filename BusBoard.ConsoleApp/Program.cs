using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.tfl.gov.uk");
            client.Authenticator = new SimpleAuthenticator("app_id", "48fc64da", "app_key", "13b3e4935f4929c443b2391efe204741");

            var request = new RestRequest();
            request.Resource = "StopPoint/490008660N/Arrivals";
            IRestResponse response = client.Execute(request);
            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            List<BusData> x = deserial.Deserialize<List<BusData>>(response);

            foreach(var y in x)
            {
                y.print();
            }
            Console.ReadLine();
        



        }
    }
}
