namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// This class defines the configuration using profiles.
/// </summary>
public class CreateEsmtApplicationCommandMappingProfile: Profile
{
    public CreateEsmtApplicationCommandMappingProfile()
    {
        CreateMap<CreateEsmtApplicationCommand, FarmApplicationEntity>();
        CreateMap<FarmApplicationEntity, CreateEsmtApplicationCommandViewModel>();
    }
}
