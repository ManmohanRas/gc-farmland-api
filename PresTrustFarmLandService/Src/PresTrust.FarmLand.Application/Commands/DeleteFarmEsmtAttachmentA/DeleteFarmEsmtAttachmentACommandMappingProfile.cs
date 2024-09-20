namespace PresTrust.FarmLand.Application.Commands;

public class DeleteFarmEsmtAttachmentACommandMappingProfile : Profile
{
    public DeleteFarmEsmtAttachmentACommandMappingProfile()
    {
        CreateMap<DeleteFarmEsmtAttachmentACommand, FarmEsmtAttachmentAEntity>();
    }
}
