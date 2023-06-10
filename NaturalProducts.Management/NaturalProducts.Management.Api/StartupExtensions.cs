using NaturalProducts.Management.Application;
using NaturalProducts.Management.Persistence;

namespace NaturalProducts.Management.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices (this WebApplicationBuilder builder)
        {
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
            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseCors("Open");

            app.MapControllers();

            return app;
        }
    }
}
