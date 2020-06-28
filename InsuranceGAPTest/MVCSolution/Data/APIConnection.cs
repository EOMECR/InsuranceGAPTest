using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCSolution.Data
{
    public class ApiConnection
    {
        public HttpClient Client { get; private set; }

        public ApiConnection(HttpClient httpClient, HttpClientSettings httpClientSettings, IHttpContextAccessor httpContextAccessor)
        {
            var bearerToken = httpContextAccessor.HttpContext.Session.GetString("JWToken");

            if (bearerToken != null)
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + bearerToken);


            httpClient.BaseAddress = new Uri("https://localhost:44330/api/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");         
            Client = httpClient;
        }
    }
}
