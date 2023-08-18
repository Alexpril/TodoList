using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Dto;
using TodoList.Domain.Entities;

namespace TodoList.Application.Queries
{
    public class GetAllEntriesQuery : IRequest<IEnumerable<TodoEntry>>
    {
    }
}
