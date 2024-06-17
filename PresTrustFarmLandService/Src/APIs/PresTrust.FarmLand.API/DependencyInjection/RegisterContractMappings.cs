namespace PresTrust.FarmLand.API.DependencyInjection
{
    public class RegisterContractMappings : IDependencyInjectionService
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPresTrustUserContext, PresTrustUserContext>();
            services.AddTransient<IApplicationRepository, ApplicationRepository>();
            services.AddTransient<IFarmListRepository, FarmListRepository>();
        }
    }
}
