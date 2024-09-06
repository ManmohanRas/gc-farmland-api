namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// This class defines the configuration using profiles.
/// </summary>
public class CreateTermApplicationCommandMappingProfile: Profile
{
    public CreateTermApplicationCommandMappingProfile()
    {
        CreateMap<CreateTermApplicationCommand, FarmApplicationEntity>();
        CreateMap<FarmApplicationEntity, CreateTermApplicationCommandViewModel>();
    }
}
