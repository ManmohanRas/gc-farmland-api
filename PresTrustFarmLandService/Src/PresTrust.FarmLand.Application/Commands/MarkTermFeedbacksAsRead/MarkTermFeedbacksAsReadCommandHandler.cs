namespace PresTrust.FarmLand.Application.Commands;

public class MarkTermFeedbacksAsReadCommandHandler : IRequestHandler<MarkTermFeedbacksAsReadCommand, bool>
{
    private IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly ITermFeedbacksRepository repoFeedback;

    public MarkTermFeedbacksAsReadCommandHandler(IMapper mapper,
        IPresTrustUserContext userContext,
        ITermFeedbacksRepository repoFeedback
        )
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.repoFeedback = repoFeedback;
    }

    public async Task<bool> Handle(MarkTermFeedbacksAsReadCommand request, CancellationToken cancellationToken)
    {
        if (userContext.Role == UserRoleEnum.PROGRAM_ADMIN)
        {
            await repoFeedback.MarkFeedbacksAsReadAsync(request.FeedbackIds);
        }
        return true;
    }
}
