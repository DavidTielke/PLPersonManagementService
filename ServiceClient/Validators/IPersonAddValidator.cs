using FluentValidation;
using ServiceClient.Services;

namespace ServiceClient.Validators
{
    public interface IPersonAddValidator : IValidator<Person>
    {

    }
}