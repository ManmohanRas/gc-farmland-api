namespace PresTrust.FarmLand.Application.Queries;
public class GetApplicationSignatoryQueryMappingProfile : Profile
{
    public GetApplicationSignatoryQueryMappingProfile()
    {
        CreateMap<FarmApplicationSignatoryEntity, GetApplicationSignatoryQueryViewModel>();
    }
}