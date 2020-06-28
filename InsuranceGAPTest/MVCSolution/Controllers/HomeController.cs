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

        private readonly ApiConnection _apiConnection;

        public HomeController(ApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }


        public async Task <IActionResult> Index()
        {
            await LoginUser(new LoginModel() { Username = "Admin", Password = "Test2020" });
            return View();
        }

        public async Task LoginUser(LoginModel userCredentials)
        {
            HttpResponseMessage rs = await _apiConnection.Client.PostAsJsonAsync("login", userCredentials);

            if (rs.IsSuccessStatusCode)
            {
                var results = await rs.Content.ReadAsStringAsync();
                var responseJson = JObject.Parse(results);
                HttpContext.Session.SetString("JWToken", (string)responseJson["token"]);

            }
          //  return Redirect("~/Home/Index");
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");

        }
    }
}
