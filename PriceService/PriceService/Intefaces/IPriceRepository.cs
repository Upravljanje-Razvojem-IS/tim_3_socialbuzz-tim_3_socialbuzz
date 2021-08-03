using PriceService.DTOs;
using System;
using System.Collections.Generic;

namespace PriceService.Intefaces
{
    public interface IPriceRepository
    {
        List<PriceReadDTO> Get();
        PriceReadDTO Get(Guid id);
        PriceConfirmationDTO Create(PriceCreateDTO dto);
        PriceConfirmationDTO Update(Guid id, PriceCreateDTO dto);
        void Delete(Guid id);
    }
}
