namespace PresTrust.FarmLand.API.DependencyInjection
{
    public class RegisterAutoMapper : IDependencyInjectionService
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
              services.AddAutoMapper(Assembly.Load("PresTrust.FarmLand.Application"));
        }
    }
}
