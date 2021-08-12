using AutoMapper;
using PostService.DTOs.ProductDTOs;
using PostService.Entities;

namespace PostService.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDTO>();
            CreateMap<Product, ProductConfirmationDTO>();
        }
    }
}
