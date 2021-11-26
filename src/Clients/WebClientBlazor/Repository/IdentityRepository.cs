using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace WebClientBlazor.Repository
{
    public class IdentityRepository
    {
        public HttpClient Client { get; set; }

        public IdentityRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:24141/identity");
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
    }
}
