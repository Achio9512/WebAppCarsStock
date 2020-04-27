using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using WebAppCarsStock.Models;

namespace WebAppCarsStock.Helpers
{
    public class HttpContext
    {
        public static async void PostHttpAction(CarsDetails cars)
        {
            var json = JsonConvert.SerializeObject(cars);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://httpbin.org/post";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
        }

    }
    
}

