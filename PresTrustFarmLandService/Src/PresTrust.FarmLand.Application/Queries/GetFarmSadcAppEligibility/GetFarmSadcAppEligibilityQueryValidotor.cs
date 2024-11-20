namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmSadcAppEligibilityQueryValidotor : AbstractValidator<GetFarmSadcAppEligibilityQuery>
    {
        public GetFarmSadcAppEligibilityQueryValidotor()
        {
            RuleFor(query => query.ApplicationId)
               .GreaterThan(0).WithMessage("Not a valid Application Id");
        }
    }
}
