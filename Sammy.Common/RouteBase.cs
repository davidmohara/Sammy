using System;
using System.Reflection;

namespace Sammy.Common
{
	public class RouteBase
	{
		public Type Type { get; private set; }

		public MethodInfo Method { get; private set; }

		public RouteBase(Type type, MethodInfo method)
		{
			Method = method;
			Type = type;
		}
	}
}
