namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmSadcResidenceQueryValidator : AbstractValidator<GetFarmSadcResidenceQuery>
{
    public GetFarmSadcResidenceQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
           .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
