using System;
using System.Reflection;
using System.Web.Http;
using Application.Logic.AutofacModules;
using Autofac;
using Autofac.Integration.WebApi;
using Vueling.Business.Facade.AutofacModules;

namespace Vueling.Business.Facade.App_Start
{
	public class AutofacConfig
	{

		protected AutofacConfig() 
		{
		}
	
		public static IContainer Configure()
		{
			var builder = new ContainerBuilder();

			builder.RegisterModule(new FacadeModule());

			var container = builder.Build();

			var resolver = new AutofacWebApiDependencyResolver(container);
			GlobalConfiguration.Configuration.DependencyResolver = resolver;

			return container;
		}
	}
}