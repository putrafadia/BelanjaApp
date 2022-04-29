using AutoMapper;
using Transaksi.Domain;
using TransaksiBelanja.Dtos;

namespace TransaksiBelanja.Profiles
{
    public class TransaksiBelanjaProfile : Profile
    {
        public TransaksiBelanjaProfile()
        {
            CreateMap<TransaksiBelanjas, ViewTransaksiDTO>();
            CreateMap<CreateTransaksiDTO, TransaksiBelanjas>();
        }
    }
}
