using System;
using Owin;
using Castle.MicroKernel;

namespace Sammy.Common
{
	public class ControllerInvoker
	{
		public IResponse Execute(IKernel kernel, IRequest request, RouteBase route)
		{
			// This is kind of nasty and needs to be smarter as well as handling bound models
			var controller = (SammyController)kernel.Resolve(route.Type);
			controller.Request = new Request(request);
			return (IResponse)route.Method.Invoke(controller, null);
		}
	}
}
