using FluentValidation;

namespace PresTrust.FarmLand.Application.Commands;

public class CountyUserRoleChangeRequestCommandValidator : AbstractValidator<CountyUserRoleChangeRequestCommand>
{
    /// <summary>
    /// create rules for attributes
    /// </summary>
    public CountyUserRoleChangeRequestCommandValidator()
    {
        RuleFor(command => command.Email)
            .NotNull().NotEmpty().WithMessage("Email is Required")
            .EmailAddress().WithMessage("Invalid email address format.");

        RuleFor(command => command.Role)
            .Must(x => ValidRole(x)).WithMessage("Invalid county user role.");

        RuleFor(command => command.NewRole)
            .NotNull().NotEmpty().WithMessage("New Role is Required")
            .Must(x => ValidRole(x)).WithMessage("Invalid county user role");
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
