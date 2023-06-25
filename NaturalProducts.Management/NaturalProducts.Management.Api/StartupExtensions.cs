using Microsoft.OpenApi.Models;
using NaturalProducts.Management.Application;
using NaturalProducts.Management.Persistence;

namespace NaturalProducts.Management.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices (this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);

            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin()
                .AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NaturalProducts Management API");
                });
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseCors("Open");

            app.MapControllers();

            return app;
        }

        private static void AddSwagger(IServiceCollection services)
        {            
            services.AddSwaggerGen(c =>
            {                
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "NaturalProducts Management API",

                });
            });
        }
    }
}
