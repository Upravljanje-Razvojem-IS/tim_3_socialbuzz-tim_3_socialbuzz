﻿using AutoMapper;
using ReactionService.Entities;
using ReactionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Profiles
{
    public class ReactionTypeProfile : Profile
    {
        public ReactionTypeProfile()
        {
            CreateMap<ReactionType, ReactionTypeDto>();
            CreateMap<ReactionType, ReactionTypeCreateDto>();
            CreateMap<ReactionTypeCreateDto, ReactionType>();
            CreateMap<ReactionTypeUpdateDto, ReactionType>();
            CreateMap<ReactionTypeDto, ReactionTypeUpdateDto>();
        }
    }
}
