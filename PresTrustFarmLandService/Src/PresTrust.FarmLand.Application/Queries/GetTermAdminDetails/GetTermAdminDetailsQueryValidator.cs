namespace PresTrust.FarmLand.Application.Queries;

public class GetTermAdminDetailsQueryValidator : AbstractValidator<GetTermAdminDetailsQuery>
{
    /// <summary>
    /// create rules for attributes
    /// </summary>
    public GetTermAdminDetailsQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
           .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
