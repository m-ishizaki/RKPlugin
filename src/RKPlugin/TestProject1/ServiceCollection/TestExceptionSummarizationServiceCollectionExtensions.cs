﻿using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestExceptionSummarizationServiceCollectionExtensions
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

    static List<string> Invoked = ExceptionSummarizationServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddExceptionSummarizer_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddExceptionSummarizer_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddExceptionSummarizer_001(object? services) =>
        ExceptionSummarizationServiceCollectionExtensions.AddExceptionSummarizer(services);

    [TestMethod]
    public void Test_AddExceptionSummarizer_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddExceptionSummarizer_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddExceptionSummarizer_002(object? services, Action<object?> configure) =>
        ExceptionSummarizationServiceCollectionExtensions.AddExceptionSummarizer(services, configure);
}
