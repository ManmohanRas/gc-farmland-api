namespace PresTrust.FarmLand.Application.Commands;

public class MarkFeedbacksAsReadCommandHandler : IRequestHandler<MarkFeedbacksAsReadCommand, bool>
{
    private IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly ITermFeedbacksRepository repoFeedback;

    public MarkFeedbacksAsReadCommandHandler(IMapper mapper,
        IPresTrustUserContext userContext,
        ITermFeedbacksRepository repoFeedback
        )
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.repoFeedback = repoFeedback;
    }

    public async Task<bool> Handle(MarkFeedbacksAsReadCommand request, CancellationToken cancellationToken)
    {
        if (userContext.Role == UserRoleEnum.PROGRAM_ADMIN)
        {
            await repoFeedback.MarkFeedbacksAsReadAsync(request.FeedbackIds);
        }
        return true;
    }
}
