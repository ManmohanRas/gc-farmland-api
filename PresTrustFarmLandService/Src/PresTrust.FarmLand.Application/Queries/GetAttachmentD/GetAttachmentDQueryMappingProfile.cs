namespace PresTrust.FarmLand.Application.Queries
{
    public class GetAttachmentDQueryMappingProfile : Profile
    {
        public GetAttachmentDQueryMappingProfile()
        {
            CreateMap<FarmEsmtAttachmentDSourseEntity, EsmtAttachmentDViewModel>();
        }
    }
}
