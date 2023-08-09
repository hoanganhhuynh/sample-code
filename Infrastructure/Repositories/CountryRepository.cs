using System;
using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
	public class CountryRepository : ICountryRepository
    {
        private readonly TodoDbContext _dbContext;
        public CountryRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<CountryEntity>> GetAll()
        {
            return await _dbContext.Countries.ToListAsync();
        }
    }
}

