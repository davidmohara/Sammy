using System.Web;
using Owin;

namespace Sammy.Sample
{
	public class BootstrapHandler : AspNetApplication, IHttpHandler
	{
		internal static IApplication App;

		public override IResponse Invoke(IRequest request)
		{
			return Application.Invoke(App, request);
		}
	}
}
