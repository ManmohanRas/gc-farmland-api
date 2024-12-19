namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmMonitoringCommandHandler : IRequestHandler<SaveFarmMonitoringCommand, int>
{
    private readonly IMapper mapper;
    private readonly IFarmMonitoringRepository repoFarmMonitoring;

    public SaveFarmMonitoringCommandHandler
        (
        IMapper mapper,
        IFarmMonitoringRepository repoFarmMonitoring
        )
    {
        this.mapper = mapper;
        this.repoFarmMonitoring = repoFarmMonitoring;
    }
    public async Task<int> Handle(SaveFarmMonitoringCommand request, CancellationToken cancellationToken)
    {

        var reqFarm = mapper.Map<SaveFarmMonitoringCommand, FarmMonitoringEntity>(request);
        var result = await repoFarmMonitoring.SaveFarmMonitoringAsync(reqFarm);

        return result.Id;
    }
}
