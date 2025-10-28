using AutoMapper;
using AutoMapper.Execution;
using DomainLayer.Models;
using Microsoft.Extensions.Configuration;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServicesLayer.MappingProfiles
{
    internal class PictureUrlResolver (IConfiguration _configuration): IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if(string.IsNullOrWhiteSpace(source.PictureUrl)) //Empty
                return string.Empty;
            else
            {
                var url =  $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.PictureUrl}";
                return url;
            }
        }
    }
}
