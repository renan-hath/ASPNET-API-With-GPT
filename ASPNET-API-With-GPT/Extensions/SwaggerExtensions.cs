using Microsoft.OpenApi.Models;

namespace ASPNET_API_With_GPT.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services,
                                      IConfiguration configuration,
                                      string appName,
                                      string appVersion)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(appVersion, new OpenApiInfo
                {
                    Title = appName,
                    Version = appVersion,
                });

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        public static void UseSwaggerDoc(this IApplicationBuilder app,
                                         string appName)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", appName);
                c.RoutePrefix = "swagger";
            });
        }
    }
}
