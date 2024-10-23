namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtAppAdminStructNonAgWetlandsQueryValidator : AbstractValidator<GetFarmEsmtAppAdminStructNonAgWetlandsQuery>
{
    /// <summary>
    /// create rules for attributes
    /// </summary>
    public GetFarmEsmtAppAdminStructNonAgWetlandsQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
           .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
