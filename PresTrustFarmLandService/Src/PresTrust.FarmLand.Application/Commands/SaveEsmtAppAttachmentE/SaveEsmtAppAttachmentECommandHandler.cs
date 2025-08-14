
namespace PresTrust.FarmLand.Application.Commands;
public class SaveEsmtAppAttachmentECommandHandler : BaseHandler, IRequestHandler<SaveEsmtAppAttachmentECommand, int>
{
    private readonly IMapper mapper;
    private readonly IEsmtAppAttachmentERepository repoAttachmentE;
    private readonly IEsmtAppExistUsesRepository repoExistUses;
    private readonly IPresTrustUserContext userContext;


    public SaveEsmtAppAttachmentECommandHandler(
        IMapper mapper,
       IEsmtAppAttachmentERepository repoAttachmentE,
       IEsmtAppExistUsesRepository repoExistUses,
       IPresTrustUserContext userContext)
    { 
        this.mapper = mapper;
        this.repoAttachmentE = repoAttachmentE;
        this.repoExistUses = repoExistUses;
        this.userContext = userContext;
    }
    public async Task<int> Handle(SaveEsmtAppAttachmentECommand request, CancellationToken cancellationToken)
    {
        userContext.DeriveUserProfileFromUserId(request.UserId);
        var attachmentE = mapper.Map<SaveEsmtAppAttachmentECommand, EsmtAppAttachmentEEntity>(request);
        attachmentE.LastUpdatedBy = userContext.Name;

        attachmentE = await repoAttachmentE.SaveEsmtAppAttachmentEAsync(attachmentE);
        return attachmentE.Id;
    }
}
