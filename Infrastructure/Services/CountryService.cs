using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using Domain.Services;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
	public class CountryService :ICountryService
	{
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(
            ICountryRepository countryRepository,
            IMapper mapper
            )
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<List<CountryDto>> GetAll()
        {
            var entities = await _countryRepository.GetAll();
            return _mapper.Map<List<CountryDto>>(entities);
        }
    }
}

