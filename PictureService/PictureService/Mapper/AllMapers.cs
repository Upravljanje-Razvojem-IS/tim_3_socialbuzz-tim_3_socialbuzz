using AutoMapper;
using PictureService.DTOs.OwnerDTOs;
using PictureService.DTOs.PictureDTOs;
using PictureService.DTOs.PostDTOs;
using PictureService.DTOs.PostPictureDTOs;
using PictureService.DTOs.ProfilePictureDTOs;
using PictureService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Mapper
{
    public class AllMapers:Profile
    {
        public AllMapers()
        {
            CreateMap<Owner, OwnerReadDto>();
            CreateMap<Owner, OwnerConfirmationDto>();
            CreateMap<Picture, PictureReadDto>().ReverseMap();
            CreateMap<Picture, PictureConfirmationDto>().ReverseMap();

            CreateMap<Post, PostReadDto>().ReverseMap();
            CreateMap<Post, PostConfirmationDto>().ReverseMap();

            CreateMap<PostPicture, PostPictureReadDto>().ReverseMap();
            CreateMap<PostPicture, PostConfirmationDto>().ReverseMap();
            CreateMap<PostPicture, PostPictureConfirmationDto>().ReverseMap();
            CreateMap<ProfilePicture, ProfilePictureReadDto>().ReverseMap();
            CreateMap<ProfilePicture, ProfilePictureConfirmationDto>().ReverseMap();
        }
    }
}
