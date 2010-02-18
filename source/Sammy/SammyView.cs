using System.Collections.Generic;
using NHaml;

namespace Sammy
{
	public abstract class SammyView : Template
	{
		public IDictionary<string, object> ViewData { get; set; }
	}
}
