using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Infrastructure.Repository;

namespace TodoList.Infrastructure
{
    /// <summary>
    /// Builds dependency injection container for this assembly
    /// </summary>
    public class InfrastructureModule : Module
    {
        /// <summary>
        /// Main execution method
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TodoRepository>().As<ITodoRepository>().SingleInstance();
        }
    }
}
