namespace TodoList.Domain.Entities
{
    /// <summary>
    /// The entry of todo list
    /// </summary>
    public class TodoEntry
    {
        /// <summary>
        /// The Id of todo entry
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// The description of todo entry
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Constructs a new entry with properties
        /// </summary>
        /// <param name="description"></param>
        public TodoEntry( string description ) 
        {
            Id = Guid.NewGuid();
            Description = description;
        }
    }
}