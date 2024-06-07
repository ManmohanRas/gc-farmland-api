namespace PresTrust.FarmLand.API.DependencyInjection
{
    public class RegisterCors : IDependencyInjectionService
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            string[] allowedOrigins = configuration.GetSection(FarmLandDomainConstants.AppSettingKeys.CORS_POLICIES_SECTION).Get<string[]>();
            services.AddCors(options =>
            {
                options.AddPolicy(FarmLandDomainConstants.AppSettingKeys.CORS_POLICY_NAME, builder =>
                {
                    builder.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
        }
    }
}
