using System;
using System.Collections.Generic;
using System.IO;
using dotless.Core;
using Kayak.Framework;
using NHaml;
using NHaml.TemplateResolution;

namespace Sammy
{
	public class SammyService : KayakService
	{
		private FileTemplateContentProvider _viewProvider;
		private TemplateEngine _viewEngine;
		private ILessSource _styleProvider;
		private ILessEngine _styleEngine;

        public virtual string ViewRootPath { get; private set; }
		public virtual string StyleRootPath { get; private set; }
        public IDictionary<string, object> ViewData { get; private set; }

		public SammyService()
		{
			ViewRootPath = Path.Combine(Environment.CurrentDirectory, "..");
			StyleRootPath = Path.Combine(Environment.CurrentDirectory, @"..\styles");
			ViewData = new Dictionary<string, object>();

			_viewProvider = new FileTemplateContentProvider();
			_viewProvider.AddPathSource(Path.Combine(ViewRootPath, @"views"));
			TemplateOptions options = new TemplateOptions { UseTabs = true, TemplateContentProvider = _viewProvider, TemplateBaseType = typeof(SammyView) };
			_viewEngine = new TemplateEngine(options);

			_styleProvider = new FileSource();
			_styleEngine = new ExtensibleEngine();
		}

		protected void NHaml(string element)
		{
			CompiledTemplate template = _viewEngine.Compile(element);
			SammyView instance = template.CreateInstance() as SammyView;
			instance.ViewData = ViewData;
			instance.Render(Response.Output);
		}

		protected void Less(string element)
		{
			LessSourceObject source = _styleProvider.GetSource(string.Format("{0}.less",Path.Combine(StyleRootPath, element)));
			Response.Write(_styleEngine.TransformToCss(source));
		}
	}
}