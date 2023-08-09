using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models;

namespace Domain.Services
{
	public interface ITodoService
	{
		Task<TodoEntity> Get(Guid id);
		Task Update(GetTodoDto todo);
		Task Delete(Guid id);
		Task Create(CreateTodoDto todo);
	}
}

