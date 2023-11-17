using Autofac;
using System.Linq;
using System.Reflection;

namespace Web.App.Infrastructure
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            var assemblies = executingAssembly.GetReferencedAssemblies()
                .Select(Assembly.Load)
                .Where(x => x.Location.Contains("Athena"))
            .ToList();

            assemblies.Add(executingAssembly);

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .AsImplementedInterfaces()
                .AsSelf();
        }
    }
}
