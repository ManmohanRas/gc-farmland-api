namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtLiensQueryValidator : AbstractValidator<GetEsmtLiensQuery>
{
    public GetEsmtLiensQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
           .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
