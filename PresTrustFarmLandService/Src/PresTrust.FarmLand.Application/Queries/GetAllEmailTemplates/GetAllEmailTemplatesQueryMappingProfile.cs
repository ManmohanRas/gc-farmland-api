namespace PresTrust.FarmLand.Application.Queries;

public class GetAllEmailTemplatesQueryMappingProfile: Profile
{
    public GetAllEmailTemplatesQueryMappingProfile()
    {
        CreateMap<FarmEmailTemplateEntity, GetAllEmailTemplatesQueryViewModel>();
    }
}
