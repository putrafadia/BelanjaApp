using AutoMapper;
using KatalogProduk.API.DTO;
using KatalogProduk.Domain;

namespace KatalogProduk.API.Profiles
{
    public class ProdukProfile : Profile
    {
        public ProdukProfile()
        {
            CreateMap<ProdukCreateDTO, Produk>();
            CreateMap<Produk, ProdukDTO>();
        }
    }
}
