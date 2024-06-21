using FluentValidation;

namespace PresTrust.FarmLand.Application.Commands;

public class DeleteCountyUserRoleCommandValidator: AbstractValidator<DeleteCountyUserRoleCommand>
{
    public DeleteCountyUserRoleCommandValidator()
    {
        RuleFor(command => command.Email)
            .NotNull().NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address format.");

        RuleFor(command => command.Role)
            .NotNull().NotEmpty().WithMessage("Role is required.")
            .Must(x => ValidRole(x)).WithMessage("Invalid agency user role.");
    }


    /// <summary>
    /// Check if a given role is valid
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public bool ValidRole(string Role)
    {
        bool result = false;

        if (string.IsNullOrEmpty(Role))
            return true;
        switch (Role) {

            case IdentityRoles.FARM_PROGRAM_ADMIN:
            case IdentityRoles.FARM_PROGRAM_COMMITTEE:
            case IdentityRoles.FARM_PROGRAM_EDITOR:
            case IdentityRoles.FARM_PROGRAM_READONLY:
                result = true;
                break;
            default:
                break;

        }
        return result;
    }
}
