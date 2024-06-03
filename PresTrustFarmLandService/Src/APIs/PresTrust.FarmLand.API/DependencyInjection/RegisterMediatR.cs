namespace PresTrust.FarmLand.API.DependencyInjection
{
    public class RegisterMediatR : IDependencyInjectionService
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config => {

                config.RegisterServicesFromAssemblies(Assembly.Load("PresTrust.FarmLand.Application"));
            });
        }
    }

}
