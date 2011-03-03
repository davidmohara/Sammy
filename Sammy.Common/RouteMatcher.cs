using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Owin;

namespace Sammy.Common
{
	public class RouteMatcher
	{
		private readonly IDictionary<string, RouteBase> _routes;

		public RouteMatcher(IDictionary<string, RouteBase> routes)
		{
			_routes = routes;
		}

		public RouteBase Find(IRequest request)
		{
			return _routes.FirstOrDefault(route => Regex.IsMatch(route.Key, request.Uri, RegexOptions.IgnoreCase)).Value;
		}
	}
}
