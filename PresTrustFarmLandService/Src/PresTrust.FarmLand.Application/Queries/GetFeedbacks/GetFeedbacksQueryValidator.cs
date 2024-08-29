namespace PresTrust.FarmLand.Application.Queries;

public class GetFeedbacksQueryValidator:AbstractValidator<GetFeedbacksQuery>
{
    public GetFeedbacksQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
            .GreaterThan(0).WithMessage("Not a valid Application Id");
    }

}
