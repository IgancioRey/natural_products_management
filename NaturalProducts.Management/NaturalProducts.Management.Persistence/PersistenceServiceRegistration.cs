using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NaturalProducts.Management.Application.Contracts.Persistence;
using NaturalProducts.Management.Persistence.Repositories;
using NaturalProducts.Management.Persistence.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices (this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddDbContext<NaturalProductsDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("NaturalProductsManagementConnectionString")));

            services.Configure<MongoDBSettings>(configuration.GetSection("MongoDB"));

            services.AddSingleton<MongoDbContext>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(MongoRepository<>));

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
