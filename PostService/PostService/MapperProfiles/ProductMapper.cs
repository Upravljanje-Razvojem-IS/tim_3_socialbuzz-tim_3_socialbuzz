using AutoMapper;
using PostService.DTOs.ProductDTOs;
using PostService.Entities;

namespace PostService.MapperProfiles
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<Product, ProductConfirmationDto>();
        }
    }
}
