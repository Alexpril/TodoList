using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Dto;
using TodoList.Domain.Entities;

namespace TodoList.Application.Commands
{
    /// <summary>
    /// Cretae todo entry command
    /// </summary>
    public class CreateEntryCommand : IRequest<TodoEntry>
    {
        /// <summary>
        /// The description of todo entry
        /// </summary>
        public string Description { get; set; }
    }
}
