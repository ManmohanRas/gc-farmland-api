namespace PresTrust.FarmLand.Application.Queries;

public class GetTermAppAdminDeedDetailsQueryValidator : AbstractValidator<GetTermAppAdminDeedDetailsQuery>
{
    public GetTermAppAdminDeedDetailsQueryValidator() {
        RuleFor(query => query.ApplicationId)
           .Cascade(CascadeMode.Stop)
           .NotNull().NotEmpty().WithMessage("ApplicationId is required.")
           .GreaterThan(0)
           .WithMessage("ApplicationId must be greater than 0");
    }
}
