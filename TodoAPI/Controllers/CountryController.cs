using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("country")]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryService _countryService;

        public CountryController(
            ILogger<CountryController> logger,
            ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _countryService.GetAll();
            return Ok(result);
        }
    }
}

