using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class PeopleRepository : IPeopleRepository
    {
        private readonly TodoDbContext _dbContext;
        public PeopleRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PeopleEntity> Create(PeopleEntity entity)
        {
            _dbContext.People.Add(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(true);
            return entity;
        }

        public async Task Delete(PeopleEntity entity)
        {
            _dbContext.People.Remove(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(true);
        }

        public async Task<PeopleEntity> Get(Guid id)
        {
            return await _dbContext.People.SingleOrDefaultAsync(people => people.Id == id);
        }

        public async Task<List<PeopleEntity>> GetAll()
        {
            return await _dbContext.People.ToListAsync();
        }
    }
}

