namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// This class defines the configuration using profiles.
/// </summary>
public class CreateApplicationCommandMappingProfile: Profile
{
    public CreateApplicationCommandMappingProfile()
    {
        CreateMap<CreateApplicationCommand, FarmApplicationEntity>();
        CreateMap<FarmApplicationEntity, CreateApplicationCommandViewModel>();
    }
}
