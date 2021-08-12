using PriceService.DTOs;
using System;
using System.Collections.Generic;

namespace PriceService.Intefaces
{
    public interface IPriceHistoryRepository
    {
        List<PriceHistoryReadDTO> Get();
        PriceHistoryReadDTO Get(Guid id);
        PriceHistoryConfirmationDTO Create(PriceHistoryCreateDTO dto);
        PriceHistoryConfirmationDTO Update(Guid id, PriceHistoryCreateDTO dto);
        void Delete(Guid id);
    }
}
