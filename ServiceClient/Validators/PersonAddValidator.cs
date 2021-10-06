using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ServiceClient.Services;

namespace ServiceClient.Validators
{
    public class PersonAddValidator : AbstractValidator<Person>, IPersonAddValidator
    {
        public PersonAddValidator()
        {
            RuleFor(p => p).NotNull();

            RuleFor(p => p.Name).NotNull().MinimumLength(3);

            RuleFor(p => p.Age).GreaterThanOrEqualTo(16);
        }
    }
}
