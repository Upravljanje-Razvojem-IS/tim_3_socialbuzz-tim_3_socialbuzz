﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Models
{
    /// <summary>
    /// Predstavlja tip reakcija.
    /// </summary>
    public class ReactionTypeDto
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
