using NUnit.Framework;
using Sammy.Common;

namespace Sammy.Test
{

    [TestFixture]
	public class SammyApplicationTests : BaseTest
	{
        [Test]
		public void Should_Register_All_Controllers()
		{
			Assert.IsTrue(Container.Kernel.HasComponent(typeof(TestController)), "Should have registered the TestController");
		}

		[Test]
		public void Should_Discover_Routes()
		{
			Assert.IsNotNull(_app.Routes);
			Assert.AreEqual(2, _app.Routes.Count);
		}

		public override void Initialize()
		{
			_app = new SammyApplication(Container.Kernel);
		}

		private SammyApplication _app;
	}
}