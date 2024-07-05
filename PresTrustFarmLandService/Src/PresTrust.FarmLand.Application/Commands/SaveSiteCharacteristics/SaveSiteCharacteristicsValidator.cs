namespace PresTrust.FarmLand.Application.Commands;
public class SaveSiteCharacteristicsValidator:AbstractValidator<SaveSiteCharacteristicsCommand>
{

public SaveSiteCharacteristicsValidator()
    {
        RuleFor(query => query.ApplicationId).GreaterThan(0)
            
            .WithMessage("Not a valid Application Id.");
    }

}
