using MediatR;
using System;

namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppExistUsesQueryHandler : BaseHandler, IRequestHandler<GetEsmtAppExistUsesQuery, GetEsmtAppExistUsesQueryViewModel>
{
    IMapper mapper;
    public IEsmtAppExistUsesRepository repoExistUses;
    private readonly IApplicationRepository repoApplication;
    private ITermOtherDocumentsRepository repoDocuments;
    
    public GetEsmtAppExistUsesQueryHandler(
          IMapper mapper,
         IApplicationRepository repoApplication,
         IEsmtAppExistUsesRepository repoExistUses,
          ITermOtherDocumentsRepository repoDocuments
        ) :base(repoApplication : repoApplication)
    {
        this.mapper = mapper;
        this.repoExistUses = repoExistUses;
        this.repoApplication = repoApplication;
        this.repoDocuments = repoDocuments;

    }
    public async Task<GetEsmtAppExistUsesQueryViewModel> Handle(GetEsmtAppExistUsesQuery request, CancellationToken cancellationToken)
    {
        var application = await repoApplication.GetApplicationAsync(request.ApplicationId);
        var existUses = await repoExistUses.GetEsmtAppExistUses(application.Id);
        var documents = await GetDocuments(request.ApplicationId);
        var result = mapper.Map<EsmtAppExistUsesEntity, GetEsmtAppExistUsesQueryViewModel>(existUses);   
        result.DocumentsTree = documents ?? new List<DocumentTypeViewModel>();
        return result;
    }


    public async Task<List<DocumentTypeViewModel>> GetDocuments(int ApplicationId)
    {

        var documents = await repoDocuments.GetTermDocumentsAsync(ApplicationId, (int)TermAppSectionEnum.ESMT_EXIS_NON_AGRI_USES);

        List<DocumentTypeViewModel> documentsTree = new List<DocumentTypeViewModel>();

        if (documents != null) {
            var docBuilder = new ApplicationDocumentTreeBuilder(documents);
            documentsTree = docBuilder.DocumentsTree;

        }
        return documentsTree;

    }
}
