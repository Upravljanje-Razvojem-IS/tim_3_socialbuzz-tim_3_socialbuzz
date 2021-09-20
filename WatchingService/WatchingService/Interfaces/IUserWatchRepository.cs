using System;
using System.Collections.Generic;
using WatchingService.DTOs;

namespace WatchingService.Interfaces
{
    public interface IUserWatchRepository
    {
        List<UserWatchReadDto> Get();
        UserWatchReadDto Get(Guid id);
        UserWatchConfirmationDto Create(UserWatchCreateDto dto);
        UserWatchConfirmationDto Update(Guid id, UserWatchCreateDto dto);
        void Delete(Guid id);
    }
}
