namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppSignatoryQueryMappingProfile : Profile
{
    public GetEsmtAppSignatoryQueryMappingProfile()
    {
        CreateMap<FarmEsmtAppSignatoryEntity, GetEsmtAppSignatoryQueryViewModel>();
        CreateMap<FarmEsmtAttachmentAEntity, FarmEsmtAttachmentAViewModel>();

    }
}
