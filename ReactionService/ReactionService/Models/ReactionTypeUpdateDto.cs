using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Models
{
    /// <summary>
    /// Predstavlja model ažuriranja tipa reakcije.
    /// </summary>
    public class ReactionTypeUpdateDto
    {
        /// <summary>
        /// Predstavlja ID tipa reakcije.
        /// </summary>
        public Guid ReactionTypeID { get; set; }

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
