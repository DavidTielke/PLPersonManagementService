using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ServiceClient.Services;

namespace ServiceClient.Validators
{
    public class PeoplePostValidator : AbstractValidator<Person>
    {
        public PeoplePostValidator()
        {
            RuleFor(p => p).NotNull();
            RuleFor(p => p.Name).NotNull();
        }
    }
}
