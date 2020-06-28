using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCSolution.Data;
using MVCSolution.Models;
using Newtonsoft.Json.Linq;

namespace MVCSolution.Controllers
{
    public class HomeController : Controller
    {
        HttpClient _apiService = new APIConnection().APIService();
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LoginUser(LoginModel userCredentials)
        {
            HttpResponseMessage rs = await _apiService.PostAsJsonAsync("login", userCredentials);

            if (rs.IsSuccessStatusCode)
            {
                var results = await rs.Content.ReadAsStringAsync();
                var responseJson = JObject.Parse(results);
                HttpContext.Session.SetString("JWToken", (string)responseJson["token"]);

            }
            return Redirect("~/Home/Index");
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");

        }
    }
}
