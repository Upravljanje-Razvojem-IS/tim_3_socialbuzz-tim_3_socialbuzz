using Microsoft.Extensions.Options;
using PostAggregatedService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostAggregatedService.Data.UserMocks
{
    /// <summary>
    /// Lažni (mock) repozitorijum u ulozi korisnika
    /// </summary>
    public class UserMockRepository : IUserMockRepository
    {
        private readonly IOptions<UserMock> options;

        public UserMockRepository(IOptions<UserMock> options)
        {
            this.options = options;
        }


        public bool AuthorizeUser(string headerKey)
        {
            if (headerKey == null || headerKey.Length == 0)
            {
                return false;
            }

            if (headerKey == options.Value.UserKey)
            {
                return true;
            }
            return false;
        }
    }
}
