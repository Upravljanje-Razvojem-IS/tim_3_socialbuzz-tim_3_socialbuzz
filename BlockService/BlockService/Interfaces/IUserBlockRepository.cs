using BlockService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockService.Interfaces
{
   public interface IUserBlockRepository
    {
        List<UserBlockReadDto> Get();
        UserBlockReadDto Get(Guid id);
        UserBlockConfirmationDto Create(UserBlockCreateDto dto);
        UserBlockConfirmationDto Update(Guid id, UserBlockCreateDto dto);
        void Delete(Guid id);
    }
}
