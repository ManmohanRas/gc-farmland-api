namespace PresTrust.FarmLand.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            new RegisterMediatR().Register(services, configuration);
            new RegisterAutoMapper().Register(services, configuration);
            new RegisterFluentValidator().Register(services, configuration);
            new RegisterContractMappings().Register(services, configuration);
            new RegisterSqlDbContexts().Register(services, configuration);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
