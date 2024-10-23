namespace PresTrust.FarmLand.API.DependencyInjection;

    public class RegisterContractMappings : IDependencyInjectionService
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPresTrustUserContext, PresTrustUserContext>();
            services.AddTransient<IApplicationRepository, ApplicationRepository>();
            services.AddTransient<IFarmRolesRepository, FarmRolesRepository>();
            services.AddTransient<IFarmListRepository, FarmListRepository>();
            services.AddTransient<IMunicipalFinanceRepository, MunicipalFinanceRepository>();
            services.AddTransient<IMunicipalTrustFundPermittedUsesRepository, MunicipalTrustFundPermittedUsesRepository>();
            services.AddTransient<IApplicationFeedbackRepository, ApplicationFeedbackRepository>();
            services.AddTransient<IOwnerDetailsRepository, OwnerDetailsRepository>();
            services.AddTransient<IApplicationCommentRepository, ApplicationCommentRepository>();
            services.AddTransient <ISiteCharacteristicsRepository, SiteCharacteristicsRepository >();
            services.AddTransient<ITermBrokenRuleRepository, TermBrokenRuleRepository>();
            services.AddTransient<ITermOtherDocumentsRepository, TermOtherDocumentsRepository>();
            services.AddTransient<ITermAppSignatoryRepository, TermAppSignatoryRepository>();
            services.AddTransient<ITermAppAdminDetailsRepository, TermAppAdminDetailsRepository>();
            services.AddTransient<ITermAppAdminContactsRepository, TermAppAdminContactsRepository>();
            services.AddTransient<IEmailManager, EmailManager>();
            services.AddTransient<IEmailTemplateRepository, EmailTemplateRepository>();
            services.AddTransient<IFarmBlockLotRepository, FarmBlockLotRepository>();
            services.AddTransient<ITermAppAdminDeedDetailsRepository, TermAppAdminDeedDetailsRepository>();
            services.AddTransient<IApplicationLocationRepository, ApplicationLocationRepository>();
            services.AddTransient<IFarmParcelHistoryRepository, FarmParcelHistoryRepository>();
            services.AddTransient<IEsmtAppStructureRepository, EsmtAppStructureRepository>();
            services.AddTransient<IEsmtOwnerDetailsRepository, EsmtOwnerDetailsRepository>();
            services.AddTransient<IFarmEsmtExceptionsRepository, FarmEsmtExceptionsRepository>();
            services.AddTransient<IEsmtLiensReposioty, EsmtLiensRepository>();
            services.AddTransient<IEsmtAppSignatoryRepository, EsmtAppSignatoryRepository>();
            services.AddTransient<IFarmEsmtAttachmentBRepository, FarmEsmtAttachmentBRepository>();
            services.AddTransient<IEsmtAppExistUsesRepository, EsmtAppExistUsesRepository>();
            services.AddTransient<IEsmtAppAttachmentCRepository, EsmtAppAttachmentCRepository>();
            services.AddTransient<IFarmEsmtAgriculturalEnterpriseRepository, FarmEsmtAgriculturalEnterpriseRepository>();
            services.AddTransient<IEsmtAppAttachmentDRepository, EsmtAppAttachmentDRepository>();
           services.AddTransient<IEsmtAppAttachmentERepository, EsmtAppAttachmentERepository>();
           services.AddTransient<IFarmEsmtAttachmentARepository, FarmEsmtAttachmentARepository>();
           services.AddTransient<IEsmtAppAdminSADCRepository, EsmtAppAdminSADCRepository>();
           services.AddTransient<IEsmtAppAdminExceptionRDSORepository, EsmtAppAdminExceptionRDSORepository>();
            services.AddTransient<IEsmtAppAdminOfferCostsRepository, EsmtAppAdminOfferCostsRepository>();
            services.AddTransient<IFarmEsmtAppAdminClosingDocsRepository, EsmtAppAdminClosingDocsRepository>();
            services.AddTransient<IFarmEsmtAppAdminCostDetailsRepository, FarmEsmtAppAdminCostDetailsRepository>();
              services.AddTransient<IFarmEsmtAppAdminAppraisalReportRepository, EsmtAppAdminAppraisalReportRepository>();

        }
    }

