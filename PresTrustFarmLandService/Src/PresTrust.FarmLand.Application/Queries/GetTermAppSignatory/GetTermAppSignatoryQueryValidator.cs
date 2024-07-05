namespace PresTrust.FarmLand.Application.Queries;
public class GetTermAppSignatoryQueryValidator : AbstractValidator<GetTermAppSignatoryQuery>
{
    /// <summary>
    /// create rules for attributes
    /// </summary>
    public GetTermAppSignatoryQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
           .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}

