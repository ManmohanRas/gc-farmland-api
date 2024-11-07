namespace PresTrust.FarmLand.Application.Commands;

public class SaveFeedbackCommandHandler : BaseHandler, IRequestHandler<SaveFeedbackCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly IApplicationFeedbackRepository repoFeedback;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="userContext"></param>
    /// <param name="systemParamOptions"></param>
    /// <param name="repoApplication"></param>
    /// <param name="repoFeedback"></param>
    public SaveFeedbackCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IApplicationFeedbackRepository repoFeedback
    ) : base(repoApplication: repoApplication)
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
    public async Task<int> Handle(SaveFeedbackCommand request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        request.ApplicationTypeId = application.ApplicationTypeId;

        var feedback = mapper.Map<SaveFeedbackCommand, FarmFeedbacksEntity>(request);
        feedback.LastUpdatedBy = userContext.Email;

        if (application.ApplicationTypeId == 1)
        {
            feedback.CorrectionStatus = feedback.Section == TermAppSectionEnum.NONE ? ApplicationCorrectionStatusEnum.NONE.ToString() : ApplicationCorrectionStatusEnum.PENDING.ToString();
        }
        else
        {
            if (request.Section == "NONE")
            {
                feedback.CorrectionStatus = "NONE";
                //feedback.CorrectionStatus = feedback.Section == EsmtAppSectionEnum.NONE ?? ApplicationCorrectionStatusEnum.NONE.ToString(); 
            }
            else
            {
                feedback.CorrectionStatus = ApplicationCorrectionStatusEnum.PENDING.ToString();
            }
        }


        feedback = await repoFeedback.SaveAsync(feedback);
        return feedback.Id;
    }
}