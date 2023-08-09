using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("people")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly IPeopleService _peopleService;

        public PeopleController(
            ILogger<TodoController> logger,
            IPeopleService peopleService)
        {
            _logger = logger;
            _peopleService = peopleService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _peopleService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePeopleDto createPeople)
        {
            var result = await _peopleService.Create(createPeople);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _peopleService.Delete(id);
            return Ok();
        }
    }
}

