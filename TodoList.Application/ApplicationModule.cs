using Autofac;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application
{
    /// <summary>
    /// Builds dependency injection container for this assembly
    /// </summary>
    public class ApplicationModule : Autofac.Module
    {
        /// <summary>
        /// The current assembly
        /// </summary>
        private readonly Assembly _currentAssembly = typeof(ApplicationModule).Assembly;

        /// <summary>
        /// Main execution method
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(_currentAssembly).AsClosedTypesOf(typeof (IRequestHandler<,>));
        }
    }
}
