namespace PresTrust.FarmLand.Application.Commands
{
    public class DeleteAttachmentDCommandMappingProfile : Profile
    {
        public DeleteAttachmentDCommandMappingProfile()
        {
            CreateMap<DeleteAttachmentDCommand, FarmEsmtAttachmentDSourseEntity>();
        }
    }
}
