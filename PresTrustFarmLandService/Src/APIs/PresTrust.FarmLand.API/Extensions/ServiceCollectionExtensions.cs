using Azure;
using System.Net;

namespace PresTrust.FarmLand.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            new RegisterApiResources().Register(services, configuration);
            new RegisterMediatR().Register(services, configuration);
            new RegisterAutoMapper().Register(services, configuration);
            new RegisterFluentValidator().Register(services, configuration);
            new RegisterContractMappings().Register(services, configuration);
            new RegisterSqlDbContexts().Register(services, configuration);

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ApiExceptionFilterAttribute));
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            //Produces Response Type
            services.AddMvc(o =>
            {
                o.Filters.Add(new ProducesResponseTypeAttribute((int)HttpStatusCode.NotFound));
                o.Filters.Add(new ProducesResponseTypeAttribute((int)HttpStatusCode.BadRequest));
                o.Filters.Add(new ProducesResponseTypeAttribute((int)HttpStatusCode.InternalServerError));
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
