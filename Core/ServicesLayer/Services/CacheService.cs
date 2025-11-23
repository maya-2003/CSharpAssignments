using DomainLayer.Contracts;
using ServiceAbstractionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
    public class CacheService(ICacheRepository _cacheRepository) : ICacheService
    {
        public async Task<string?> GetAsync(string cacheKey)
        {
           return await _cacheRepository.GetAsync(cacheKey);
        }

        public async Task SetAsync(string cacheKey, object value, TimeSpan timeToLive)
        {
            var valueToCache= JsonSerializer.Serialize(value);
            await _cacheRepository.SetAsync(cacheKey, valueToCache, timeToLive);
        }
    }
}
