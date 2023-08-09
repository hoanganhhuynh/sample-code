using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Models;
using Domain.Services;

namespace Infrastructure.Services
{
	public class TodoService : ITodoService
	{
		private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;
		public TodoService(
            ITodoRepository todoRepository,
            IMapper mapper
            )
		{
			_todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateTodoDto createTodo)
        {
            var entity = _mapper.Map<TodoEntity>(createTodo);
            await _todoRepository.Create(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await Get(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Todo with id {id} is not found");
            }
            await _todoRepository.Delete(entity);
        }

        public async Task<TodoEntity> Get(Guid id)
        {
            return await _todoRepository.Get(id);
        }

        public async Task Update(GetTodoDto createTodo)
        {
            var isExist = await _todoRepository.IsExist(createTodo.Id);
            if (!isExist)
            {
                throw new KeyNotFoundException($"Todo with id {createTodo.Id} is not found");
            }
            var entity = _mapper.Map<TodoEntity>(createTodo);
            await _todoRepository.Update(entity);
        }
    }
}

