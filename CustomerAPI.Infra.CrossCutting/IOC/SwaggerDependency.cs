using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace CustomerAPI.Infra.CrossCutting.IOC
{
    public static class SwaggerDependency
    {
        public static void AddSwaggerDependency(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.EnableAnnotations();
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Customer API",
                    Version = "v1",
                    Description = "Documentation of Customer API",
                    Contact = new OpenApiContact
                    {
                        Name = "Cristiane Stallivieri",
                        Email = "cstallivieri@gmail.com"
                    }
                });

                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });

                opt.OperationFilter<SecurityRequirementsOperationFilter>();

            });
        }

        public static void UseSwaggerDependency(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "docs/{documentName}/docs.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "Customer API";
                c.SwaggerEndpoint("/docs/v1/docs.json", "Customer API - v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
