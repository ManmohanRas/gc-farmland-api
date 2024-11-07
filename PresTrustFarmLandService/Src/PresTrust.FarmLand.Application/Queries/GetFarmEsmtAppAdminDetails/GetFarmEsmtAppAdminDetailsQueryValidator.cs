namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtAppAdminDetailsQueryValidator : AbstractValidator<GetFarmEsmtAppAdminDetailsQuery>
{
    public GetFarmEsmtAppAdminDetailsQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
           .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
