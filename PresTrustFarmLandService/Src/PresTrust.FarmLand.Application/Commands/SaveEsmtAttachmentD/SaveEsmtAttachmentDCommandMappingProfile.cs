namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveEsmtAttachmentDCommandMappingProfile : Profile
    {
        public SaveEsmtAttachmentDCommandMappingProfile()
        {
            CreateMap<SaveEsmtAttachmentDViewModel, FarmEsmtAttachmentDSourseEntity>();
        }
    }
}

