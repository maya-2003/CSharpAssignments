using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersistenceLayer
{
    public class DataSeeding(StoreDbContext _storeDbContext) : IDataSeeding
    {
        public void DataSeed()
        {
            try
            {
                if (_storeDbContext.Database.GetPendingMigrations().Any())
                {
                    _storeDbContext.Database.Migrate();
                }
                if (!_storeDbContext.ProductBrands.Any())
                {
                    var productBrandsData = File.ReadAllText(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandsData);
                    if (brands is not null && brands.Any())
                    {
                        _storeDbContext.ProductBrands.AddRange(brands);

                    }
                }

                if (!_storeDbContext.ProductTypes.Any())
                {
                    var productTypesData = File.ReadAllText(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(productTypesData);
                    if (types is not null && types.Any())
                    {
                        _storeDbContext.ProductTypes.AddRange(types);

                    }
                }

                if (!_storeDbContext.Products.Any())
                {
                    var productsData = File.ReadAllText(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    if (products is not null && products.Any())
                    {
                        _storeDbContext.Products.AddRange(products);

                    }
                }

                _storeDbContext.SaveChanges();

            }
            catch (Exception)
            {

                //todo
            }
        }       
    }
}
