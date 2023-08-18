using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.Repository
{
    /// <summary>
    /// The todo repository definition
    /// </summary>
    public interface ITodoRepository
    {
        /// <summary>
        /// Creates todo entry in db
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public Task<TodoEntry> CreateAsync( TodoEntry entry );

        /// <summary>
        /// Reads entries in db
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TodoEntry>> ReadAllAsync();
    }
}
