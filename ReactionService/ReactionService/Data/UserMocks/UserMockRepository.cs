using Microsoft.Extensions.Options;
using ReactionService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Data
{
    /// <summary>
    /// Lažni (mock) repozitorijum u ulozi korisnika
    /// </summary>
    public class UserMockRepository : IUserMockRepository
    {
        List<User> Users = new List<User>();
        private readonly IOptions<User> options;

        public UserMockRepository(IOptions<User> options)
        {
            this.options = options;
        }


        public bool AuthorizeUser(string headerKey)
        {
            if ( headerKey == null || headerKey.Length == 0)
            {
                return false;
            }

            if ( headerKey == options.Value.UserKey)
            {
                return true;
            }
            return false;
        }
    }
}
