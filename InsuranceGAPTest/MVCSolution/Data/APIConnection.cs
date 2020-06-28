using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCSolution.Data
{
    public class APIConnection
    {
        public HttpClient APIService()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/api/");
            return client;
        }
    }
}
