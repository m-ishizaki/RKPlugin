﻿using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestHttpClientLoggingServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = HttpClientLoggingServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddExtendedHttpClientLogging_001() =>
        Test(nameof(
            _Test_AddExtendedHttpClientLogging_001));
    static void _Test_AddExtendedHttpClientLogging_001(object? services) =>
        PluginServiceCollection.AddExtendedHttpClientLogging_(services);

    [TestMethod]
    public void Test_AddExtendedHttpClientLogging_002() =>
        Test(nameof(
            _Test_AddExtendedHttpClientLogging_002));
    static void _Test_AddExtendedHttpClientLogging_002(object? services) =>
        PluginServiceCollection.AddExtendedHttpClientLogging(services, section:null);

    [TestMethod]
    public void Test_AddExtendedHttpClientLogging_003() =>
        Test(nameof(
            _Test_AddExtendedHttpClientLogging_003));
    static void _Test_AddExtendedHttpClientLogging_003(object? services) =>
        PluginServiceCollection.AddExtendedHttpClientLogging(services, configure:Test1.DummyAction);

    [TestMethod]
    public void Test_AddHttpClientLogEnricher_001() =>
        Test(nameof(
            _Test_AddHttpClientLogEnricher_001));
    static void _Test_AddHttpClientLogEnricher_001(object? services) =>
        PluginServiceCollection.AddHttpClientLogEnricher<object>(services);
}
