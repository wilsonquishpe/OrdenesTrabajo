using OrdenesTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesTrabajo.Data
{
    public class ServiceOrden
    {
        public static string urlIp = "http://192.168.137.133:4001/api/";

        private string BaseUrl { get; }
        private HttpClient Client { get; }

        public ServiceOrden()
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
                Console.WriteLine($"URL: {BaseUrl + uri}");
                HttpResponseMessage response = await Client.GetAsync(BaseUrl + uri);
                string Content = await response.Content.ReadAsStringAsync();

                return new Response
                {
                    IsSuccess = response.IsSuccessStatusCode,
                    Message = Content,
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
