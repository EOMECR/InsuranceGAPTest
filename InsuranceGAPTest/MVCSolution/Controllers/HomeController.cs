using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCSolution.Data;
using MVCSolution.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCSolution.Controllers
{
    public class HomeController : Controller
    {
        #region Private - Variable - Members
        private readonly ApiConnection _apiConnection;
        #endregion

        #region Constructor Destructor Finalizer
        public HomeController(ApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }
        #endregion

        #region Methods
        public async Task <IActionResult> Index()
        {
            //Podemos simular acá una autenticación desde un formulario para basar en roles, etc.
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
        }
        #endregion
    }
}
