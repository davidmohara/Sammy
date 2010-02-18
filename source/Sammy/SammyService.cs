using System.IO;
using Kayak.Framework;
using NHaml;

namespace Sammy
{
	public class SammyService : KayakService
	{
		private string _rootPath;

		public SammyService(string rootPath)
		{
			_rootPath = rootPath;
		}

		protected void View(string viewName)
		{
			NHaml.TemplateResolution.FileTemplateContentProvider contentProvider = new NHaml.TemplateResolution.FileTemplateContentProvider();
			contentProvider.AddPathSource(Path.Combine(_rootPath, @"views"));
			TemplateOptions options = new TemplateOptions { UseTabs = true, TemplateContentProvider = contentProvider };
			TemplateEngine engine = new TemplateEngine(options);
			CompiledTemplate template = engine.Compile(viewName);
			template.CreateInstance().Render(Response.Output);
		}
	}
}