using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace UserSvc.Infrastructure.Extensions
{
    public static class SwaggerInstaller
    {
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "User Service",
                    Description = "User Service",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Jigar Acharya",
                        Email = "jigaracharya@gmail.com",
                        Url = new Uri("https://twitter.com/jigaracharya"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                //c.SchemaFilter<>
                //c.IncludeXmlComments("api.xml");
            });

        }

        public static void UseSwaggerService(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseSwagger();

            applicationBuilder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserSvc V1");
            });
        }


    }
}
