﻿using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestOptionsConfigurationServiceCollectionExtensions
{
    static Object _lock = new Lock();
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

    static List<string> Invoked = OptionsConfigurationServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_Configure_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_Configure_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_Configure_001(object? services, object? config) =>
        OptionsConfigurationServiceCollectionExtensions.Configure<object>(services, config);

    [TestMethod]
    public void Test_Configure_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_Configure_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_Configure_002(object? services, string? name, object? config) =>
        OptionsConfigurationServiceCollectionExtensions.Configure<object>(services, name, config);

    [TestMethod]
    public void Test_Configure_003() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_Configure_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_Configure_003(object? services, object? config, Action<object?>? configureBinder) =>
        OptionsConfigurationServiceCollectionExtensions.Configure<object>(services, config, configureBinder);

    [TestMethod]
    public void Test_Configure_004() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_Configure_004), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null, null]));
    static void _Test_Configure_004(object? services, string? name, object? config, Action<object?>? configureBinder) =>
        OptionsConfigurationServiceCollectionExtensions.Configure<object>(services, name, config, configureBinder);
}
