using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostAggregatedService.Models
{
    /// <summary>
    /// Predstavlja model za kreiranje agregiranih podataka oglasa.
    /// </summary>
    public class PostAggregatedCreateDto
    {
        /// <summary>
        /// Predstavlja ID oglasa na koji se odnose agregirani podaci.
        /// </summary>
        public Guid PostId { get; set; }
    }
}
