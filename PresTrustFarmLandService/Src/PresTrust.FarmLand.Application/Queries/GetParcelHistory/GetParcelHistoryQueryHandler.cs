
namespace PresTrust.FarmLand.Application.Queries;

public class GetParcelHistoryQueryHandler : IRequestHandler<GetParcelHistoryQuery, List<GetParcelHistoryQueryViewModel>>
{
    private readonly IMapper mapper;
    private readonly IFarmParcelHistoryRepository repoParcelHistory;

    public GetParcelHistoryQueryHandler
        (
        IMapper mapper,
        IFarmParcelHistoryRepository repoParcelHistory
        )
    {
        this.mapper = mapper;
        this.repoParcelHistory = repoParcelHistory;
    }
    public async Task<List<GetParcelHistoryQueryViewModel>> Handle(GetParcelHistoryQuery request, CancellationToken cancellationToken)
    {
        List<GetParcelHistoryQueryViewModel> result;
        var reqHistory = await repoParcelHistory.GetParcelHistoryAsync(request.ParcelId);

        result = mapper.Map<List<FarmParcelHistoryEntity>, List<GetParcelHistoryQueryViewModel>>(reqHistory);

        return result;

    }
}
