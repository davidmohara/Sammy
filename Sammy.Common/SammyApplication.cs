using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Owin;

namespace Sammy.Common
{
    public class SammyApplication : Application, IApplication
	{
		private readonly IKernel _kernel;

		public IDictionary<string, RouteBase> Routes { get; private set; }

		public SammyApplication(IKernel kernel)
			: this(kernel, new[] { Assembly.GetCallingAssembly() })
		{
		}

		public SammyApplication(IKernel kernel, Assembly[] assembly)
		{
			_kernel = kernel;
			var types = assembly.SelectMany<Assembly, Type>(a => a.GetTypes()).ToArray();

			// Should this be off some kind of marker (like HttpApplication)?
			_kernel.Register(AllTypes.From(types).BasedOn<SammyController>());

			// This is getting a bit large - how do we initialize this better?
			Routes = RouteCollector.Collect(_kernel.GetAssignableHandlers(typeof(SammyController)).Select(h => h.Service).ToArray());
		}

		public override IResponse Invoke(IRequest request)
		{
			var route = new RouteMatcher(Routes).Find(request);
			return new ControllerInvoker().Execute(_kernel, request, route);
		}
	}
}
