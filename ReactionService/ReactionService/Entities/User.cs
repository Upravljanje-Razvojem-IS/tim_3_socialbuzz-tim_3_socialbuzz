using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Entities
{
    /// <summary>
    /// Predstavlja model korisnika koji ce se koristiti za autorizaciju
    /// </summary>
    public class User
    {
        /// <summary>
        /// Predstavlja podatke aplikacije
        /// </summary>
        public const string SectionName = "User";

        /// <summary>
        /// Predstavlja ključ korisnika za autorizaciju
        /// </summary>
        public string UserKey { get; set; }
    }
}
