namespace PresTrust.FarmLand.Application.Commands;

public class DeleteOwnerDetailsCommandMappingProfile : Profile
{
    public DeleteOwnerDetailsCommandMappingProfile()
    {
        CreateMap<DeleteOwnerDetailsCommand, OwnerDetailsEntity>();
    }
}