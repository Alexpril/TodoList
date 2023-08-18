using AutoMapper;w
using TodoList.Domain.Dto;
using TodoList.Domain.Entities;

namespace TodoList.Domain
{
    /// <summary>
    /// The auto mapper profile
    /// </summary>
    public class AutomapperProfile : Profile
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public AutomapperProfile() {
            CreateMap<TodoEntry, TodoEntryDto>();
            CreateMap<IEnumerable<TodoEntry>, IEnumerable<TodoEntryDto>>();
        }
    }
}
