namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermCommentCommandMappingProfile : Profile
{
    public SaveTermCommentCommandMappingProfile() 
    {
        CreateMap<SaveTermCommentCommand, FarmCommentsEntity>();
    }
}
