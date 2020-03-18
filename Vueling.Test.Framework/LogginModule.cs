using System.Linq;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using log4net;

namespace Vueling.Test.Framework
{
	public class LogginModule: Module
	{
		protected override void AttachToComponentRegistration(IComponentRegistryBuilder componentRegistry, IComponentRegistration registration)
		{
			registration.Preparing += OnComponentPreparing;
		}

		static void OnComponentPreparing(object sender, PreparingEventArgs e)
		{
			var t = e.Component.Activator.LimitType;
			e.Parameters = e.Parameters.Union(new[]
			{
				new ResolvedParameter((p, i) => p.ParameterType == typeof(ILog), (p, i) => LogManager.GetLogger(t))
			});
		}
	}
}
