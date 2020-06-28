using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;

namespace MVCSolution.Data
{
    public class ApiConnection
    {
        #region Properties
        public HttpClient Client { get; private set; }
        #endregion

        #region Constructor - Destructor - Finalizer
        public ApiConnection(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            var bearerToken = httpContextAccessor.HttpContext.Session.GetString("JWToken");

            if (bearerToken != null)
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + bearerToken);


            httpClient.BaseAddress = new Uri("https://localhost:44330/api/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");         
            Client = httpClient;
        }
        #endregion
    }
}
