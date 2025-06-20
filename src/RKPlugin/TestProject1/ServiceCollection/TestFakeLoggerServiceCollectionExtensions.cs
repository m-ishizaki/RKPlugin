﻿using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestFakeLoggerServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = FakeLoggerServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddFakeLogging_001() => Test(nameof(_Test_AddFakeLogging_001));
    static void _Test_AddFakeLogging_001(object? services) =>
        PluginServiceCollection.AddFakeLogging(services, section: null);

    [TestMethod]
    public void Test_AddFakeLogging_002() => Test(nameof(_Test_AddFakeLogging_002));
    static void _Test_AddFakeLogging_002(object? services) =>
        PluginServiceCollection.AddFakeLogging(services, configure: Test1.DummyAction);

    [TestMethod]
    public void Test_AddFakeLogging_003() => Test(nameof(_Test_AddFakeLogging_003));
    static void _Test_AddFakeLogging_003(object? services) =>
        PluginServiceCollection.AddFakeLogging_(services);
}
