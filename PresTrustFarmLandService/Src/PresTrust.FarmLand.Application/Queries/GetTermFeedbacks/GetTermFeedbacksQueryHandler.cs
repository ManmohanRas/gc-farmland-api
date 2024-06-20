namespace PresTrust.FarmLand.Application.Queries;

public class GetTermFeedbacksQueryHandler : IRequestHandler<GetTermFeedbacksQuery, IEnumerable<GetTermFeedbacksQueryViewModel>>
{
    private readonly IMapper mapper;
    private readonly ITermFeedbacksRepository repoFeedback;

    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="userContext"></param>
    /// <param name="systemParamOptions"></param>
    /// <param name="repoApplication"></param>
    /// <param name="repoFeedback"></param>
    public GetTermFeedbacksQueryHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        ITermFeedbacksRepository repoFeedback
    )
    {
        this.mapper = mapper;
        this.repoFeedback = repoFeedback;
    }

    public async Task<IEnumerable<GetTermFeedbacksQueryViewModel>> Handle(GetTermFeedbacksQuery request, CancellationToken cancellationToken)
    {
        // get feedbacks for a given application id
        var feedbacks = await repoFeedback.GetFeedbacksAsync(request.ApplicationId);

        // map command object to the GetFeedbacksQueryViewModel
        var result = mapper.Map<IEnumerable<TermFeedbacksEntity>, IEnumerable<GetTermFeedbacksQueryViewModel>>(feedbacks);
        return result;
    }
}
