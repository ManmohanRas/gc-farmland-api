namespace PresTrust.FarmLand.Application.Queries;

public class GetTermFeedbacksQueryValidator:AbstractValidator<GetTermFeedbacksQuery>
{
    public GetTermFeedbacksQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
            .GreaterThan(0).WithMessage("Not a valid Application Id");
    }

}
