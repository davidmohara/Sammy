using Owin;

namespace Sammy.Common
{
	public abstract class SammyController
	{
		public Request Request { get; set; }
		
		public IResponse Content(string value)
		{
			return new Response(value);
		}
	}
}
