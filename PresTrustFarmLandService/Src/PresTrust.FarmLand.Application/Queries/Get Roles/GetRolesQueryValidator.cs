using FluentValidation;

namespace PresTrust.FarmLand.Application.Queries;

public class GetRolesQueryValidator : AbstractValidator<GetRolesQuery>
{
    public GetRolesQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
            .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
