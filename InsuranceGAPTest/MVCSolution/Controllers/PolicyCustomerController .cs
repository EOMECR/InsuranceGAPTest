using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCSolution.Data;
using MVCSolution.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCSolution.Controllers
{
    public class PolicyCustomerController : Controller
    {
        #region Private Varriable Members
        private readonly ApiConnection _apiConnection;
        #endregion

        #region Constructor - Destructor - Finalizer
        public PolicyCustomerController(ApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }
        #endregion

        #region Methods
        // GET: CustomerController
        public async Task<ActionResult> Index()
        {
            List<DTOPolicyCustomer> policyCustomers = new List<DTOPolicyCustomer>();
            HttpResponseMessage rs = await _apiConnection.Client.GetAsync("policycustomers");

            if (rs.IsSuccessStatusCode)
            {
                var results = rs.Content.ReadAsAsync<List<DTOPolicyCustomer>>();
                results.Wait();
                policyCustomers = results.Result;
            }

            return View(policyCustomers);
        }

        // GET: CustomerController/Create
        public async Task<ActionResult> Create()
        {
            List<Customer> customers = new List<Customer>();
            List<Policy> policies = new List<Policy>();
            HttpResponseMessage rCustomer = await _apiConnection.Client.GetAsync("customers");
            HttpResponseMessage rPolicy = await _apiConnection.Client.GetAsync("policies");

            if (rCustomer.IsSuccessStatusCode)
            {
                var results = rCustomer.Content.ReadAsAsync<List<Customer>>();
                results.Wait();
                customers = results.Result;
            }
            if (rPolicy.IsSuccessStatusCode)
            {
                var results = rPolicy.Content.ReadAsAsync<List<Policy>>();
                results.Wait();
                policies = results.Result;
            }

            ViewBag.Customers =(from customer in customers
                                               select new SelectListItem()
                                               {
                                                   Value = customer.Id.ToString(),
                                                   Text = $"{customer.Name} {customer.LastName}"
                                               }).ToList();
            ViewBag.Policies = (from policy in policies
                                              select new SelectListItem()
                                              {
                                                  Value = policy.Id.ToString(),
                                                  Text = policy.Name
                                              }).ToList();

            return View(new PolicyCustomer());
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PolicyCustomer policyCustomer)
        {

            var postTask = _apiConnection.Client.PostAsJsonAsync<PolicyCustomer>("policycustomers", policyCustomer);

            postTask.Wait();
            var results = postTask.Result;

            if (results.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View();

        }

        // GET: CustomerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var rs = await _apiConnection.Client.DeleteAsync($"policycustomers/{id}");
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
