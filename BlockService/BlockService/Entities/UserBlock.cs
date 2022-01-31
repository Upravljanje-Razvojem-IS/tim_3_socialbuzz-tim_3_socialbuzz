using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlockService.Entities
{
    public class UserBlock
    {
        /// <summary>
        /// Id
        /// </summary>
      
        public Guid Id { get; set; }

        /// <summary>
        /// Blocking User id
        /// </summary>
        public Guid BlockerId { get; set; }

        /// <summary>
        /// Blocking User id
        /// </summary>
        public User User { get; set; }


      public Guid BlockedId { get; set; }
      public User BlockedUser { get; set; }


    }
}
