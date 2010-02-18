using Kayak.Framework;
using NHaml;

namespace Sammy
{
	public class SampleService : SammyService
	{
		public SampleService() : base(@"c:\develop\sammy\source\Sammy\")
		{
		}

		[Path("/")]
		public void Index()
		{
			View("index");
		}
	}
}
