using AutoMapper;
using ReactionService.Entities;
using ReactionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Profiles
{
    public class ReactionProfile : Profile
    {
        public ReactionProfile()
        {
            CreateMap<Reaction, ReactionDto>()
                .ForMember(
                    dest => dest.ReactionDate,
                    opt => opt.MapFrom(src => $"{ src.Day }/{ src.Month }/{ src.Year }"));
            CreateMap<Reaction, ReactionCreateDto>();
            CreateMap<ReactionCreateDto, Reaction>();
            CreateMap<ReactionUpdateDto, Reaction>();
            CreateMap<ReactionDto, ReactionUpdateDto>();
        }
    }
}
