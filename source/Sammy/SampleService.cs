using Kayak.Framework;

namespace Sammy
{
	public class SampleService : SammyService
	{
		[Path("/")]
		public void Index()
		{
			ViewData["element"] = System.DateTime.Now;
			NHaml("index");
		}
	}
}
