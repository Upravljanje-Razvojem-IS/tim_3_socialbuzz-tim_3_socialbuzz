using System;
using System.ComponentModel.DataAnnotations;

namespace WatchingService.Entities
{
    public class UserWatch
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Watching User id
        /// </summary>
        public Guid WatchingId { get; set; }
        /// <summary>
        /// Watching user
        /// </summary>
        public User Watching { get; set; }
        /// <summary>
        /// Watched user id
        /// </summary>
        public Guid WatchedId { get; set; }
        /// <summary>
        /// Watched user
        /// </summary>
        public User Watched { get; set; }

    }
}
