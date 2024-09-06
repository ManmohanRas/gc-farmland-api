namespace PresTrust.FarmLand.Application.Queries;

public class GetFeedbacksQueryHandler : IRequestHandler<GetFeedbacksQuery, IEnumerable<GetFeedbacksQueryViewModel>>
{
    private readonly IMapper mapper;
    private readonly IApplicationFeedbackRepository repoFeedback;

    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="userContext"></param>
    /// <param name="systemParamOptions"></param>
    /// <param name="repoApplication"></param>
    /// <param name="repoFeedback"></param>
    public GetFeedbacksQueryHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IApplicationFeedbackRepository repoFeedback
    )
    {
        this.mapper = mapper;
        this.repoFeedback = repoFeedback;
    }

    public async Task<IEnumerable<GetFeedbacksQueryViewModel>> Handle(GetFeedbacksQuery request, CancellationToken cancellationToken)
    {
        // get feedbacks for a given application id
        var feedbacks = await repoFeedback.GetFeedbacksAsync(request.ApplicationId);

        // map command object to the GetFeedbacksQueryViewModel
        var result = mapper.Map<IEnumerable<FarmFeedbacksEntity>, IEnumerable<GetFeedbacksQueryViewModel>>(feedbacks);
        return result;
    }
}
