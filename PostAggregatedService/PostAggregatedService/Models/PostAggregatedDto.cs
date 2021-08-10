using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostAggregatedService.Models
{
    /// <summary>
    /// Predstavlja agregirane podatke oglasa.
    /// </summary>
    public class PostAggregatedDto
    {
        /// <summary>
        /// Predstavlja ID agregiranih podataka.
        /// </summary>
        public Guid PostAggregatedId { get; set; }

        /// <summary>
        /// Predstavlja ID oglasa na koji se odnose agregirani podaci.
        /// </summary>
        public Guid PostId { get; set; }

        /// <summary>
        /// Predstavlja broj poseta oglasa.
        /// </summary>
        public int NumberOfVisits { get; set; }

        /// <summary>
        /// Predstavlja broj komentara oglasa.
        /// </summary>
        public int NumberOfComments { get; set; }

        /// <summary>
        /// Predstavlja broj like-ova oglasa.
        /// </summary>
        public int NumberOfLikes { get; set; }

        /// <summary>
        /// Predstavlja broj dislike-ova oglasa.
        /// </summary>
        public int NumberOfDislikes { get; set; }

        /// <summary>
        /// Predstavlja broj smiley-a oglasa.
        /// </summary>
        public int NumberOfSmileys { get; set; }

        /// <summary>
        /// Predstavlja broj srca oglasa.
        /// </summary>
        public int NumberOfHearts { get; set; }
    }
}
