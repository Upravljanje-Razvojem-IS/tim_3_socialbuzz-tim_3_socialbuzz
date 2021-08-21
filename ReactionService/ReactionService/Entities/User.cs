using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Entities
{
    /// <summary>
    /// Predstavlja model korisnika
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id korisnika
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Ime korisnika
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Prezime korisnika
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Korisničko ime
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email korisnika
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Hash-ovana šifra korisnika
        /// </summary>
        public string Password { get; set; }
    }
}
