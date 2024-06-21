using FluentValidation;
using Microsoft.Identity.Client;

namespace PresTrust.FarmLand.Application.Commands;

public class MunicipalUserRoleChangeRequestCommandValidator : AbstractValidator<MunicipalUserRoleChangeRequestCommand>
{

    /// <summary>
    /// create rules for attributes
    /// </summary>
    public MunicipalUserRoleChangeRequestCommandValidator()
    {
        RuleFor(command => command.AgencyId)
            .GreaterThan(0).WithMessage("Invalid Agency Id.");

        RuleFor(command => command.Email)
            .NotNull().NotEmpty().WithMessage("Email is Required.")
            .EmailAddress().WithMessage("Invalid Email address format.");

        RuleFor(command => command.Role)
            .Must(x => ValidRole(x)).WithMessage("Invalid Municipal User role.");

        RuleFor(command => command.NewRole)
            .NotNull().NotEmpty().WithMessage("New Role is Required.")
            .Must(x => ValidRole(x)).WithMessage("Invalid Municipal User role.");
    }

    /// <summary>
    /// Check if a given role is valid
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>

    public bool ValidRole(string role)
    { 
        bool result = false;

        if (string.IsNullOrEmpty(role))
            return true;

        switch(role)
        {
            case IdentityClaimTypes.FARM_AGENCY_ADMIN:
            case IdentityClaimTypes.FARM_AGENCY_EDITOR:
            case IdentityClaimTypes.FARM_AGENCY_READONLY:
            case IdentityClaimTypes.FARM_AGENCY_SIGNATURE:
                result = true;
                break;
            default:
                break;
        }
        return result;
    }
}
