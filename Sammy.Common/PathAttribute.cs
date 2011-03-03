using System;

namespace Sammy.Common
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class PathAttribute : Attribute
	{
		// Should we handling ordering?
		public string Selector { get; set; }

		public PathAttribute(string selector)
		{
			Selector = selector;
		}
	}
}
