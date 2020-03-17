using System.Reflection;
using Application.Logic.AutofacModules;
using Application.Logic.Contracts;
using Application.Logic.Implementations;
using Autofac;
using Autofac.Integration.WebApi;
using Vueling.Domain.Entities;

namespace Vueling.Business.Facade.AutofacModules
{
	public class FacadeModule: Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<StudentService>()
				.As<IService<Student>>();

			builder.RegisterModule(new LogginModule());
			builder.RegisterModule(new LogicModule());

			base.Load(builder);

		}
	}
}