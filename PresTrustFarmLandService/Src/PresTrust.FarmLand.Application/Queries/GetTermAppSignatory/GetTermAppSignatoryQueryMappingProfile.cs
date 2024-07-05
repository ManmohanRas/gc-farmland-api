namespace PresTrust.FarmLand.Application.Queries;
public class GetTermAppSignatoryQueryMappingProfile : Profile
{
    public GetTermAppSignatoryQueryMappingProfile()
    {
        CreateMap<FarmTermAppSignatoryEntity, GetTermAppSignatoryQueryViewModel>();
    }
}