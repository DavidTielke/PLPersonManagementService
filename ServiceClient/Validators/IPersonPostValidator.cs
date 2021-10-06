using FluentValidation;
using ServiceClient.Services;

namespace ServiceClient.Validators
{
    public interface IPersonPostValidator : IValidator<Person>
    {

    }
}