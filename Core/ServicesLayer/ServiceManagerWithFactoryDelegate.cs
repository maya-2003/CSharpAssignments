using ServiceAbstractionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer
{
    public class ServiceManagerWithFactoryDelegate(Func<IProductService> productServiceFactory, Func<IBasketService> basketServiceFactory, Func<IAuthenticationService> authenticationServiceFactory, Func<IOrderService> orderServiceFactory) : IServiceManager
    {
        public IProductService ProductService => productServiceFactory.Invoke();

        public IBasketService BasketService => basketServiceFactory.Invoke();

        public IAuthenticationService AuthenticationService =>authenticationServiceFactory.Invoke();

        public IOrderService OrderService => orderServiceFactory.Invoke();
    }
}
