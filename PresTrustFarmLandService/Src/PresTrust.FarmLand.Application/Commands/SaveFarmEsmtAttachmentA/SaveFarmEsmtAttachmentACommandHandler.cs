using PresTrust.FarmLand.Application.Commands.SaveFarmEsmtAttachmentA;

namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAttachmentACommandHandler : BaseHandler, IRequestHandler<SaveFarmEsmtAttachmentACommand, int>
{
    private readonly IMapper mapper;
    private readonly IFarmEsmtAttachmentARepository repoAttachmentA;
    private readonly IPresTrustUserContext userContext;


    public SaveFarmEsmtAttachmentACommandHandler(
        IMapper mapper,
        IFarmEsmtAttachmentARepository repoAttachmentA,
        IPresTrustUserContext userContext
        )
    {
        this.mapper = mapper;
        this.repoAttachmentA = repoAttachmentA;
        this.userContext = userContext;
    }

    public async Task<int> Handle(SaveFarmEsmtAttachmentACommand request, CancellationToken cancellationToken)
    {
        var attachmentA = mapper.Map<SaveFarmEsmtAttachmentACommand, FarmEsmtAttachmentAEntity>(request);
        attachmentA.LastUpdatedBy = userContext.Name;

        attachmentA = await repoAttachmentA.SaveEsmtAttachmentADetailsAsync(attachmentA);

        return attachmentA.Id;
    }
}
