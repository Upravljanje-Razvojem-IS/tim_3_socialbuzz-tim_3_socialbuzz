using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Models
{
    /// <summary>
    /// Predstavlja reakciju (npr. Like)
    /// </summary>
    public class ReactionDto
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
        /// Predstavlja datum kreiranja reakcije.
        /// </summary>
        public string ReactionDate { get; set; }
    }
}
