using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Logic.Contracts;
using Application.Logic.Implementations;
using Autofac;
using Vueling.Domain.Entities;
using Vueling.Test.Framework;

namespace Vueling.Application.Logic.Integration.Tests.AutofacModules
{
	public class ApplicationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<StudentService>().As<IService<Student>>();

			builder.RegisterModule<LogginModule>();

			base.Load(builder);
		}
	}
}
