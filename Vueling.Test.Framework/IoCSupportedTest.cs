using Autofac;
using Autofac.Core;

namespace Vueling.Test.Framework
{
	public class IoCSupportedTest<TModule> where TModule :
		IModule, new()
	{
		private readonly IContainer container;

		public IoCSupportedTest()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule(new TModule());

			container = builder.Build();
		}
		protected TEntity Resolve<TEntity>()
		{
			return container.Resolve<TEntity>();
		}
		protected void ShutDownIoc()
		{
			container.Dispose();
		}
	}
}
