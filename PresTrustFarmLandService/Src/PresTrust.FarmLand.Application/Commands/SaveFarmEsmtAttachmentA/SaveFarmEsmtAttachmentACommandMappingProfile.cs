using PresTrust.FarmLand.Application.Commands.SaveFarmEsmtAttachmentA;

namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAttachmentACommandMappingProfile : Profile
{
    public SaveFarmEsmtAttachmentACommandMappingProfile()
    {
        CreateMap<SaveFarmEsmtAttachmentACommand, FarmEsmtAttachmentAEntity>();
    }
}
