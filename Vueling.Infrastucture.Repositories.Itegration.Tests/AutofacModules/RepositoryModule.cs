using Autofac;
using Vueling.Domain.Entities;
using Vueling.Infrastucture.Repositories.Contracts;
using Vueling.Infrastucture.Repositories.Implementations;
using Vueling.Test.Framework;

namespace Vueling.Infrastucture.Repositories.Itegration.Tests.AutofacModules
{
	public class RepositoryModule: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<StudentRepository>().As<IRepository<Student>>();

			builder.RegisterModule<LogginModule>();

			base.Load(builder);
		}
	}
}
