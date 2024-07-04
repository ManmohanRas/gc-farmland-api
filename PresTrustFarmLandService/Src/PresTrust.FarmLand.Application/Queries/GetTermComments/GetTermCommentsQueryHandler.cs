namespace PresTrust.FarmLand.Application.Queries;

public class GetTermCommentsQueryHandler : IRequestHandler<GetTermCommentsQuery , IEnumerable<GetTermCommentsQueryViewModel>>
{

    private readonly IMapper mapper;
    private readonly ITermCommentsRepository repoComment;

    public GetTermCommentsQueryHandler (
            IMapper mapper,
            ITermCommentsRepository repoComment)
    {
        this.mapper = mapper;
        this.repoComment = repoComment;
    }

    public async Task<IEnumerable<GetTermCommentsQueryViewModel>> Handle(GetTermCommentsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<TermCommentsEntity> results = default;

        results = await this.repoComment.GetAllCommentsAsync(request.ApplicationId);

        var comments = mapper.Map<IEnumerable<TermCommentsEntity>, IEnumerable<GetTermCommentsQueryViewModel>>(results);

        return comments;
    }
}
