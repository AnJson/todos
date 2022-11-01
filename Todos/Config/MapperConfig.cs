using AutoMapper;
using Todos.Model;
using Todos.Model.DTO.Todo;

namespace Todos.Config
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Todo, TodoResponse>().ReverseMap();
            CreateMap<Todo, TodoCreate>().ReverseMap();
        }
    }
}
