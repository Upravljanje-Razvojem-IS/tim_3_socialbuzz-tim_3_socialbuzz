using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostAggregatedService.Models
{
    /// <summary>
    /// Predstavlja model za ažuriranje agregiranih podataka oglasa.
    /// </summary>
    public class PostAggregatedUpdateDto : IValidatableObject
    {
        /// <summary>
        /// Predstavlja ID agregiranih podataka.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID agregiranih podataka.")]
        public Guid PostAggregatedId { get; set; }

        /// <summary>
        /// Predstavlja ID oglasa na koji se odnose agregirani podaci.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID oglasa za koji su vezani agregirani podaci.")]
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (NumberOfVisits < 0 || NumberOfComments < 0 || NumberOfLikes < 0 || NumberOfDislikes < 0 || NumberOfSmileys < 0
                || NumberOfHearts < 0)
            {
                yield return new ValidationResult(
                    "Pogrešan unos broja agregiranih podataka. Broj mora biti veći od nule.",
                    new[] { "PostAggregatedUpdateDto" });
            }
        }
    }
}
