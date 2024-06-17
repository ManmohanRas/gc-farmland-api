namespace PresTrust.FarmLand.Application.Commands;

public class AssignRolesCommandMappingProfile : Profile
{
    public AssignRolesCommandMappingProfile()
    {
        CreateMap<FarmRolesViewModel, FarmRolesEntity>();
    }
}
