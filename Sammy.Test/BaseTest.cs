using Castle.Windsor;
using NUnit.Framework;

namespace Sammy.Test
{
	public abstract class BaseTest
	{
		public IWindsorContainer Container { get; private set; }

		[SetUp]
		public void Setup()
		{
			Container = CreateContainer();

			Initialize();
		}

		[TearDown]
		public void Teardown()
		{
			Cleanup();
			if (Container != null)
			{
				Container.Dispose();
				Container = null;
			}
		}

		 protected virtual IWindsorContainer CreateContainer()
		{
			return new WindsorContainer();
		}

        public virtual void Initialize()
		{
		}

		public virtual void Cleanup()
		{
		}
	}
}
