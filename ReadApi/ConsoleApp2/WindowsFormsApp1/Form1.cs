using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {





            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://webcode.me");
                Console.WriteLine(result.StatusCode);
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                //HttpResponseMessage response = await client.GetAsync("https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400");
                //Console.WriteLine(response.StatusCode);
                //if (response.IsSuccessStatusCode)
                //{
                //    SunResultModel result = await response.Content.ReadAsAsync<SunResultModel>();

                //    Console.WriteLine(result.Sunset, result.Sunrise);

                //}

            }

            }
        //}
    
    public static HttpClient ApiClient { get; set; }
        
    }
}
