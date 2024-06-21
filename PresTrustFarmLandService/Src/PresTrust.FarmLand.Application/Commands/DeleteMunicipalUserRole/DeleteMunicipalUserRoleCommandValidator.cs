using FluentValidation;

namespace PresTrust.FarmLand.Application.Commands;

public class DeleteMunicipalUserRoleCommandValidator : AbstractValidator<DeleteMunicipalUserRoleCommand>
{
    public DeleteMunicipalUserRoleCommandValidator()
    {

        RuleFor(command => command.AgencyId)
           .GreaterThan(0).WithMessage("Invalid Municipal Id");

        RuleFor(command => command.Email)
            .NotNull().NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address format.");

        RuleFor(command => command.Role)
            .NotNull().NotEmpty().WithMessage("Role is required.")
            .Must(x => ValidRole(x)).WithMessage("Invalid Municipal user role.");

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

        switch (role)
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


