
namespace PresTrust.FarmLand.Application.Queries;

public class GetTermAppAdminDeedDetailsQueryHandler :BaseHandler, IRequestHandler<GetTermAppAdminDeedDetailsQuery, GetTermAppAdminDeedDetailsQueryViewModel>
{

    private readonly IMapper mapper;
    private readonly ITermAppAdminDeedDetailsRepository repoDeedDetails;
    private ITermOtherDocumentsRepository repoOtherDocument;
    private IApplicationRepository repoApplication;
    private IApplicationLocationRepository repoLocation;

    public GetTermAppAdminDeedDetailsQueryHandler
    (
        IMapper mapper,
        ITermAppAdminDeedDetailsRepository repoDeedDetails,
        ITermOtherDocumentsRepository repoOtherDocument,
        IApplicationRepository repoApplication,
        IApplicationLocationRepository repoLocation
    ) :base(repoApplication:repoApplication)
    {
        this.mapper = mapper;
        this.repoDeedDetails = repoDeedDetails;
        this.repoOtherDocument = repoOtherDocument;
        this.repoLocation  = repoLocation;
    }
    public async Task<GetTermAppAdminDeedDetailsQueryViewModel> Handle(GetTermAppAdminDeedDetailsQuery request, CancellationToken cancellationToken)
    {
        var application = await GetIfApplicationExists(request.ApplicationId);  
        
        var result = new GetTermAppAdminDeedDetailsQueryViewModel();

        var deeddetails = await this.repoDeedDetails.GetTermAppAdminDeedDetails(request.ApplicationId);
        var locationDetails = await repoLocation.GetParcelsByFarmID(application.Id, application.FarmListId);
        if (deeddetails.Count() == 0)
        {
            foreach (var item in locationDetails)
            {
                if (item.IsChecked)
                {
                    deeddetails.Add(new TermAppAdminDeedDetailsEntity()
                    {
                        ApplicationId = application.Id,
                        OriginalBlock = item.Block,
                        OriginalLot = item.Lot,
                        OriginalBook = item.DeedBook,
                        OriginalPage = item.DeedPage
                    });
                }   
            }
        }
        result.DeedDetails = mapper.Map<IEnumerable<TermAppAdminDeedDetailsEntity>, IEnumerable<TermAppAdminDeedDetailsViewModel>>(deeddetails);

        var documents = await GetDocuments(request.ApplicationId);
        result.DocumentsTree = documents ?? new List<DocumentTypeViewModel>();

        return result;
    }

    private async Task<List<DocumentTypeViewModel>> GetDocuments(int applicationId)
    {
        var documents = await repoOtherDocument.GetTermDocumentsAsync(applicationId, (int)TermAppSectionEnum.ADMIN_DEED_DETAILS);

        List<DocumentTypeViewModel> documentsTree = new List<DocumentTypeViewModel>();
        if (documents != null)
        {
            var docBuilder = new ApplicationDocumentTreeBuilder(documents);
            documentsTree = docBuilder.DocumentsTree;
        }
        return documentsTree;
    }

}

