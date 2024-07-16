namespace PresTrust.FarmLand.API.DependencyInjection
{
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
            services.AddTransient<ITermFeedbacksRepository, TermFeedbacksRepository>();
            services.AddTransient<IOwnerDetailsRepository, OwnerDetailsRepository>();
            services.AddTransient<ITermCommentsRepository, TermCommentsRepository>();
            services.AddTransient <ISiteCharacteristicsRepository, SiteCharacteristicsRepository >();
            services.AddTransient<ITermBrokenRuleRepository, TermBrokenRuleRepository>();
            services.AddTransient<ITermOtherDocumentsRepository, TermOtherDocumentsRepository>();
            services.AddTransient<ITermAppSignatoryRepository, TermAppSignatoryRepository>();
            services.AddTransient<ITermAppAdminDetailsRepository, TermAppAdminDetailsRepository>();
            services.AddTransient<ITermAppAdminContactsRepository, TermAppAdminContactsRepository>();
            services.AddTransient<IEmailManager, EmailManager>();
            services.AddTransient<IEmailTemplateRepository, EmailTemplateRepository>();
        }
    }
}
