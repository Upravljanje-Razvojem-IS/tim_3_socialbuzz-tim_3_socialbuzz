using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Entities
{
    public class Picture
    {
       
        public Guid Id { get; set; }

        public string Url { get; set; }

    }
}
