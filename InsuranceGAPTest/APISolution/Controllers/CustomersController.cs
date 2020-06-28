using APISolution.Contracts;
using APISolution.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace APISolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomersController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public CustomersController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Customer.FindAll());
        }


        [HttpGet("{id}")]
        public  IActionResult Get(int id)
        {
            var model = _repository.Customer.FindByCondition(x=> x.Id ==id).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        // PUT: api/[controller]/5
        [HttpPut()]
        public IActionResult Put(Customer customer)
        {
            _repository.Customer.Update(customer);
            _repository.Save();
            return Ok();
        }

        // POST: api/[controller]
        [HttpPost]
        public ActionResult Post([FromBody] Customer customer)
        {
            _repository.Customer.Create(customer);
            _repository.Save();
            return Ok();
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var column = _repository.Customer.FindByCondition(x => x.Id == id).FirstOrDefault();
             
            if (column == null)
            {
                return NotFound();
            }

            _repository.Customer.Delete(column);
            _repository.Save();
            return Ok();
        }
    }
}

