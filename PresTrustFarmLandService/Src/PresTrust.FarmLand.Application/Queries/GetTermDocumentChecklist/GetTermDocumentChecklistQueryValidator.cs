namespace PresTrust.FarmLand.Application.Queries;

public class GetApplicationDocumentChecklistQueryValidator : AbstractValidator<GetTermDocumentChecklistQuery>
{
        public GetApplicationDocumentChecklistQueryValidator()
        {
            RuleFor(query => query.ApplicationId)
                   .GreaterThan(0).WithMessage("Not a valid Application Id");
        }
    
}
