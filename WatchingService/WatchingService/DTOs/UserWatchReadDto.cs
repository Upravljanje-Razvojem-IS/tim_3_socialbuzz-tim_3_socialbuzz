using System;

namespace WatchingService.DTOs
{
    public class UserWatchReadDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Watching User id
        /// </summary>
        public Guid WatchingId { get; set; }
        /// <summary>
        /// Watched user id
        /// </summary>
        public Guid WatchedId { get; set; }
    }
}
