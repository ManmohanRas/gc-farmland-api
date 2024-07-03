namespace PresTrust.FarmLand.Application.Queries;
/// <summary>
/// This class validates query input
/// </summary>
/// <remarks>
/// Returns BadRequest Response if any failures occured
/// </remarks>
public class GetTermBrokenRulesQueryValidator : AbstractValidator<GetTermBrokenRulesQuery>
{
    public GetTermBrokenRulesQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
              .GreaterThan(0)
              .WithMessage("Not a valid Application Id");
    }
}
