﻿using System;

namespace CommentService.DTOs.OwnerDTOs
{
    public class OwnerConfirmationDto
    {
        /// <summary>
        /// owner id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }
    }
}
