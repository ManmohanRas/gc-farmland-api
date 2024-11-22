namespace PresTrust.FarmLand.Application.Queries;
public class GetFarmEsmtSadcFarmInfoQueryValidator:AbstractValidator<GetFarmEsmtSadcHistoryQuery>
{
    public GetFarmEsmtSadcFarmInfoQueryValidator()
    {
        RuleFor(query => query.ApplicationId).GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
