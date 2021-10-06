using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ServiceClient.Services;
using ServiceClient.Validators;

namespace ServiceClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonManager _manager;
        private readonly IPersonPostValidator _validator;

        public PeopleController(IPersonManager manager, IPersonPostValidator validator)
        {
            _manager = manager;
            _validator = validator;
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
            _validator.ValidateAndThrow(person);

            _manager.Add(person);


            return Ok(person);
        }
    }
}
