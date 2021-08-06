using PostService.DTOs.ServiceDTOs;
using System;
using System.Collections.Generic;

namespace PostService.Interface
{
    public interface IServiceRepository
    {
        List<ServiceReadDTO> Get();
        ServiceReadDTO Get(Guid id);
        ServiceConfirmationDTO Create(ServiceCreateDTO dto);
        ServiceConfirmationDTO Update(Guid id, ServiceCreateDTO dto);
        void Delete(Guid id);
    }
}
