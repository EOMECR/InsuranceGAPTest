using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCSolution.Data;
using MVCSolution.Models;

namespace MVCSolution.Controllers
{
    public class PolicyCustomerController : Controller
    {
       
        HttpClient _apiService = new APIConnection().APIService();

        // GET: CustomerController
        public async Task<ActionResult> Index()
        {
            List<Customer> customers = new List<Customer>();
            HttpResponseMessage rs = await _apiService.GetAsync("customers");

            if (rs.IsSuccessStatusCode)
            {
                var results = rs.Content.ReadAsAsync<List<Customer>>();
                results.Wait();
                customers = results.Result;
            }

            return View(customers);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {

            var postTask = _apiService.PostAsJsonAsync<Customer>("customers", customer);

            postTask.Wait();
            var results = postTask.Result;

            if (results.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View();

        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Customer customer = new Customer();
            HttpResponseMessage rs = await _apiService.GetAsync($"customers/{id}");

            if (rs.IsSuccessStatusCode)
            {
                var results = rs.Content.ReadAsAsync<Customer>();
                results.Wait();
                customer = results.Result;
            }

            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var postTask = _apiService.PutAsJsonAsync<Customer>("customers", customer);

            postTask.Wait();
            var results = postTask.Result;

            if (results.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View();
        }

        // GET: CustomerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var rs = await _apiService.DeleteAsync($"customers/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
