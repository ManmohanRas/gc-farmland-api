namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppAdminCostDetailsQueryValidator : AbstractValidator<GetEsmtAppAdminCostDetailsQuery>
{
    public GetEsmtAppAdminCostDetailsQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
           .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
