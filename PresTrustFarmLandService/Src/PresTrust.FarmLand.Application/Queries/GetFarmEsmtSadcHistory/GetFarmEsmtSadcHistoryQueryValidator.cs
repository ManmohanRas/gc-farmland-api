namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtSadcHistoryQueryValidator : AbstractValidator<GetFarmEsmtSadcHistoryQuery>
{
    public GetFarmEsmtSadcHistoryQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
           .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
