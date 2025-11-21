using AutoMapper;
using DomainLayer.Models.BasketModels;
using Shared.DTOs.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.MappingProfiles
{
    internal class BasketMappingProfile : Profile
    {

        public BasketMappingProfile()
        {
            CreateMap<CustomerBasket, BasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
        }
    }
}
