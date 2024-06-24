using FluentValidation;

namespace PresTrust.FarmLand.Application.Queries;

public class GetMunicipalUsersQueryValidator : AbstractValidator<GetMunicipalUsersQuery>
{
    
        /// <summary>
        /// create rules for attributes
        /// </summary>
        public GetMunicipalUsersQueryValidator()
        {
        RuleFor(query => query.AgencyId)
            .Cascade(CascadeMode.Stop)
            .NotNull().NotEmpty().WithMessage("AgencyId is required.")
            .GreaterThan(0)
            .WithMessage("AgencyId must be greater than 0");
        }
}
