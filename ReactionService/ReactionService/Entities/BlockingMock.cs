﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Entities
{
    /// <summary>
    /// Predstavlja lažni model blokiranog korisnika.
    /// </summary>
    public class BlockingMock
    {
        /// <summary>
        /// Predstavlja ID bloka.
        /// </summary>
        public Guid BlockingMockId { get; set; }

        /// <summary>
        /// Predstavlja ID korisnika koji blokira.
        /// </summary>
        public Guid UserThatBlocks { get; set; }

        /// <summary>
        /// Predstavlja ID korisnika koji je blokiran.
        /// </summary>
        public Guid BlockedUser { get; set; }


    }
}
