using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Models;
using Domain.Services;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
	public class PeopleService : IPeopleService
	{
        private readonly IPeopleRepository _peopleRepository;
        private readonly IMapper _mapper;
        public PeopleService(
            IPeopleRepository peopleRepository,
            IMapper mapper
            )
        {
            _peopleRepository = peopleRepository;
            _mapper = mapper;
        }

        public async Task<CreatePeopleDto> Create(CreatePeopleDto peopleDto)
        {
            var entity = _mapper.Map<PeopleEntity>(peopleDto);
            await _peopleRepository.Create(entity);

            return _mapper.Map<CreatePeopleDto>(entity);
        }

        public async Task Delete(Guid id)
        {
            var people = await Get(id);
            if (people == null)
            {
                throw new KeyNotFoundException($"People with id {id} is not found");
            }
            var entity = _mapper.Map<PeopleEntity>(people);
            await _peopleRepository.Delete(entity);
        }

        public async Task<GetPeopleDto> Get(Guid id)
        {
            var entity = await _peopleRepository.Get(id);
            return _mapper.Map<GetPeopleDto>(entity);
        }

        public async Task<List<GetPeopleDto>> GetAll()
        {
            var entities = await _peopleRepository.GetAll();
            return _mapper.Map<List<GetPeopleDto>>(entities);
        }
    }
}

