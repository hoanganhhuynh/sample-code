using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services
{
	public interface ICountryService
	{
		Task<List<CountryDto>> GetAll();
	}
}

