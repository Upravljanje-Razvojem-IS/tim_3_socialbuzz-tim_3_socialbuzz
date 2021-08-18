using PriceService.DTOs;
using System;
using System.Collections.Generic;

namespace PriceService.Intefaces
{
    public interface IPriceHistoryRepository
    {
        List<PriceHistoryReadDto> Get();
        PriceHistoryReadDto Get(Guid id);
        PriceHistoryConfirmationDto Create(PriceHistoryCreateDto dto);
        PriceHistoryConfirmationDto Update(Guid id, PriceHistoryCreateDto dto);
        void Delete(Guid id);
    }
}
