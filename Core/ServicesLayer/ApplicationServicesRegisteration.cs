using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceAbstractionLayer;
using ServicesLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer
{
    public static class ApplicationServicesRegisteration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
        {
            Services.AddAutoMapper((x) => { }, typeof(ServiceLayerAssemblyReference).Assembly);
            Services.AddScoped<IServiceManager, ServiceManagerWithFactoryDelegate>();
            Services.AddScoped<ICacheService, CacheService>();

            #region Register Product Service
            Services.AddScoped<IProductService, ProductService>();
            Services.AddScoped<Func<IProductService>>(provider => () => provider.GetRequiredService<IProductService>());
            #endregion

            #region Register Basket Service
            Services.AddScoped<IBasketService, BasketService>();
            Services.AddScoped<Func<IBasketService>>(provider => () => provider.GetRequiredService<IBasketService>());
            #endregion

            #region Register Order Service
            Services.AddScoped<IOrderService, OrderService>();
            Services.AddScoped<Func<IOrderService>>(provider => () => provider.GetRequiredService<IOrderService>());
            #endregion

            #region Register Authentication Service
            Services.AddScoped<IAuthenticationService, AuthenticationService>();
            Services.AddScoped<Func<IAuthenticationService>>(provider => () => provider.GetRequiredService<IAuthenticationService>());
            #endregion

       


            return Services;
        }
    }
}
