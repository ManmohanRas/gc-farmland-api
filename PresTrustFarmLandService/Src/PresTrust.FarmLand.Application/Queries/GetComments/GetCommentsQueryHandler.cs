namespace PresTrust.FarmLand.Application.Queries;

public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery , IEnumerable<GetCommentsQueryViewModel>>
{

    private readonly IMapper mapper;
    private readonly ITermCommentsRepository repoComment;

    public GetCommentsQueryHandler (
            IMapper mapper,
            ITermCommentsRepository repoComment)
    {
        this.mapper = mapper;
        this.repoComment = repoComment;
    }

    public async Task<IEnumerable<GetCommentsQueryViewModel>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<FarmCommentsEntity> results = default;

        results = await this.repoComment.GetAllCommentsAsync(request.ApplicationId);

        var comments = mapper.Map<IEnumerable<FarmCommentsEntity>, IEnumerable<GetCommentsQueryViewModel>>(results);

        return comments;
    }
}
