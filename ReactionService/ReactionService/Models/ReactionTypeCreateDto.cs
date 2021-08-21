using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Models
{
    /// <summary>
    /// Predstavlja model kreiranja tipa reakcije.
    /// </summary>
    public class ReactionTypeCreateDto
    {
        /// <summary>
        /// Predstavlja naziv tipa reakcije.
        /// </summary>
        public string ReactionTypeName { get; set; }

        /// <summary>
        /// Predstavlja url do slike tipa reakcije.
        /// </summary>
        public string ReactionTypeImage { get; set; }
    }
}
