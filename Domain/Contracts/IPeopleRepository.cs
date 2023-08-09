using System;
using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Contracts
{
	public interface IPeopleRepository
	{
        Task<List<PeopleEntity>> GetAll();
        Task<PeopleEntity> Create(PeopleEntity entity);
        Task<PeopleEntity> Get(Guid id);
        Task Delete(PeopleEntity entity);
    }
}

