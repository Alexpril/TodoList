using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Queries;
using TodoList.Domain.Dto;
using TodoList.Domain.Entities;

namespace TodoList.API.Controllers
{
    /// <summary>
    /// Handles routed trafic to TodoList domain
    /// </summary>
    [Route("api/todo")]
    [ApiController]
    public partial class TodoListController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoEntry>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllEntriesQuery());

            return Ok(result);
        }
    }
}
