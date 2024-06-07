
using Microsoft.OpenApi.Models;

namespace PresTrust.FarmLand.API.DependencyInjection
{
    public class RegisterSwagger : IDependencyInjectionService
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Farm Mitigation API",
                    Version = "v1",
                    Description = "Farm Mitigation API"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. <br/>
                                    Enter 'Bearer' [space] and then your token in the text input below.<br/>
                                    Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                 {
                     new OpenApiSecurityScheme
                     {
                        Reference = new OpenApiReference
                          {
                             Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                           },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                     },
                     new List<string>()
                 }
             });
            });
        }
    }
}
