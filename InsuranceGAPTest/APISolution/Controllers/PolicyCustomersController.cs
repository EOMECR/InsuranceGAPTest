using APISolution.Contracts;
using APISolution.Entities;
using APISolution.Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PolicyCustomersController : ControllerBase
    {
        #region Private Variable Members
        private IRepositoryWrapper _repository;
        #endregion

        #region Constructor - Destructor - Finalizer
        public PolicyCustomersController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult Get()
        {
            List<DTOPolicyCustomer> listPolicyCustomer = new List<DTOPolicyCustomer>();
            var objPC = _repository.PolicyCustomer.FindAll().ToList();
            var objC = _repository.Customer.FindAll().ToList();
            var objP = _repository.Policy.FindAll().ToList();

            foreach (var obkPC in objPC)
            {
                var das = (from customer in objC
                          from policy in objP
                          where customer.Id == obkPC.CustomerId
                          where policy.Id == obkPC.PolicyID
                          select new DTOPolicyCustomer()
                          {
                              Id = obkPC.Id,
                              CustomerId = customer.Id,
                              PolicyID = policy.Id,
                              CustomerName = $"{customer.Name} {customer.LastName}",
                              PolicyName = policy.Name
                          }).FirstOrDefault();
                listPolicyCustomer.Add(das);
            }

            return Ok(listPolicyCustomer);
        }

        // POST: api/[controller]
        [HttpPost]
        public ActionResult Post([FromBody] PolicyCustomer policyCustomer)
        {
            _repository.PolicyCustomer.Create(policyCustomer);
            _repository.Save();
            return Ok();
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var column = _repository.PolicyCustomer.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (column == null)
            {
                return NotFound();
            }

            _repository.PolicyCustomer.Delete(column);
            _repository.Save();
            return Ok();
        }
        #endregion
    }
}
