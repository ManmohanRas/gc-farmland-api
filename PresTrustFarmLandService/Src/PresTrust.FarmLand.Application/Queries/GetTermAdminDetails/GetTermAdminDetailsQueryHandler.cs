namespace PresTrust.FarmLand.Application.Queries;

public class GetTermAdminDetailsQueryHandler : BaseHandler, IRequestHandler<GetTermAdminDetailsQuery, GetTermAdminDetailsQueryViewModel>
{

    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private ITermAppAdminDetailsRepository repoTermAppAdminDetailsRepository;
    private ITermOtherDocumentsRepository repoTermOtherDocumentsRepository;
   

    public GetTermAdminDetailsQueryHandler
        (
        IMapper mapper,
        IApplicationRepository repoApplication,
        ITermOtherDocumentsRepository repoTermOtherDocumentsRepository,
        ITermAppAdminDetailsRepository repoTermAppAdminDetailsRepository
        
        ) : base(repoApplication: repoApplication)
    {

        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoTermOtherDocumentsRepository = repoTermOtherDocumentsRepository;
        this.repoTermAppAdminDetailsRepository = repoTermAppAdminDetailsRepository;
      
       
    }

    
    public async Task<GetTermAdminDetailsQueryViewModel> Handle(GetTermAdminDetailsQuery request, CancellationToken cancellationToken)
    {
        //get application details
        var application = await GetIfApplicationExists(request.ApplicationId);
        var documents = await GetDocuments(request.ApplicationId); 

        //get Admin details
        var admindetails = await this.repoTermAppAdminDetailsRepository.GetTermAppAdminDetailsAsync(request.ApplicationId);
        var result = mapper.Map<FarmTermAppAdminDetailsEntity, GetTermAdminDetailsQueryViewModel>(admindetails);
        result.DocumentsTree = documents?? new List<DocumentTypeViewModel>() ;
        
        return result;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    private async Task<List<DocumentTypeViewModel>> GetDocuments(int applicationId)
    {
        var documents = await repoTermOtherDocumentsRepository.GetTermDocumentsAsync(applicationId, (int)TermAppSectionEnum.ADMIN_DETAILS);

        List<DocumentTypeViewModel> documentsTree = new List<DocumentTypeViewModel>();
        if (documents != null)
        {
            var docBuilder = new ApplicationDocumentTreeBuilder(documents);
            documentsTree = docBuilder.DocumentsTree;
        }
        
        return documentsTree;
    }

}
