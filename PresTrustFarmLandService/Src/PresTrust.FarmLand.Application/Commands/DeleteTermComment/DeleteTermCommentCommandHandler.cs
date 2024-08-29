namespace PresTrust.FarmLand.Application.Commands;

public class DeleteTermCommentCommandHandler : IRequestHandler<DeleteTermCommentCommand, bool>
{
    private readonly IMapper mapper;
    private readonly ITermCommentsRepository repoComment;

    public DeleteTermCommentCommandHandler (
        IMapper mapper,
        ITermCommentsRepository repoComment)
    {
        this.mapper = mapper;
        this.repoComment = repoComment;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> Handle(DeleteTermCommentCommand request, CancellationToken cancellationToken)
    {
        var reqComment = mapper.Map<DeleteTermCommentCommand, FarmCommentsEntity>(request);
        await repoComment.DeleteCommentAsync(reqComment);
        return true;
    }
}
