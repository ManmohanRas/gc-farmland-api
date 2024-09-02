namespace PresTrust.FarmLand.Application.Commands;

public class DeleteCommentCommandMappingProfile : Profile
{
    public DeleteCommentCommandMappingProfile()
    {
        CreateMap<DeleteCommentCommand, FarmCommentsEntity>();
    
    }
}
