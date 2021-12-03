using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace WebClientBlazor.Repository
{
    public class DiagnosticosRepository
    {
        public HttpClient Client { get; set; }
        public DiagnosticosRepository()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:24141/diagnosticos")
            };
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    }
}
