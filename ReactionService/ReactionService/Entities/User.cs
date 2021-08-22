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
        public const string SectionName = "User";

        public string UserKey { get; set; }
    }
}
