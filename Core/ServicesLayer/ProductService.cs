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


namespace ServicesLayer
{
    public class ProductService (IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var repo = _unitOfWork.GetRepository<ProductBrand, int>();
            var brands = await repo.GetALLAsync();
            var brandsDtos = _mapper. Map<IEnumerable<BrandDto>>(brands);
            return brandsDtos;
            

        }

        public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams queryParams)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            var specs = new ProductWithBrandAndTypeSpecification(queryParams);
            var products =  await repo.GetALLAsync();
            var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(products);
            var countSpecs= new ProductCountSpecifications(queryParams);
            var totalCount=await repo.CountAsync(countSpecs);
            return new PaginatedResult<ProductDto>(queryParams.PageIndex, queryParams.PageSize, 0, mappedProducts);
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var types=  await _unitOfWork.GetRepository<ProductType, int>().GetALLAsync();
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
