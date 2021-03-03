using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WindowsFormsApp2
{
      public  class SunProcessor
    {
        
        public static async Task <SunModel> loadSunTime()
        {
            SunModel model;

            try
            {
                var apicallObject = new
                {
                    sunrise= model.Sunrise,
                    sunset = model.Sunset
                };

                if (apicallObject != null)
                {
                    var bodyContent = JsonConvert.SerializeObject(apicallObject);
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(bodyContent.ToString(), Encoding.UTF8, "application/json");
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                     //   client.DefaultRequestHeaders.Add("access-token", _token); // _token = access token
                        var response = await client.PostAsync("https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400", content); // _url =api endpoint url
                        if (response != null)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();

                            try
                            {
                                var result = JsonConvert.DeserializeObject<SunModel>(jsonString); // TestModel2 = deserialize object
                            }
                            catch (Exception e)
                            {
                                //msg
                                throw e;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;


        }


        


    }
}
