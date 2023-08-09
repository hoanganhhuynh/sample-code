using System;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Contracts
{
	public interface ITodoRepository
	{
		Task<TodoEntity> Get(Guid id);
		Task Create(TodoEntity entity);
		Task Update(TodoEntity entity);
		Task Delete (TodoEntity entity);
		Task<bool> IsExist(Guid id);
	}
}

