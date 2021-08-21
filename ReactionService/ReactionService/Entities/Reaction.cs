using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Entities
{
    /// <summary>
    /// Predstavlja model reakcije.
    /// </summary>
    public class Reaction
    {
        /// <summary>
        /// Predstavlja ID reakcije.
        /// </summary>
        public Guid ReactionId { get; set; }

        /// <summary>
        /// Predstavlja prijavu ispita
        /// </summary>
        public Guid ReactionTypeId { get; set; }

        /// <summary>
        /// Predstavlja dan kreiranja reakcije.
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Predstavlja mesec kreiranja reakcije.
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Predstavlja godinu kreiranja reakcije.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Predstavlja ID korisnika.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
