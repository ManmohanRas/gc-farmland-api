namespace PresTrust.FarmLand.Application.Queries;

 public class GetOwnerDetailsQueryValidator : AbstractValidator<GetOwnerDetailsQuery>
{
    public GetOwnerDetailsQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
           .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
