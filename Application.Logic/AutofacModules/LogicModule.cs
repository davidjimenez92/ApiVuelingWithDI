using Autofac;
using Vueling.Domain.Entities;
using Vueling.Infrastucture.Repositories.Contracts;
using Vueling.Infrastucture.Repositories.Implementations;

namespace Application.Logic.AutofacModules
{
	public class LogicModule: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder
				.RegisterType<StudentRepository>()
				.As<IRepository<Student>>();

			base.Load(builder);

		}
	}
}