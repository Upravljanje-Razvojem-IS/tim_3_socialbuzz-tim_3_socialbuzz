using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlockService.Entities
{
    public class User
    {
        /// Id
        /// </summary>
     
        public Guid Id { get; set; }
        /// <summary>
        /// UserName
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Blocked list
        /// </summary>
        public List<UserBlock> BlockedUsers { get; set; }

        /// <summary>
        /// User that blocks  list
        /// </summary>
        public List<UserBlock> BlockerUsers { get; set; }
    }

       

    }

