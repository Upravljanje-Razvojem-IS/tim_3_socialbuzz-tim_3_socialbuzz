using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Data
{
    public interface IUserMockRepository
    {
        public bool AuthorizeUser(string headerKey);
    }
}
