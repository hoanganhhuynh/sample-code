using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services
{
	public interface IPeopleService
	{
		Task<List<GetPeopleDto>> GetAll();
        Task<GetPeopleDto> Get(Guid id);
        Task<CreatePeopleDto> Create(CreatePeopleDto peopleDto);
        Task Delete(Guid id);
    }

}

