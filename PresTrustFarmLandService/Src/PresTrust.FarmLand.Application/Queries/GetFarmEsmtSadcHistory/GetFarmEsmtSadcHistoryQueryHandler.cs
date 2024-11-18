namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtSadcHistoryQueryHandler : BaseHandler, IRequestHandler<GetFarmEsmtSadcHistoryQuery, GetFarmEsmtSadcHistoryQueryViewModel>
{
        private readonly IMapper mapper;
        private readonly IApplicationRepository repoApplication;
        private readonly IFarmEsmtSadcHistoryRepository repoSadcHistory;
        private IEsmtAppAttachmentERepository repoAttachmentE;
        private IEsmtLiensReposioty repoliens;


        public GetFarmEsmtSadcHistoryQueryHandler
           (
               IMapper mapper,
               IFarmEsmtSadcHistoryRepository repoSadcHistory,
               IEsmtAppAttachmentERepository repoAttachmentE,
               IEsmtLiensReposioty repoliens,
               IApplicationRepository repoApplication
            ) : base(repoApplication: repoApplication)
        {
            this.mapper = mapper;
            this.repoSadcHistory = repoSadcHistory;
            this.repoApplication = repoApplication;
            this.repoAttachmentE = repoAttachmentE;
            this.repoliens = repoliens;
        }

        public async Task<GetFarmEsmtSadcHistoryQueryViewModel> Handle(GetFarmEsmtSadcHistoryQuery request, CancellationToken cancellationToken)
        {
            //get application details
            var application = await GetIfApplicationExists(request.ApplicationId);

            var reqSadcHistory = await repoSadcHistory.GetSadcHistoryAsync(request.ApplicationId);

            // Lines Esmt 
            var linesEsmt = await repoliens.GetLiensAsync(request.ApplicationId);
            linesEsmt = linesEsmt ?? new EsmtLiensEntity();

            // Map or assign attachmentE
            var attachmentEResult = await repoAttachmentE.GetEsmtAppAttachmentEAsync(request.ApplicationId);
            var attachmentE = attachmentEResult?.FirstOrDefault() != null
            ? mapper.Map<EsmtAppAttachmentEEntity>(attachmentEResult.FirstOrDefault())
            : new EsmtAppAttachmentEEntity();

            var sadcHistoryDetails = mapper.Map<FarmEsmtSadcHistoryEntity, GetFarmEsmtSadcHistoryQueryViewModel>(reqSadcHistory);
            sadcHistoryDetails.PropertySale = linesEsmt.PropertySale;
            sadcHistoryDetails.EstateSituation = linesEsmt.EstateSituation;
            sadcHistoryDetails.Bankruptcy = linesEsmt.Bankruptcy;
            sadcHistoryDetails.ForeClosure = linesEsmt.ForeClosure;
            sadcHistoryDetails.ScaleofSubdivision = attachmentE.ScaleofSubdivision;
            sadcHistoryDetails.TypeOfDevelopment = attachmentE.TypeOfDevelopment;
            sadcHistoryDetails.PreliminaryApprovalDate = attachmentE.PreliminaryApprovalDate;
            sadcHistoryDetails.FinalApprovalDate = attachmentE.FinalApprovalDate;

           return sadcHistoryDetails;

        }
}
