namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppSignatoryQueryValidator : AbstractValidator<GetEsmtAppSignatoryQuery>
{
    /// <summary>
    /// create rules for attributes
    /// </summary>
    public GetEsmtAppSignatoryQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
           .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
