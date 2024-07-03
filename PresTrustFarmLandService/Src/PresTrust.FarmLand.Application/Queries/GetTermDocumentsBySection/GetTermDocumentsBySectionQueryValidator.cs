namespace PresTrust.FarmLand.Application.Queries;

public class GetTermDocumentsBySectionQueryValidator : AbstractValidator<GetTermDocumentsBySectionQuery>
{
    public GetTermDocumentsBySectionQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
            .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
