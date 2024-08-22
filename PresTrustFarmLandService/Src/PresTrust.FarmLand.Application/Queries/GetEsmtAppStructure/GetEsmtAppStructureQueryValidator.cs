

using FluentValidation.AspNetCore;

namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppStructureQueryValidator:AbstractValidator<GetEsmtAppStructureQuery>
{
    public GetEsmtAppStructureQueryValidator()
    {
        RuleFor(query => query.ApplicationId).GreaterThan(0).WithMessage("Not a valid Application Id");
    }
    
}
