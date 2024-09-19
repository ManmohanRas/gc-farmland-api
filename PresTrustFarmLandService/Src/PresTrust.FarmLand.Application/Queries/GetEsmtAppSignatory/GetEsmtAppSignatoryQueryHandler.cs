namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppSignatoryQueryHandler : BaseHandler, IRequestHandler<GetEsmtAppSignatoryQuery, GetEsmtAppSignatoryQueryViewModel>
{
    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private IEsmtAppSignatoryRepository repoSignatory;
    private readonly IFarmEsmtAttachmentARepository repoAttachmentA;


    public GetEsmtAppSignatoryQueryHandler(
        IMapper mapper,
        IApplicationRepository repoApplication,
        IEsmtAppSignatoryRepository repoSignatory,
        IFarmEsmtAttachmentARepository repoAttachmentA
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoAttachmentA = repoAttachmentA;
        this.repoSignatory = repoSignatory;
    }

    public async Task<GetEsmtAppSignatoryQueryViewModel> Handle(GetEsmtAppSignatoryQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // get signatory details
        var signatory = await this.repoSignatory.GetSignatoryAsync(request.ApplicationId);
        var attachmentAs = await repoAttachmentA.GetEsmtAttachmentAAsync(request.ApplicationId);
        var result = mapper.Map<FarmEsmtAppSignatoryEntity, GetEsmtAppSignatoryQueryViewModel>(signatory);
        result.AttachmentAs = mapper.Map<IEnumerable<FarmEsmtAttachmentAEntity>, IEnumerable<FarmEsmtAttachmentAViewModel>>(attachmentAs);

        return result;
    }
}
