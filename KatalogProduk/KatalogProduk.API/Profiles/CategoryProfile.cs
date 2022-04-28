using AutoMapper;
using KatalogProduk.API.DTO;
using KatalogProduk.Domain;

namespace KatalogProduk.API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CreateCategoryDTO, Category>();
        }
    }
}
