namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAppAdminStructNonAgWetlandsCommandValidator : AbstractValidator<SaveFarmEsmtAppAdminStructNonAgWetlandsCommand>
{
        public SaveFarmEsmtAppAdminStructNonAgWetlandsCommandValidator()
        {
            RuleFor(query => query.ApplicationId)
                    .GreaterThan(0)
                    .WithMessage("Not a valid Application Id.");

        }
}
