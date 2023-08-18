using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Commands;
using TodoList.Domain.Dto;
using TodoList.Domain.Entities;

namespace TodoList.API.Controllers
{
    /// <summary>
    /// Handles routed trafic to TodoList domain
    /// </summary>
    public partial class TodoListController : ControllerBase
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mediator"></param>
        public TodoListController (IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates an entry
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TodoEntry>> CreateEntry( [FromBody] CreateEntryCommand command )
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
