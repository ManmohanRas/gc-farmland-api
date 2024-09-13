namespace PresTrust.FarmLand.Application.Commands;

public class DeleteFarmEsmtAttachmentBCommandHandler : IRequestHandler<DeleteFarmEsmtAttachmentBCommand, bool>
{
    private readonly IMapper mapper;
    private readonly IFarmEsmtAttachmentBRepository repoAttachmentB;


    public DeleteFarmEsmtAttachmentBCommandHandler(
        IMapper mapper, 
        IFarmEsmtAttachmentBRepository repoAttachmentB
        )
    {
        this.mapper = mapper;
        this.repoAttachmentB = repoAttachmentB;
    }

    public async Task<bool> Handle(DeleteFarmEsmtAttachmentBCommand request, CancellationToken cancellationToken)
    {
        var AttachmentBDetails = mapper.Map<DeleteFarmEsmtAttachmentBCommand, FarmEsmtAttachmentBEntity>(request);

        await repoAttachmentB.DeleteEsmtAttachmentBDetailsAsync(AttachmentBDetails);
        return true;
    }
}
