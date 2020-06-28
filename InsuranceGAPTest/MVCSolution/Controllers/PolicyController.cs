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
    public class PolicyController : Controller
    {
       
        HttpClient _apiService = new APIConnection().APIService();

        // GET: PolicyController
        public async Task<ActionResult> Index()
        {
            List<Policy > policies = new List<Policy>();
            HttpResponseMessage rs = await _apiService.GetAsync("policies");

            if (rs.IsSuccessStatusCode)
            {
                var results = rs.Content.ReadAsAsync<List<Policy>>();
                results.Wait();
                policies = results.Result;
            }

            return View(policies);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PolicyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Policy policy)
        {

            var postTask = _apiService.PostAsJsonAsync<Policy>("policies", policy);

            postTask.Wait();
            var results = postTask.Result;

            if (results.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View();

        }

        // GET: PolicyController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Policy policy = new Policy();
            HttpResponseMessage rs = await _apiService.GetAsync($"Policies/{id}");

            if (rs.IsSuccessStatusCode)
            {
                var results = rs.Content.ReadAsAsync<Policy >();
                results.Wait();
                policy = results.Result;
            }

            return View(policy);
        }

        // POST: PolicyController/Edit/5
        [HttpPost]
        public ActionResult Edit(Policy policy)
        {
            var postTask = _apiService.PutAsJsonAsync<Policy>("Policies", policy);

            postTask.Wait();
            var results = postTask.Result;

            if (results.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View();
        }

        // GET: PolicyController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {            
            var rs = await _apiService.DeleteAsync($"policies/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
