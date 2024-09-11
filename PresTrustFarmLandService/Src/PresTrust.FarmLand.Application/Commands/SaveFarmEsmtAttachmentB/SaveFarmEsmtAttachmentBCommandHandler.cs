namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAttachmentBCommandHandler : BaseHandler, IRequestHandler<SaveFarmEsmtAttachmentBCommand, int>
{
    private readonly IMapper mapper;
    private readonly IFarmEsmtAttachmentBRepository repoAttachmentB;
    private readonly IFarmEsmtExceptionsRepository repoExceptions;
    private readonly IPresTrustUserContext userContext;



    public SaveFarmEsmtAttachmentBCommandHandler(
        IMapper mapper, 
        IFarmEsmtAttachmentBRepository repoAttachmentB,
        IFarmEsmtExceptionsRepository repoExceptions,
        IPresTrustUserContext userContext
        )
    {
        this.mapper = mapper;
        this.repoAttachmentB = repoAttachmentB;
        this.repoExceptions = repoExceptions;
        this.userContext = userContext;
    }

    public async Task<int> Handle(SaveFarmEsmtAttachmentBCommand request, CancellationToken cancellationToken)
    {
        var attachmentB = mapper.Map<SaveFarmEsmtAttachmentBCommand, FarmEsmtAttachmentBEntity>(request);
        attachmentB.LastUpdatedBy = userContext.Name;
       
        attachmentB = await repoAttachmentB.SaveEsmtAttachmentBDetailsAsync(attachmentB);

        return attachmentB.Id;
    }

}
