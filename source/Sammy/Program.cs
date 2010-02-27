using System;
using System.IO;
using System.Net;
using Kayak;
using Kayak.Framework;

namespace Sammy
{
	class Program
	{
		static void Main(string[] args)
		{
			KayakServer server = new KayakServer();
			server.UseFramework();

			server.Start(new System.Net.IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000));
			server.MapDirectory("/", Path.Combine(Environment.CurrentDirectory, "../public"));
			server.AddResponder(new FileNotFoundResponder());
	
			Console.WriteLine("Sammy has begun on port 3000");
			Console.WriteLine("Press Control-Z to exit");
			ConsoleKeyInfo key = Console.ReadKey();
			while (!(key.Key == ConsoleKey.Z && key.Modifiers == ConsoleModifiers.Control))
			{
				key = Console.ReadKey();
			}
			server.Stop();
		}
	}
}
