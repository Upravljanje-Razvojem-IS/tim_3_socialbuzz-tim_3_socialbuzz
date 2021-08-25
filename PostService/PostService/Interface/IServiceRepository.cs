using PostService.DTOs.ServiceDTOs;
using System;
using System.Collections.Generic;

namespace PostService.Interface
{
    public interface IServiceRepository
    {
        List<ServiceReadDto> Get();
        ServiceReadDto Get(Guid id);
        ServiceConfirmationDto Create(ServiceCreateDto dto);
        ServiceConfirmationDto Update(Guid id, ServiceCreateDto dto);
        void Delete(Guid id);
    }
}
