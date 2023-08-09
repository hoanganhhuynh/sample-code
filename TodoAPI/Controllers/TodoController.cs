using System;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("todo")]
    public class TodoController : ControllerBase
    {
        
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoService _todoService;

        public TodoController(
            ILogger<TodoController> logger,
            ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _todoService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTodoDto createTodo)
        {
            await _todoService.Create(createTodo);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(GetTodoDto updateTodo)
        {
            await _todoService.Update(updateTodo);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _todoService.Delete(id);
            return NoContent();
        }
    }
}

