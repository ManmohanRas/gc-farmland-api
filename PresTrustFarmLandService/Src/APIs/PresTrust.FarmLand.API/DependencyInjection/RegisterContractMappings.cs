
using PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;
using PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;
using PresTrust.FarmLand.Infrastructure.SqlServerDb;

namespace PresTrust.FarmLand.API.DependencyInjection
{
    public class RegisterContractMappings : IDependencyInjectionService
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IApplicationRepository, ApplicationRepository>();
        }
    }
}
