using FluentValidation;

namespace Application.Customers.Queries.GetCustomerDetail;

public class GetCustomerDetailQueryValidator: AbstractValidator<GetCustomerDetailQuery>
{
    public GetCustomerDetailQueryValidator() => RuleFor(v => v.Id).Length(5).NotEmpty();
}