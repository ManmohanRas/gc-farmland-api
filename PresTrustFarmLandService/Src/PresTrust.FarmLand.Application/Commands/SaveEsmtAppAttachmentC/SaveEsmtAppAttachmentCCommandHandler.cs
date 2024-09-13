
namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAttachmentCCommandHandler : BaseHandler, IRequestHandler<SaveEsmtAppAttachmentCCommand, int>
{

    private readonly IMapper mapper;
    private readonly IEsmtAppAttachmentCRepository repoAttachmentC;
    private readonly IEsmtAppExistUsesRepository repoExistUses;
    private readonly IPresTrustUserContext userContext;

    public SaveEsmtAppAttachmentCCommandHandler(
        IMapper mapper,
        IEsmtAppAttachmentCRepository repoAttachmentC,
        IEsmtAppExistUsesRepository repoExistUses,
        IPresTrustUserContext userContext
        ) { 
       this.mapper = mapper;
        this.repoAttachmentC = repoAttachmentC;
        this.repoExistUses = repoExistUses;
        this.userContext = userContext;    
    }

    public async Task<int> Handle(SaveEsmtAppAttachmentCCommand request, CancellationToken cancellationToken)
    {

        var attachmentC = mapper.Map<SaveEsmtAppAttachmentCCommand, EsmtAppAttachmentCEntity>(request);
        attachmentC.LastUpdatedBy = userContext.Name;

        attachmentC = await repoAttachmentC.SaveEsmtAppAttachmentCAsync(attachmentC);

        return attachmentC.Id;
    }
}
