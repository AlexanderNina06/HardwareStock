using Application.Services;
using HardwareStock.Core.Application.Interfaces.Services;
using HardwareStock.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HardwareStock.Infrastructure.Persistence
{
    //Extension Method - Decorator pattern
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services,IConfiguration configuration)
        {

            #region Service
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            #endregion

        }
    }
}
