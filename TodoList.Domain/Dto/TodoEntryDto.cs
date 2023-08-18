using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Dto
{
    /// <summary>
    /// The entry dto of the todo list
    /// </summary>
    public class TodoEntryDto
    {
        /// <summary>
        /// The Id of todo entry
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The description of todo entry
        /// </summary>
        public string Description { get; set; }
    }
}
