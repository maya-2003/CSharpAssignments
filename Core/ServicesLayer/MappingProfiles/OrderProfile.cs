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
                    .ForMember(dest => dest.BuyerEmail, opt => opt.MapFrom(src => src.UserEmail))
                    .ForMember(dest => dest.ShipToAddress, opt => opt.MapFrom(src => src.Address))
                     .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.OrderStatus.ToString()));
            

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<OrderItemPictureUrlResolver>());

            CreateMap<DeliveryMethod, DeliveryMethodDto>()
            .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Price));
        }
    }
}
