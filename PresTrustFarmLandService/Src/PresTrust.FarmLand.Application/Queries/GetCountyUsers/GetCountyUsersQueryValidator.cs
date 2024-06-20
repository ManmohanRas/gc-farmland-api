using FluentValidation;
using PresTrust.FarmLand.Application.Queries;

namespace PresTrust.FloodMitigation.Application.Queries;

public class GetCountyUsersQueryValidator : AbstractValidator<GetCountyUsersQuery>
{
    /// <summary>
    /// create rules for attributes
    /// </summary>
    public GetCountyUsersQueryValidator()
    {
    }

}
