using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models;

namespace Domain.Services
{
	public interface ITodoService
	{
		Task<TodoEntity> Fetch(Guid id);
		Task Update(UpdateTodoDto todo);
		Task Delete(Guid id);
		Task Create(CreateTodoDto todo);
	}
}

