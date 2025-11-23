using AutoMapper;
using DomainLayer.Models.OrderModels;
using Shared.DTOs.IdentityDtos;
using Shared.DTOs.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ServicesLayer.MappingProfiles
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<AddressDto, OrderAddress> ();

            CreateMap<Order, OrderToReturnDto>()
                    .ForMember(dest => dest.DeliveryMethod,
                    opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
                     .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus.ToString()));
            

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<OrderItemPictureUrlResolver>());

            CreateMap<DeliveryMethod, DeliveryMethodDto>();
        }
    }
}
