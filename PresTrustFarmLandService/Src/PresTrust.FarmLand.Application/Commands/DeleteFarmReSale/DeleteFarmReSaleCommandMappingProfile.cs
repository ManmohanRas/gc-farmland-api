namespace PresTrust.FarmLand.Application.Commands;

public class DeleteFarmReSaleCommandMappingProfile : Profile
{

    public DeleteFarmReSaleCommandMappingProfile()
    {
        CreateMap<DeleteFarmReSaleCommand, FarmReSaleEntity>();
    }
}
