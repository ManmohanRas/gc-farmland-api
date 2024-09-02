namespace PresTrust.FarmLand.Application.Commands;

public class SaveCommentCommandHandler : IRequestHandler<SaveCommentCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermCommentsRepository repoComment;

    public SaveCommentCommandHandler
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

    public async Task<int> Handle(SaveCommentCommand request, CancellationToken cancellationToken)
    {

        var reqComment = mapper.Map<SaveCommentCommand, FarmCommentsEntity>(request);


        // save comment
        FarmCommentsEntity comment = default;
        comment = await this.repoComment.SaveAsync(reqComment);

        return comment.Id;
    }
}
