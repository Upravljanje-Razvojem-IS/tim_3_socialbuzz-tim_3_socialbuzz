using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Entities
{
    public class Post
    {
       
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<PostPicture> postPictures { get; set; }

    }
}