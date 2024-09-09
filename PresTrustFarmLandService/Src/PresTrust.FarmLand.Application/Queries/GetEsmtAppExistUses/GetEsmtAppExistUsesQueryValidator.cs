
namespace PresTrust.FarmLand.Application.Queries;
public class GetEsmtAppExistUsesQueryValidator:AbstractValidator<GetEsmtAppExistUsesQuery>
{

    public GetEsmtAppExistUsesQueryValidator()
    {
       RuleFor(query => query.ApplicationId).GreaterThan(0).WithMessage("Not a valid Application Id");

    }
}
