global using FluentValidation;
global using FluentValidation.AspNetCore;

namespace PresTrust.FarmLand.API.DependencyInjection
{
    public class RegisterFluentValidator : IDependencyInjectionService
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.Load("PresTrust.FarmLand.Application"));
        }
    }
}
