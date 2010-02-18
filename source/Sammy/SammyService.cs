using System;
using System.Collections.Generic;
using System.IO;
using Kayak.Framework;
using NHaml;
using NHaml.TemplateResolution;

namespace Sammy
{
	public class SammyService : KayakService
	{
		private FileTemplateContentProvider _contentProvider;
		private TemplateEngine _engine;

        public virtual string RootPath { get; private set; }
        public IDictionary<string, object> ViewData { get; private set; }

		public SammyService()
		{
			RootPath = Path.Combine(Environment.CurrentDirectory, "..");
			ViewData = new Dictionary<string, object>();

			_contentProvider = new FileTemplateContentProvider();
			_contentProvider.AddPathSource(Path.Combine(RootPath, @"views"));
			TemplateOptions options = new TemplateOptions { UseTabs = true, TemplateContentProvider = _contentProvider, TemplateBaseType = typeof(SammyView) };
			_engine = new TemplateEngine(options);
		}

		protected void NHaml(string viewName)
		{
			CompiledTemplate template = _engine.Compile(viewName);
			SammyView instance = template.CreateInstance() as SammyView;
			instance.ViewData = ViewData;
			instance.Render(Response.Output);
		}
	}
}