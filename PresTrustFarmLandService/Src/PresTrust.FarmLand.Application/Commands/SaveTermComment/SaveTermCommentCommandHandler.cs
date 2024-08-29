namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermCommentCommandHandler : IRequestHandler<SaveTermCommentCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermCommentsRepository repoComment;

    public SaveTermCommentCommandHandler
        (
          IMapper mapper,
          IPresTrustUserContext userContext,
          IOptions<SystemParameterConfiguration> systemParamOptions,
          IApplicationRepository repoApplication,
          ITermCommentsRepository repoComment
        )
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoComment = repoComment;
    }

    public async Task<int> Handle(SaveTermCommentCommand request, CancellationToken cancellationToken)
    {

        var reqComment = mapper.Map<SaveTermCommentCommand, FarmCommentsEntity>(request);


        // save comment
        FarmCommentsEntity comment = default;
        comment = await this.repoComment.SaveAsync(reqComment);

        return comment.Id;
    }
}
