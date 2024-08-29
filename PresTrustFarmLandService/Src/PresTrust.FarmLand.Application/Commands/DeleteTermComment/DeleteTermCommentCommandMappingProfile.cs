namespace PresTrust.FarmLand.Application.Commands;

public class DeleteTermCommentCommandMappingProfile : Profile
{
    public DeleteTermCommentCommandMappingProfile()
    {
        CreateMap<DeleteTermCommentCommand, FarmCommentsEntity>();
    
    }
}
