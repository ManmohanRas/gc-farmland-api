namespace PresTrust.FarmLand.Application.Queries;

public class GetDocumentChecklistQueryValidator : AbstractValidator<GetDocumentChecklistQuery>
{
        public GetDocumentChecklistQueryValidator()
        {
            RuleFor(query => query.ApplicationId)
                   .GreaterThan(0).WithMessage("Not a valid Application Id");
        }
    
}
