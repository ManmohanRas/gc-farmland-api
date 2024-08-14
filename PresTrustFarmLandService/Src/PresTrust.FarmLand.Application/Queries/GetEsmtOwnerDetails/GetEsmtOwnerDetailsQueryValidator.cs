namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtOwnerDetailsQueryValidator : AbstractValidator<GetOwnerDetailsQuery>
{
    public GetEsmtOwnerDetailsQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
           .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
