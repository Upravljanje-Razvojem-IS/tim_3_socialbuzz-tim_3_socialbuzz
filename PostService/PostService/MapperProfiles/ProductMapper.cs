using AutoMapper;
using PostService.DTOs.ProductDTOs;
using PostService.Entities;

namespace PostService.MapperProfiles
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductReadDTO>();
            CreateMap<Product, ProductConfirmationDTO>();
        }
    }
}
