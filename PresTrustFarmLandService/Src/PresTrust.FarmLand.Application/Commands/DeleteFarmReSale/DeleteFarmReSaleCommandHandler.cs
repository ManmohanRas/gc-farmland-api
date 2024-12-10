namespace PresTrust.FarmLand.Application.Commands;

public class DeleteFarmReSaleCommandHandler : IRequestHandler<DeleteFarmReSaleCommand, bool>
{
    private readonly IMapper mapper;
    private readonly IFarmReSaleRepository repoFarmReSale;

    public DeleteFarmReSaleCommandHandler
        (
        IMapper mapper,
        IFarmReSaleRepository repoFarmReSale
        )
    {
        this.mapper = mapper;
        this.repoFarmReSale = repoFarmReSale;
    }

    public async Task<bool> Handle(DeleteFarmReSaleCommand request, CancellationToken cancellationToken)
    {
        var FarmResaleDetails = mapper.Map<DeleteFarmReSaleCommand, FarmReSaleEntity>(request);

        await repoFarmReSale.DeleteFarmReSaleById(FarmResaleDetails);
        return true;
    }
}
