using Kayak.Framework;

namespace Sammy
{
	public class Sample : SammyService
	{
        [Path("/")]
		public void Index()
		{
			ViewData["element"] = System.DateTime.Now;
			NHaml("index");
		}

		[Path("/styles.css")]
		public void Style()
		{
			Less("styles");
		}
	}
}
