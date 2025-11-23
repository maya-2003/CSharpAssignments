using ServiceAbstractionLayer;
using DomainLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLayer.Specification;
using Shared;
using DomainLayer.Exceptions;
using DomainLayer.Models.ProductModels;
using Shared.DTOs.ProductDtos;
using ServicesLayer.Specification.ProductModuleSpecifications;


namespace ServicesLayer.Services
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var repo = _unitOfWork.GetRepository<ProductBrand, int>();
            var brands = await repo.GetALLAsync();
            var brandsDtos = _mapper.Map<IEnumerable<BrandDto>>(brands);
            return brandsDtos;


        }

        public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams queryParams)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            var specs = new ProductWithBrandAndTypeSpecification(queryParams);
            var countSpecs = new ProductCountSpecifications(queryParams);
            var products = await repo.GetAllAsync(specs);
            var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(products);
            
            var totalCount = await repo.CountAsync(countSpecs);
            return new PaginatedResult<ProductDto>(queryParams.PageNumber, queryParams.PageSize, totalCount, mappedProducts);
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetALLAsync();
            return _mapper.Map<IEnumerable<TypeDto>>(types);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var specs = new ProductWithBrandAndTypeSpecification(id);
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(specs);
            if (product is null) throw new ProductNotFoundException(id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
