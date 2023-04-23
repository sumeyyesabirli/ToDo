using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Services.Commands.Category.Insert;
using Todo.Application.Services.Commands.TodoItem.Delete;
using Todo.Application.Services.Commands.TodoItem.Insert;
using Todo.Application.Services.Commands.TodoItem.Update;
using Todo.Application.Services.Commands.User.Insert;
using Todo.Application.Services.Queries.Category.GetAll;
using Todo.Application.Services.Queries.TodoItem.GetAll;
using Todo.Core.Entities;

namespace Todo.Application.MappingConfiguration
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<RegisterUserCommandRequest, User>().ReverseMap();


            CreateMap<InsertTodoItemCommandRequest, TodoItem>().ReverseMap();
            CreateMap<UpdateTodoItemCommandRequest, TodoItem>().ReverseMap();
            CreateMap<DeleteTodoItemCommandRequest, TodoItem>().ReverseMap();
            CreateMap<GetAllTodoItemQueriesResponse, TodoItem>().ReverseMap();


            CreateMap<InsertCategoryCommandRequest, Category>().ReverseMap();
            CreateMap<InsertCategoryCommandRequest, Category>().ReverseMap();
            CreateMap<GetAllCategoryQueriesResponse, Category>().ReverseMap();
        
        }
    }
}
