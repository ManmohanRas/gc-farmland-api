namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtExceptionsQueryHandler : BaseHandler, IRequestHandler<GetFarmEsmtExceptionsQuery, GetFarmEsmtExceptionsQueryViewModel>
{
    private readonly IMapper mapper;
    private readonly IFarmEsmtExceptionsRepository repoexceptionsDetails;
    private readonly IApplicationRepository repoApplication;
    private readonly IFarmEsmtAttachmentBRepository repoAttachmentB;
    
    public GetFarmEsmtExceptionsQueryHandler
       (
             IMapper mapper,
           IFarmEsmtExceptionsRepository repoexceptionsDetails,
           IFarmEsmtAttachmentBRepository repoAttachmentB,
           IApplicationRepository repoApplication
        ) : base(repoApplication: repoApplication)
    {
         this.mapper = mapper;
         this.repoexceptionsDetails = repoexceptionsDetails;
         this.repoAttachmentB = repoAttachmentB;
         this.repoApplication = repoApplication;
    }


    public async Task<GetFarmEsmtExceptionsQueryViewModel> Handle(GetFarmEsmtExceptionsQuery request, CancellationToken cancellationToken)
    {
        FarmEsmtExceptionsEntity results = default;

        var application = await GetIfApplicationExists(request.ApplicationId);
        var reqExceptionDetails = await repoexceptionsDetails.GetEsmtExceptionsDetailsAsync(request.ApplicationId);
        var attachmentBs = await repoAttachmentB.GetEsmtAttachmentBAsync(request.ApplicationId);

        var exceptionDetails = mapper.Map<FarmEsmtExceptionsEntity, GetFarmEsmtExceptionsQueryViewModel>(reqExceptionDetails);

        exceptionDetails.AttachmentBs = mapper.Map<IEnumerable<FarmEsmtAttachmentBEntity>, IEnumerable<FarmEsmtAttachmentBViewModel>>(attachmentBs);
        return exceptionDetails;
    }
}
