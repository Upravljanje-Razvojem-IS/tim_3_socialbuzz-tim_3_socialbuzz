using AutoMapper;
using BlockService.DTOs;
using BlockService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockService.Mapper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>().ReverseMap();
            CreateMap<User, UserConfirmationDto>().ReverseMap();
        }
    }
}
