namespace PresTrust.FarmLand.Application.Commands;

public class RequestApplicationCommandValidator : AbstractValidator<RequestApplicationCommand>
{
    public RequestApplicationCommandValidator() 
    {
        RuleFor(query => query.ApplicationId)
                .GreaterThan(0)
                .WithMessage("Not a Valid Application Id.");
    }
}
