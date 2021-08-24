using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostAggregatedService.Data.UserMocks
{
    public interface IUserMockRepository
    {
        public bool AuthorizeUser(string headerKey);
    }
}
