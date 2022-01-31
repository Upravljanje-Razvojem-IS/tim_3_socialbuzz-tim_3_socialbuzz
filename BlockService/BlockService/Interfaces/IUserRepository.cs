using BlockService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockService.Interfaces
{
  public interface IUserRepository
    {
        List<UserReadDto> Get();
        UserReadDto Get(Guid id);
        UserConfirmationDto Create(UserCreateDto dto);
        UserConfirmationDto Update(Guid id, UserCreateDto dto);
        void Delete(Guid id);
    }
}
