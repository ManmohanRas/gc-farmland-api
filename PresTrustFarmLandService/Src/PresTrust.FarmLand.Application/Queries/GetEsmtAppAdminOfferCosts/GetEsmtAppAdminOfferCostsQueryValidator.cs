namespace PresTrust.FarmLand.Application.Queries;
public class GetEsmtAppAdminOfferCostsQueryValidator:AbstractValidator<GetEsmtAppAdminOfferCostsQuery>
{
    public GetEsmtAppAdminOfferCostsQueryValidator()
    {
        RuleFor(query => query.ApplicationId).GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
