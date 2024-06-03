namespace PresTrust.FarmLand.API.Contracts
{
    public interface IDependencyInjectionService
    {
        void Register(IServiceCollection services, IConfiguration configuration);
    }
}
