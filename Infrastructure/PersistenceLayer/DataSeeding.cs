using DomainLayer.Contracts;
using DomainLayer.Models.ProductModels;
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
        public async Task DataSeedAsync()
        {
            try
            {
                if ((await _storeDbContext.Database.GetPendingMigrationsAsync()).Any())
                {
                    await _storeDbContext.Database.MigrateAsync();
                }
                if (!_storeDbContext.ProductBrands.Any())
                {
                    //var productBrandsData =await File.ReadAllTextAsync(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\brands.json");
                    var productBrandsData = File.OpenRead(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\brands.json");
                    var brands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(productBrandsData);
                    if (brands is not null && brands.Any())
                    {
                        await _storeDbContext.ProductBrands.AddRangeAsync(brands);

                    }
                }

                if (!_storeDbContext.ProductTypes.Any())
                {
                    var productTypesData = File.OpenRead(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\types.json");
                    var types = await JsonSerializer.DeserializeAsync<List<ProductType>>(productTypesData);
                    if (types is not null && types.Any())
                    {
                       await _storeDbContext.ProductTypes.AddRangeAsync(types);

                    }
                }

                if (!_storeDbContext.Products.Any())
                {
                    var productsData = File.OpenRead(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\products.json");
                    var products = await JsonSerializer.DeserializeAsync<List<Product>>(productsData);
                    if (products is not null && products.Any())
                    {
                       await _storeDbContext.Products.AddRangeAsync(products);

                    }
                }

                await _storeDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {

                //todo
            }
        }       
    }
}
