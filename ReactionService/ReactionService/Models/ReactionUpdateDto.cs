using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Models
{
    /// <summary>
    /// Predstavlja model za ažuriranje reakcije.
    /// </summary>
    public class ReactionUpdateDto
    {
        /// <summary>
        /// Predstavlja ID reakcije.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID reakcije.")]
        public Guid ReactionId { get; set; }

        /// <summary>
        /// Predstavlja ID tipa reakcije.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti tip reakcije.")]
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            DateTime date = DateTime.Today;
            if (Year < 1900 || Year > date.Year)
            {
                yield return new ValidationResult(
                    "Pogrešan unos godine.",
                    new[] { "ReactionCreateDto" });
            }
            if (Month < 1 || Month > 12)
            {
                yield return new ValidationResult(
                    "Pogrešan unos meseca.",
                    new[] { "ReactionCreateDto" });
            }
            if (Day < 1 || Day > 30)
            {
                yield return new ValidationResult(
                    "Pogrešan unos dana.",
                    new[] { "ReactionCreateDto" });
            }
        }
    }
}
