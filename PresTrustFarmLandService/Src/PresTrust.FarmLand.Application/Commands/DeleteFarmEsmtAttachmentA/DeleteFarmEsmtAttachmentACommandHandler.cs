namespace PresTrust.FarmLand.Application.Commands;

public class DeleteFarmEsmtAttachmentACommandHandler : IRequestHandler<DeleteFarmEsmtAttachmentACommand, bool>
{
    private readonly IMapper mapper;
    private readonly IFarmEsmtAttachmentARepository repoAttachmentA;


    public DeleteFarmEsmtAttachmentACommandHandler(
        IMapper mapper,
        IFarmEsmtAttachmentARepository repoAttachmentA
        )
    {
        this.mapper = mapper;
        this.repoAttachmentA = repoAttachmentA;
    }

    public async Task<bool> Handle(DeleteFarmEsmtAttachmentACommand request, CancellationToken cancellationToken)
    {
        var AttachmentADetails = mapper.Map<DeleteFarmEsmtAttachmentACommand, FarmEsmtAttachmentAEntity>(request);

        await repoAttachmentA.DeleteEsmtAttachmentADetailsAsync(AttachmentADetails);
        return true;
    }
}
