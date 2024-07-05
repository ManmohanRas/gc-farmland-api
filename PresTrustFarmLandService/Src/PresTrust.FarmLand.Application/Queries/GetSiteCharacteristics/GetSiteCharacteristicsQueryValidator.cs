

namespace PresTrust.FarmLand.Application.Queries;

public class GetSiteCharacteristicsQueryValidator:AbstractValidator<GetSiteCharacteristicsQuery>
{

    public GetSiteCharacteristicsQueryValidator()
    {
        RuleFor(query => query.ApplicationId)
            .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
