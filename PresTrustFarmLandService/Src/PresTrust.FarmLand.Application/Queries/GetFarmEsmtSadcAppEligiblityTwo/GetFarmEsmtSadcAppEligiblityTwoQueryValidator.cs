namespace PresTrust.FarmLand.Application.Queries;
public class GetFarmEsmtSadcAppEligiblityTwoQueryValidator:AbstractValidator<GetFarmEsmtSadcAppEligiblityTwoQuery>
{
    public GetFarmEsmtSadcAppEligiblityTwoQueryValidator()
    {
        RuleFor(query => query.ApplicationId).GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
