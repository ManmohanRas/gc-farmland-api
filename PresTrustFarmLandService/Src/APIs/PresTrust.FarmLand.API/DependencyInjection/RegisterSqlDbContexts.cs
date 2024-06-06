namespace PresTrust.FarmLand.API.DependencyInjection
{
    public class RegisterSqlDbContexts : IDependencyInjectionService
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<PresTrustSqlDbContext>();
        }
    }
}
