﻿using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestSqlServerCachingServicesExtensions
{
    static Object _lock = new Object();
    void Test(List<string> args, Action act)
    {
        lock (_lock)
        {
            int count = args.Count;
            act();
            Assert.AreEqual(count + 1, args.Count);
            Assert.IsTrue(!args.Reverse<string>().Skip(1).Any(x => x == args.LastOrDefault()));
        }
    }

    static List<string> Invoked = ApplicationEnricherServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddDistributedSqlServerCache_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddDistributedSqlServerCache_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddDistributedSqlServerCache_001(object? services, Action<object?> setupAction) =>
        PluginServiceCollection.AddDistributedSqlServerCache(services, setupAction);
}