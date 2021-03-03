using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

using System.Net.Http.Headers;
using System.Threading.Tasks;
using WindowsFormsApp2;

namespace ConsoleApp1
{

    class Program
    {
     
        static async Task Main(string[] args)
        {




            using var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400");


            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
           // Console.WriteLine(responseBody);
            var result = JsonConvert.DeserializeObject<Record>(responseBody);
           


            Console.WriteLine(result.ToString());
            //Console.WriteLine(result.Sunrise);
        }
    }

    
}
