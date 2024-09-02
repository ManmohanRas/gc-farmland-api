namespace PresTrust.FarmLand.Application.Queries;

public class GetDocumentsBySectionQueryValidator : AbstractValidator<GetDocumentsBySectionQuery>
{
    public GetDocumentsBySectionQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
            .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
