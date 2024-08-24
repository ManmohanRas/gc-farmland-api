namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveEsmtLiensCommandValidator : AbstractValidator<SaveEsmtLiensCommand>
    {
        public SaveEsmtLiensCommandValidator()
        {
            RuleFor(query => query.ApplicationId)
                    .GreaterThan(0)
                    .WithMessage("Not a valid Application Id.");
        }
    }
}
