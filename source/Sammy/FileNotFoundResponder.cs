using System;
using Kayak;

namespace Sammy
{
	public class FileNotFoundResponder : IKayakResponder
	{
		public void Respond(KayakContext context, Action<Exception> callback)
		{
			context.Response.WriteLine("Nope, didn't find it");
			context.Response.SetStatusToNotFound();
			callback(null);
		}

		public void WillRespond(KayakContext context, Action<bool, Exception> callback)
		{
			callback(true, null);
		}
	}
}
