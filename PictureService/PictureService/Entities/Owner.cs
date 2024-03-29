﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Entities
{
    public class Owner
    {
     
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public virtual ProfilePicture ProfilePicture { get; set; }

    }
}
