using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WatchingService.Entities
{
    public class User
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
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
        /// Watching list
        /// </summary>
        List<UserWatch> Watching { get; set; }
        /// <summary>
        /// Watched list
        /// </summary>
        List<UserWatch> Watched { get; set; }
    }
}
