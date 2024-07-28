using Application.Repository;
using Application.Services;
using HardwareStock.Core.Application.Interfaces.Repositories;
using HardwareStock.Infrastructure.Persistence.Contexts;
using HardwareStock.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareStock.Infrastructure.Persistence
{
    //Extension Method - Decorator pattern
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            //Configuration to connect the DB
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<HardwareContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<HardwareContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                m => m.MigrationsAssembly(typeof(HardwareContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            #endregion
        }
    }
}
