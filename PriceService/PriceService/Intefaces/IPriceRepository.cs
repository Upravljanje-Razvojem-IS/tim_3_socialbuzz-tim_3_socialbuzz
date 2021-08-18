using PriceService.DTOs;
using System;
using System.Collections.Generic;

namespace PriceService.Intefaces
{
    public interface IPriceRepository
    {
        List<PriceReadDto> Get();
        PriceReadDto Get(Guid id);
        PriceConfirmationDto Create(PriceCreateDto dto);
        PriceConfirmationDto Update(Guid id, PriceCreateDto dto);
        void Delete(Guid id);
    }
}
