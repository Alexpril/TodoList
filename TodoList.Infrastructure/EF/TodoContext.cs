using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.EF
{
    /// <summary>
    /// EF todo context
    /// </summary>
    public class TodoContext : DbContext
    {
        /// <summary>
        /// DBSet of todo entries
        /// </summary>
        public DbSet<TodoEntry> TodoEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
