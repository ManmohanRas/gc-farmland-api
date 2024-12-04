namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmReSaleCommandHandler : IRequestHandler<SaveFarmReSaleCommand, int>
{
    private readonly IMapper mapper;
    private readonly IFarmReSaleRepository repoFramReSale;

    public SaveFarmReSaleCommandHandler
        (
        IMapper mapper,
        IFarmReSaleRepository repoFramReSale
        )
    {
        this.mapper = mapper;
        this.repoFramReSale = repoFramReSale;
    }
    public async Task<int> Handle(SaveFarmReSaleCommand request, CancellationToken cancellationToken)
    {

        var reqFarm = mapper.Map<SaveFarmReSaleCommand, FarmReSaleEntity>(request);
        var result = await repoFramReSale.SaveFarmReSaleAsync(reqFarm);

        return result.Id;
    }
}
