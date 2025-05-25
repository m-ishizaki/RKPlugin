using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestContextualOptionsServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);

    static List<string> Invoked = ContextualOptionsServiceCollectionExtensions.Invoked;

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

    [TestMethod]
    public void Test_AddContextualOptions_001() => Test(nameof(_Test_AddContextualOptions_001));
    static void _Test_AddContextualOptions_001(object? services) =>
        PluginServiceCollection.AddContextualOptions(services);

    [TestMethod]
    public void Test_Configure_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_Configure_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_Configure_001(object? services, Func<object?, object?, object?> loadOptions) =>
        PluginServiceCollection.Configure<Object>(services, loadOptions);

    [TestMethod]
    public void Test_Configure_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_Configure_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_Configure_002(object? services, string? name, Func<object?, object?, object?> loadOptions) =>
        PluginServiceCollection.Configure<Object>(services, name, loadOptions);

    [TestMethod]
    public void Test_Configure_003() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_Configure_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_Configure_003(object? services, Action<object?, Object> configure) =>
        PluginServiceCollection.Configure<Object>(services, configure);

    [TestMethod]
    public void Test_Configure_004() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_Configure_004), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_Configure_004(object? services, string? name, Action<object?, Object> configure) =>
        PluginServiceCollection.Configure<Object>(services, name, configure);

    [TestMethod]
    public void Test_ConfigureAll_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_ConfigureAll_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_ConfigureAll_001(object? services, Func<object?, object?, object?> loadOptions) =>
        PluginServiceCollection.ConfigureAll<Object>(services, loadOptions);

    [TestMethod]
    public void Test_ConfigureAll_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_ConfigureAll_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_ConfigureAll_002(object? services, Action<object?, Object> configure) =>
        PluginServiceCollection.ConfigureAll<Object>(services, configure);
}
