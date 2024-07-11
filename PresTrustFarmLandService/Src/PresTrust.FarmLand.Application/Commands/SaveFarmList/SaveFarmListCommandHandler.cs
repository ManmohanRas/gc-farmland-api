namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmListCommandHandler : IRequestHandler<SaveFarmListCommand, int>
{
    private readonly IMapper mapper;
    private readonly IFarmListRepository repoFarmList;

    public SaveFarmListCommandHandler
        (
        IMapper mapper,
        IFarmListRepository repoFarmList
        )
    {
        this.mapper = mapper;
        this.repoFarmList = repoFarmList;
    }
    public async Task<int> Handle(SaveFarmListCommand request, CancellationToken cancellationToken)
    {

        var reqFarm = mapper.Map<SaveFarmListCommand, FarmListEntity>(request);
        var result = await repoFarmList.SaveFarmListAsync(reqFarm);

        return result.FarmListID;
    }
}
