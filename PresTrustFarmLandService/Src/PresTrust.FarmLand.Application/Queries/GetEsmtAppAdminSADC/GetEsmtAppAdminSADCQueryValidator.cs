namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppAdminSADCQueryValidator : AbstractValidator<GetEsmtAppAdminSADCQuery>
{
    public GetEsmtAppAdminSADCQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
                .Cascade(CascadeMode.Stop)
                .NotNull().NotEmpty().WithMessage("ApplicationId is required.")
                .GreaterThan(0)
                .WithMessage("ApplicationId must be greater than 0");
    }
}
