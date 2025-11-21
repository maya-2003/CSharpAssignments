using AutoMapper;
using DomainLayer.Contracts;
using ServiceAbstractionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer
{
    public class ServiceManager (IUnitOfWork _unitofWork,IMapper _mapper, IBasketRepository _basketRepository) : IServiceManager
    {
        private readonly Lazy<IProductService> _lazyProductService = new Lazy<IProductService> (()=> new ProductService(_unitofWork, _mapper));
        public IProductService ProductService => _lazyProductService.Value;

        private readonly Lazy<IBasketService> _lazyBasketService = new Lazy<IBasketService>(() => new BasketService(_basketRepository, _mapper));
        public IBasketService BasketService => _lazyBasketService.Value;
    }
}
