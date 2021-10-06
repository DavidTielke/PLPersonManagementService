using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceClient.Services;

namespace ServiceClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonManager _manager;

        public PeopleController(IPersonManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var people = _manager.Load().ToList();
            return people;
        }


        [HttpPost]
        public IActionResult Post(Person person)
        {
            _manager.Add(person);

            return Ok(person);
        }
    }
}
