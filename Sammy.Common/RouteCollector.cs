using System;
using System.Collections.Generic;

namespace Sammy.Common
{
	public static class RouteCollector
	{
		public static IDictionary<string, RouteBase> Collect(Type[] types)
		{
			var routes = new Dictionary<string, RouteBase>();
			foreach (var item in types)
			{
				foreach (var method in item.GetMethods())
				{
					foreach (var attrib in (PathAttribute[])method.GetCustomAttributes(typeof(PathAttribute), false))
					{
						routes.Add(attrib.Selector, new RouteBase(item, method));
					}
				}
			}
			return routes;
		}
	}
}
