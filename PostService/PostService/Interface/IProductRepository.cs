using PostService.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;

namespace PostService.Interface
{
    public interface IProductRepository
    {
        List<ProductReadDTO> Get();
        ProductReadDTO Get(Guid id);
        ProductConfirmationDTO Create(ProductCreateDTO dto);
        ProductConfirmationDTO Update(Guid id, ProductCreateDTO dto);
        void Delete(Guid id);
    }
}
