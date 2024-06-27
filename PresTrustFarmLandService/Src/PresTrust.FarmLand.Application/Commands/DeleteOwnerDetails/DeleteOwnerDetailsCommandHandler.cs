namespace PresTrust.FarmLand.Application.Commands;

public class DeleteOwnerDetailsCommandHandler : IRequestHandler<DeleteOwnerDetailsCommand, bool>
{
    private readonly IMapper mapper;
    private readonly IOwnerDetailsRepository repoOwner;

    public DeleteOwnerDetailsCommandHandler(
        IMapper mapper,
        IOwnerDetailsRepository repoOwner)
    {
        this.mapper = mapper;
        this.repoOwner = repoOwner;
    }
    public async Task<bool> Handle(DeleteOwnerDetailsCommand request, CancellationToken cancellationToken)
    {
        await repoOwner.DeleteOwnerDetailsAsync(request.ApplicationId, request.Id);
        return true;
    }
}
