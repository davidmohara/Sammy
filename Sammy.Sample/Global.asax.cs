using System;
using System.Web;
using Castle.Windsor;
using Improving.Core;
using Owin;
using Sammy.Common;

namespace Sammy.Sample
{
	public class Global : HttpApplication, IContainerAccessor
	{
		private IWindsorContainer _container = null;

		protected void Application_Start(object sender, EventArgs e)
		{
			InitializeContainer(this);

			BootstrapHandler.App = BuildAppStack();
		}

		protected void Application_End(object sender, EventArgs e)
		{
			if (Container != null)
				Container.Dispose();
		}

		private IApplication BuildAppStack()
		{
			return new Builder()
				.Use(new ShowExceptions())
				.Run(new SammyApplication(_container.Kernel))
				.ToApp();
		}

		public IWindsorContainer Container
		{
			get
			{
				if (_container == null)
					InitializeContainer(this);
				return _container;
			}
		}

		private static void InitializeContainer(Global app)
		{
			app.CreateContainer();
		}

		public void CreateContainer()
		{
			_container = ContainerBuilder.Create()
				.Build();
		}
	}
}