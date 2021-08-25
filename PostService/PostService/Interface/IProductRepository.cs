using PostService.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;

namespace PostService.Interface
{
    public interface IProductRepository
    {
        List<ProductReadDto> Get();
        ProductReadDto Get(Guid id);
        ProductConfirmationDto Create(ProductCreateDto dto);
        ProductConfirmationDto Update(Guid id, ProductCreateDto dto);
        void Delete(Guid id);
    }
}
