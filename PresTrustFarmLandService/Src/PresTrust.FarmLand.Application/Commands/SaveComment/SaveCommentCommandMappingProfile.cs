namespace PresTrust.FarmLand.Application.Commands;

public class SaveCommentCommandMappingProfile : Profile
{
    public SaveCommentCommandMappingProfile() 
    {
        CreateMap<SaveCommentCommand, FarmCommentsEntity>();
    }
}
