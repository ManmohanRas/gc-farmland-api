namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtExceptionsQueryValidator : AbstractValidator<GetFarmEsmtExceptionsQuery>
{
    public GetFarmEsmtExceptionsQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
                .Cascade(CascadeMode.Stop)
                .NotNull().NotEmpty().WithMessage("ApplicationId is required.")
                .GreaterThan(0)
                .WithMessage("ApplicationId must be greater than 0");
    }
}
