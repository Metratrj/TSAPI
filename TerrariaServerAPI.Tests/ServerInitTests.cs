using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;

namespace TerrariaServerAPI.Tests;

public class ServerInitTests
{
	[Test]
	public void EnsureBoots()
	{
		var are = new AutoResetEvent(false);
		On.Terraria.Main.hook_DedServ cb = (On.Terraria.Main.orig_DedServ orig, Terraria.Main instance) =>
		{
			are.Set();
			Debug.WriteLine("Server startup successful");
		};
		On.Terraria.Main.DedServ += cb;

		new Thread(() => global::TerrariaApi.Server.Program.Main(new string[] { })).Start();

		var hit = are.WaitOne(TimeSpan.FromSeconds(30));

		On.Terraria.Main.DedServ -= cb;

		Assert.That(hit, Is.True);
	}
}
