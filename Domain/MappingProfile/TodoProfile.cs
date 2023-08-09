using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Domain.MappingProfile;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<TodoEntity, CreateTodoDto>().ReverseMap();
        CreateMap<TodoEntity, GetTodoDto>().ReverseMap();
    }
}