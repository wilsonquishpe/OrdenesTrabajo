using OrdenesTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesTrabajo.Data
{
    public class ServiceExt
    {

        public static string urlIp = "https://get.geojs.io/v1/ip/geo.js";


        private string BaseUrl { get; }
        private HttpClient Client { get; }

        public ServiceExt()
        {
            BaseUrl = urlIp;
            Client = new HttpClient();
        }


        public async Task<Response> Get(string uri)
        {
            try
            {
                Client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                Console.WriteLine($"URL: {uri}");
                HttpResponseMessage response = await Client.GetAsync(BaseUrl + uri);
                string Content = await response.Content.ReadAsStringAsync();


                int total = Content.Length;
                int startIndex = 6;
                int length = total-8;
                string substring = Content.Substring(startIndex, length);
                Console.WriteLine(substring);

                return new Response
                {
                    IsSuccess = response.IsSuccessStatusCode,
                    Message = substring,
                };
            }
            catch (Exception e)
            {

                Console.WriteLine("Get:Exception: " + e.Message);
                return new Response
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }

        }
    }
}
