
namespace PresTrust.FarmLand.Application.Commands;
public class DeleteEsmtAppAttachmentECommandHandler : BaseHandler, IRequestHandler<DeleteEsmtAppAttachmentECommand, bool>
{
    private readonly IMapper mapper;
    private readonly IEsmtAppAttachmentERepository repoAttachmentE;

    public DeleteEsmtAppAttachmentECommandHandler(
        IMapper mapper,
        IEsmtAppAttachmentERepository repoAttachmentE)
    {
        this.mapper = mapper;
        this.repoAttachmentE = repoAttachmentE;
    }
    public async Task<bool> Handle(DeleteEsmtAppAttachmentECommand request, CancellationToken cancellationToken)
    {
        var AttachmentEDetails = mapper.Map<DeleteEsmtAppAttachmentECommand, EsmtAppAttachmentEEntity>(request);

        await repoAttachmentE.DeleteEsmtAppAttachmentEAsync(AttachmentEDetails);
        return true;
    }
}
