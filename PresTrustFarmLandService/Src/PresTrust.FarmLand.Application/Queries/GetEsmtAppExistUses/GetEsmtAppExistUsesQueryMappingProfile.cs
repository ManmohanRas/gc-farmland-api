namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppExistUsesQueryMappingProfile:Profile
{
    public GetEsmtAppExistUsesQueryMappingProfile()
    {
        CreateMap<EsmtAppExistUsesEntity, GetEsmtAppExistUsesQueryViewModel>();
        CreateMap<EsmtAppAttachmentCEntity, GetEsmtAppAttachmentCQueryViewModel>();
        CreateMap<EsmtAppAttachmentEEntity, GetEsmtAppAttachmentEQueryViewModel>();

    }
}
