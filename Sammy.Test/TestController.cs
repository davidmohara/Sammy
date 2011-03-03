using System;
using Sammy.Common;
using Owin;

namespace Sammy.Test
{
	public class TestController : SammyController
	{
		[Path("/")]
		public IRequest Index()
		{
			return null;
		}

		[Path("/Something")]
		public IRequest Something()
		{
			return null;
		}
	}
}
