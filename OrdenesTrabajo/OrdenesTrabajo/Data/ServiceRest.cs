using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using OrdenesTrabajo.Models;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Diagnostics;
using Xamarin.Essentials;

namespace OrdenesTrabajo.Data
{
    internal class ServiceRest
    {
        public static HttpClient client;
        public static int resultado = 0;
        public static Resultado res = null;
        public static string baseUri = "http://192.168.137.133:4001";
        public static string urlUsuario = baseUri + "/api/usuario/";
        public static string urlCliente = baseUri + "/api/cliente/";
        public static string urlCatalogo = baseUri + "/api/catalogo/";
        public static string urlOrden = baseUri + "/api/ordenTrabajo/";
        public static Uri RequestUri =  null;

        public async Task<Resultado> SaveCliente(Cliente cliente)
        {
            try
            {
                client = new HttpClient();
                RequestUri = new Uri(urlCliente + "save");
                var json = JsonConvert.SerializeObject(cliente);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(RequestUri, contentJson);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    res = new Resultado();
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("content: " + content);
                    res = JsonConvert.DeserializeObject<Resultado>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return res;
        }

        public async Task<Resultado> SaveOrdenTrabajo(OrdenTrabajo orden)
        {
            try
            {
                client = new HttpClient();
                RequestUri = new Uri(urlOrden + "save");
                var json = JsonConvert.SerializeObject(orden);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(RequestUri, contentJson);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    res = new Resultado();
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("content: " + content);
                    res = JsonConvert.DeserializeObject<Resultado>(content);
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return res;
        }

        public async Task<int> IniciarSesion(UserLogin user)
        {
            try
            {
                resultado = 0;
                client = new HttpClient();
                RequestUri = new Uri(urlUsuario+"login");
                Debug.WriteLine("username " + user.username);
                Debug.WriteLine("password " + user.password);
                var json = JsonConvert.SerializeObject(user);
                var contentJson = new StringContent(json,Encoding.UTF8,"application/json");
                using (client)//agregar en las otras consultas
                {
                    var response = await client.PostAsync(RequestUri, contentJson);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        res = new Resultado();
                        var content = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine("content: " + content);
                        res = JsonConvert.DeserializeObject<Resultado>(content);
                        Debug.WriteLine("En el res" + res.ok);
                        if (res.ok) { 
                            resultado = 1;
                            Preferences.Set("isLogged", true);
                            
                        }
                        else { resultado = 0;
                            Preferences.Set("isLogged", false);
                        }     
                    }
                    else
                    {
                        resultado = 0;
                    }
                }    
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return resultado;
        } 

        public async Task<Resultado> GetListUsuarios()
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(urlUsuario + "list");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
                client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    res = new Resultado();
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(content);
                    res = JsonConvert.DeserializeObject<Resultado>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return res;
        }



        public static async Task<Resultado> GetListClientes()
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(urlCliente + "list");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
                client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    res = new Resultado();
                    string content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("GetListClientes " + content);
                    res = JsonConvert.DeserializeObject<Resultado>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return res;
        }

        public static async Task<Resultado> GetListCatalogos()
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(urlCatalogo + "list");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
                client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    res = new Resultado();
                    string content = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<Resultado>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return res;
        }

        public async Task<Resultado> GetCatalogoByTipo(string tipo)
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(urlCatalogo + "listByType/"+tipo);
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
                client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    res = new Resultado();
                    string content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("GetCatalogoByTipo " + content);
                    res = JsonConvert.DeserializeObject<Resultado>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return res;
        }


        public static async Task<Resultado> GetListOrdenes()
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(urlOrden + "list");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
                client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    res = new Resultado();
                    string content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(content);
                    res = JsonConvert.DeserializeObject<Resultado>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return res;
        }





    }
}
