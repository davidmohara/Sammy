using NUnit.Framework;
using Sammy.Common;

namespace Sammy.Test
{
	[TestFixture]
	public class RouteCollectorTests
	{
		[Test]
		public void Should_Collect_Routes()
		{
			var routes = RouteCollector.Collect(new[] { typeof(TestController) });
			Assert.IsNotNull(routes);
			Assert.AreEqual(2, routes.Count);
		}
	}
}
