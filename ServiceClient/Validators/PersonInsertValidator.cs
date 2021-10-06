using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ServiceClient.Services;

namespace ServiceClient.Validators
{
    public class PersonInsertValidator : AbstractValidator<Person>, IPersonInsertValidator 
    {
        public PersonInsertValidator()
        {
            RuleFor(p => p).NotNull();
            RuleFor(p => p.Id).Equals(0);
        }
    }
}
