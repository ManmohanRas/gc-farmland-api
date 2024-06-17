namespace PresTrust.FarmLand.Application.Commands;
/// <summary>
/// This class validates command input
/// </summary>
/// <remarks>
/// Returns BadRequest Response if any failures occured
/// </remarks>
public class AssignRolesCommandValidator : AbstractValidator<AssignRolesCommand>
{
    public AssignRolesCommandValidator()
    {
        RuleFor(command => command.ApplicationId)
            .GreaterThan(0).WithMessage("Not a valid Application Id");
    }
}
