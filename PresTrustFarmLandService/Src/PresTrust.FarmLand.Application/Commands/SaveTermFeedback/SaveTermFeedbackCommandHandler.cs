namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermFeedbackCommandHandler : IRequestHandler<SaveTermFeedbackCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermFeedbacksRepository repoFeedback;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="userContext"></param>
    /// <param name="systemParamOptions"></param>
    /// <param name="repoApplication"></param>
    /// <param name="repoFeedback"></param>
    public SaveTermFeedbackCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        ITermFeedbacksRepository repoFeedback
    )
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoFeedback = repoFeedback;
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(SaveTermFeedbackCommand request, CancellationToken cancellationToken)
    {
        // get application details
        //var application = await GetIfApplicationExists(request.ApplicationId);

        var feedback = mapper.Map<SaveTermFeedbackCommand, TermFeedbacksEntity>(request);
        feedback.LastUpdatedBy = userContext.Email;
        feedback.CorrectionStatus = feedback.Section == ApplicationSectionEnum.NONE ? ApplicationCorrectionStatusEnum.NONE.ToString() : ApplicationCorrectionStatusEnum.PENDING.ToString();
        feedback = await repoFeedback.SaveAsync(feedback);
        return feedback.Id;
    }
}
