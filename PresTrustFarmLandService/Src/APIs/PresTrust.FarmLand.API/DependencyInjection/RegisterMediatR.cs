namespace PresTrust.FarmLand.API.DependencyInjection
{
    public class RegisterMediatR : IDependencyInjectionService
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config => {

                config.RegisterServicesFromAssemblies(Assembly.Load("PresTrust.FarmLand.Application"));
            });

            // Register MediatR pipeline behaviors, in the same order the behaviors should be called.
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        }
    }

}
