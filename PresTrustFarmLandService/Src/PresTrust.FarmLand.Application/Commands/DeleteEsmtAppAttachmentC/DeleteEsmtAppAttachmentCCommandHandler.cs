
namespace PresTrust.FarmLand.Application.Commands;

public class DeleteEsmtAppAttachmentCCommandHandler : BaseHandler, IRequestHandler<DeleteEsmtAppAttachmentCCommand, bool>
{

    private readonly IMapper mapper;
    private readonly IEsmtAppAttachmentCRepository repoAttachmentC;

    public DeleteEsmtAppAttachmentCCommandHandler(
        IMapper mapper,
        IEsmtAppAttachmentCRepository repoAttachmentC
        )
    { 
      this.mapper = mapper;
      this.repoAttachmentC = repoAttachmentC;
    
    }
    public async Task<bool> Handle(DeleteEsmtAppAttachmentCCommand request, CancellationToken cancellationToken)
    {
        var AttachmentCDetails = mapper.Map<DeleteEsmtAppAttachmentCCommand, EsmtAppAttachmentCEntity>(request);

        await repoAttachmentC.DeleteEsmtAppAttachmentCAsync(AttachmentCDetails);
        return true;
    }
}
