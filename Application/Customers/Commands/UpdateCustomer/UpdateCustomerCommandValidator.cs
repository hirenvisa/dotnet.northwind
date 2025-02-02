using FluentValidation;
using FluentValidation.Validators;

namespace Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId).MaximumLength(5).NotEmpty();
        RuleFor(x => x.Address).MaximumLength(60);
        RuleFor(x => x.City).MaximumLength(15);
        RuleFor(x => x.ContactName).MaximumLength(40).NotEmpty();
        RuleFor(x => x.ContactName).MaximumLength(30);
        RuleFor(x => x.ContactTitle).MaximumLength(30);
        RuleFor(x => x.Country).MaximumLength(15);
        RuleFor(x => x.Fax).MaximumLength(24).NotEmpty();
        RuleFor(x => x.Phone).MaximumLength(24).NotEmpty();
        RuleFor(x => x.PostalCode).MaximumLength(10);
        RuleFor(x => x.Region).MaximumLength(15);
    }
}
