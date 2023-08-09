using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Contracts
{
	public interface ICountryRepository
	{
		Task<List<CountryEntity>> GetAll();
	}
}

