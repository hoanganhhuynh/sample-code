using System;
using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Domain.MappingProfile
{
	public class PeopleProfile : Profile
    {
		public PeopleProfile()
		{
            CreateMap<PeopleEntity, CreatePeopleDto>().ReverseMap();
            CreateMap<PeopleEntity, GetPeopleDto>().ReverseMap();
        }
	}
}

