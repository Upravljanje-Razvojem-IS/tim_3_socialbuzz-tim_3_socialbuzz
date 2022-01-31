using BlockService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockService.Interfaces
{
   public interface IAuthService
    {
        string Login(Principal principal);
        string GenerateJwt(string role);
    }
}
