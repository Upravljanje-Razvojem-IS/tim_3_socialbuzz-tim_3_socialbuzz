using System;

namespace WatchingService.DTOs
{
    public class UserWatchCreateDto
    {
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
