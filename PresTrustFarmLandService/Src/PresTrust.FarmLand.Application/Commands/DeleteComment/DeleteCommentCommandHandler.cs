namespace PresTrust.FarmLand.Application.Commands;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
{
    private readonly IMapper mapper;
    private readonly ITermCommentsRepository repoComment;

    public DeleteCommentCommandHandler (
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
    public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var reqComment = mapper.Map<DeleteCommentCommand, FarmCommentsEntity>(request);
        await repoComment.DeleteCommentAsync(reqComment);
        return true;
    }
}
