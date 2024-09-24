namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtAgriEnterpriseQueryValidator : AbstractValidator<GetFarmEsmtAgriEnterpriseQuery>
{
    /// <summary>
    /// create rules for attributes
    /// </summary>
    public GetFarmEsmtAgriEnterpriseQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
           .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
