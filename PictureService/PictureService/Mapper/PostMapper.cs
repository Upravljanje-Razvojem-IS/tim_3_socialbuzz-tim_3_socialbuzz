using AutoMapper;
using PictureService.DTOs.PostDTOs;
using PictureService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Mapper
{
    public class PostMapper : Profile
    {
        public PostMapper()
        {
            CreateMap<Post, PostReadDto>().ReverseMap();
            CreateMap<Post, PostConfirmationDto>().ReverseMap();

        }
    }
}
