using AutoMapper;
using Shipping.API.DTO;
using Shipping.Domain;

namespace Shipping.API.Profiles
{
    public class ShippingProfile : Profile
    {
        public ShippingProfile()
        {
            CreateMap<Pengiriman, ShippingDTO>();
            CreateMap<ShippingCreateDTO, Pengiriman>();
        }
       
    }
}
