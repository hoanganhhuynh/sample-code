using System;
using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Domain.MappingProfile
{
	public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryEntity, CountryDto>().ReverseMap();
        }
    }
}

