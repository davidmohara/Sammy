using Owin;
using Sammy.Common;

namespace Sammy.Sample.Controllers
{
    public class HomeController : SammyController
    {
		[Path("/")]
		public IResponse Index()
		{
			return Content("Hello");
		}

    }
}
