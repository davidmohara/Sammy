using System;
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
			Console.WriteLine("Sammy has begun on port 3000");
			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
			server.Stop();
		}
	}
}
