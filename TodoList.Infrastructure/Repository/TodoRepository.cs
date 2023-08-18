using TodoList.Domain.Entities;
using TodoList.Infrastructure.EF;

namespace TodoList.Infrastructure.Repository
{
    /// <summary>
    /// The todo entry repository
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        /// <summary>
        /// EF todo context
        /// </summary>
        private TodoContext todoContext = new();

        /// <summary>
        /// Creates entity in db
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public Task<TodoEntry> CreateAsync(TodoEntry entry)
        {
            var createdEntry = todoContext.TodoEntries.Add(entry);
            todoContext.SaveChangesAsync();
            return Task.FromResult(createdEntry);
        }

        /// <summary>
        /// Reads entities
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TodoEntry>> ReadAllAsync()
        {
            var entries = todoContext.TodoEntries.Local.ToList();
            return Task.FromResult((IEnumerable<TodoEntry>)entries);
        }
    }
}