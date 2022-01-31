using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Entities
{
    public class PostPicture : Picture
    {
        public string PictureType { get; set; }
        

        
        public Guid PostId { get; set; }
        public Post Post { get; set; }

        
       
    }
}
