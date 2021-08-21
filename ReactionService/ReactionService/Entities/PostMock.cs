using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Entities
{
    /// <summary>
    /// Predstavlja lažni model oglasa.
    /// </summary>
    public class PostMock
    {
        /// <summary>
        /// Predstavlja ID oglasa.
        /// </summary>
        public Guid PostId { get; set; }

        /// <summary>
        /// Predstavlja ID oglasa.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Predstavlja datum objavljivanja oglasa
        /// </summary>
        public String Date { get; set; }

        /// <summary>
        /// Predstavlja naziv oglasa
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// Predstavlja opis oglasa
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Predstavlja državu iz koje je proizvod sa oglasa
        /// </summary>
        public String Country { get; set; }

        /// <summary>
        /// Predstavlja grad iz koje je proizvod sa oglasa
        /// </summary>
        public String City { get; set; }

        /// <summary>
        /// Predstavlja adresu iz koje je proizvod sa oglasa
        /// </summary>
        public String Address { get; set; }
    }
}
