using APISolution.Contracts;
using APISolution.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace APISolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PoliciesController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public PoliciesController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Policy.FindAll());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _repository.Policy.FindByCondition(x => x.Id == id).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        // PUT: api/[controller]/5
        [HttpPut()]
        public IActionResult Put(Policy policy)
        {
            _repository.Policy.Update(policy);
            _repository.Save();
            return Ok();
        }

        // POST: api/[controller]
        [HttpPost]
        public ActionResult Post([FromBody] Policy policy)
        {
            _repository.Policy.Create(policy);
            _repository.Save();
            return Ok();
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var column = _repository.Policy.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (column == null)
            {
                return NotFound();
            }

            _repository.Policy.Delete(column);
            _repository.Save();
            return Ok();
        }
    }
}