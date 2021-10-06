using FluentValidation;
using ServiceClient.Services;

namespace ServiceClient.Validators
{
    public interface IPersonInsertValidator : IValidator<Person>
    {
    }
}