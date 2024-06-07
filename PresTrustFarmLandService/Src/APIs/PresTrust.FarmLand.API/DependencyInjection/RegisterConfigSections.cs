namespace PresTrust.FarmLand.API.DependencyInjection
{
    public class RegisterConfigSections : IDependencyInjectionService
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SystemParameterConfiguration>(configuration.GetSection(FarmLandDomainConstants.AppSettingKeys.SYSTEM_PARAMETER_SECTION));
        }
    }
}
