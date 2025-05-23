using Microsoft.Extensions.AmbientMetadata.Application;
using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using System.Reflection;
using System.Security.AccessControl;
using System.Xml.Linq;

namespace TestProject1;

[TestClass]
public sealed class Test1
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

    [TestMethod]
    public void TestMethod001() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod001), BindingFlags.NonPublic | BindingFlags.Static)!, null, []));
    static void _TestMethod001(object? services) => PluginServiceCollection.AddHttpClient(services);
    [TestMethod]
    public void TestMethod003() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod003(object? services, Action<object?> configure) =>
        PluginServiceCollection.ConfigureHttpClientDefaults(services, configure);
    [TestMethod]
    public void TestMethod004() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod004), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod004(object? services, string name) =>
        PluginServiceCollection.AddHttpClient(services, name);
    [TestMethod]
    public void TestMethod005() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod005), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod005(object? services, string name, Action<HttpClient> configureClient) =>
        PluginServiceCollection.AddHttpClient(services, name, configureClient);
    [TestMethod]
    public void TestMethod006() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod006), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod006(object? services, string name, Action<IServiceProvider, HttpClient> configureClient) =>
        PluginServiceCollection.AddHttpClient(services, name, configureClient);
    [TestMethod]
    public void TestMethod007() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod007), BindingFlags.NonPublic | BindingFlags.Static)!, null, []));
    static void _TestMethod007(object? services) =>
        PluginServiceCollection.AddHttpClient<Object>(services);
    [TestMethod]
    public void TestMethod008() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod008), BindingFlags.NonPublic | BindingFlags.Static)!, null, []));
    static void _TestMethod008(object? services) =>
        PluginServiceCollection.AddHttpClient<Object, Object>(services);
    [TestMethod]
    public void TestMethod009() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod009), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod009(object? services, string name) =>
        PluginServiceCollection.AddHttpClient<Object>(services, name);
    [TestMethod]
    public void TestMethod010() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod010), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod010(object? services, string name) =>
        PluginServiceCollection.AddHttpClient<Object, Object>(services, name);
    [TestMethod]
    public void TestMethod011() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod011), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod011(object? services, Action<HttpClient> configureClient) =>
        PluginServiceCollection.AddHttpClient<Object>(services, configureClient);
    [TestMethod]
    public void TestMethod012() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod012), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod012(object? services, Action<IServiceProvider, HttpClient> configureClient) =>
        PluginServiceCollection.AddHttpClient<Object>(services, configureClient);
    [TestMethod]
    public void TestMethod013() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod013), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod013(object? services, Action<HttpClient> configureClient) =>
        PluginServiceCollection.AddHttpClient<Object, Object>(services, configureClient);
    [TestMethod]
    public void TestMethod014() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod014), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod014(object? services, Action<IServiceProvider, HttpClient> configureClient) =>
        PluginServiceCollection.AddHttpClient<Object, Object>(services, configureClient);
    [TestMethod]
    public void TestMethod015() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod015), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod015(object? services, string name, Action<HttpClient> configureClient) =>
        PluginServiceCollection.AddHttpClient<Object>(services, name, configureClient);
    [TestMethod]
    public void TestMethod016() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod016), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod016(object? services, string name, Action<IServiceProvider, HttpClient> configureClient) =>
        PluginServiceCollection.AddHttpClient<Object>(services, name, configureClient);
    [TestMethod]
    public void TestMethod017() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod017), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod017(object? services, string name, Action<HttpClient> configureClient) =>
        PluginServiceCollection.AddHttpClient<Object, Object>(services, name, configureClient);
    [TestMethod]
    public void TestMethod018() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod018), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod018(object? services, string name, Action<IServiceProvider, HttpClient> configureClient) =>
        PluginServiceCollection.AddHttpClient<Object, Object>(services, name, configureClient);
    [TestMethod]
    public void TestMethod019() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod019), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod019(object? services, Func<HttpClient, Object> factory) =>
        PluginServiceCollection.AddHttpClient<Object, Object>(services, factory);
    [TestMethod]
    public void TestMethod020() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod020), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod020(object? services, string name, Func<HttpClient, Object> factory) =>
        PluginServiceCollection.AddHttpClient<Object, Object>(services, name, factory);
    [TestMethod]
    public void TestMethod021() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod021), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod021(object? services, Func<HttpClient, IServiceProvider, Object> factory) =>
        PluginServiceCollection.AddHttpClient<Object, Object>(services, factory);
    [TestMethod]
    public void TestMethod022() => Test(HttpClientFactoryServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod022), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod022(object? services, string name, Func<HttpClient, IServiceProvider, Object> factory) =>
        PluginServiceCollection.AddHttpClient<Object, Object>(services, name, factory);

    [TestMethod]
    public void TestMethod101() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod101), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod101(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollection.AddTransient(services, serviceType, implementationType);
    [TestMethod]
    public void TestMethod102() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod102), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod102(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) =>
        PluginServiceCollection.AddTransient(services, serviceType, implementationFactory);
    [TestMethod]
    public void TestMethod103() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod103), BindingFlags.NonPublic | BindingFlags.Static)!, null, []));
    static void _TestMethod103(object? services) =>
        PluginServiceCollection.AddTransient<Object, Object>(services);
    [TestMethod]
    public void TestMethod104() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod104), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod104(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) =>
        PluginServiceCollection.AddTransient(services, serviceType);
    [TestMethod]
    public void TestMethod105() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod105), BindingFlags.NonPublic | BindingFlags.Static)!, null, []));
    static void _TestMethod105(object? services) =>
        PluginServiceCollection.AddTransient<Object>(services);
    [TestMethod]
    public void TestMethod106() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod106), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod106(object? services, Func<IServiceProvider, Object> implementationFactory) =>
        PluginServiceCollection.AddTransient<Object>(services, implementationFactory);
    [TestMethod]
    public void TestMethod107() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod107), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod107(object? services, Func<IServiceProvider, Object> implementationFactory) =>
        PluginServiceCollection.AddTransient<Object, Object>(services, implementationFactory);
    [TestMethod]
    public void TestMethod108() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod108), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod108(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollection.AddScoped(services, serviceType, implementationType);
    [TestMethod]
    public void TestMethod109() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod109), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod109(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) =>
        PluginServiceCollection.AddScoped(services, serviceType, implementationFactory);
    [TestMethod]
    public void TestMethod110() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod110), BindingFlags.NonPublic | BindingFlags.Static)!, null, []));
    static void _TestMethod110(object? services) =>
        PluginServiceCollection.AddScoped<Object, Object>(services);
    [TestMethod]
    public void TestMethod111() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod111), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod111(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) =>
        PluginServiceCollection.AddScoped(services, serviceType);
    [TestMethod]
    public void TestMethod112() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod112), BindingFlags.NonPublic | BindingFlags.Static)!, null, []));
    static void _TestMethod112(object? services) =>
        PluginServiceCollection.AddScoped<Object>(services);
    [TestMethod]
    public void TestMethod113() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod113), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod113(object? services, Func<IServiceProvider, Object> implementationFactory) =>
        PluginServiceCollection.AddScoped<Object>(services, implementationFactory);
    [TestMethod]
    public void TestMethod114() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod114), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod114(object? services, Func<IServiceProvider, Object> implementationFactory) =>
        PluginServiceCollection.AddScoped<Object, Object>(services, implementationFactory);
    [TestMethod]
    public void TestMethod115() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod115), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod115(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollection.AddSingleton(services, serviceType, implementationType);
    [TestMethod]
    public void TestMethod116() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod116), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod116(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) =>
        PluginServiceCollection.AddSingleton(services, serviceType, implementationFactory);
    [TestMethod]
    public void TestMethod117() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod117), BindingFlags.NonPublic | BindingFlags.Static)!, null, []));
    static void _TestMethod117(object? services) =>
        PluginServiceCollection.AddSingleton<Object, Object>(services);
    [TestMethod]
    public void TestMethod118() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod118), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod118(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) =>
        PluginServiceCollection.AddSingleton(services, serviceType);
    [TestMethod]
    public void TestMethod119() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod119), BindingFlags.NonPublic | BindingFlags.Static)!, null, []));
    static void _TestMethod119(object? services) =>
        PluginServiceCollection.AddSingleton<Object>(services);
    [TestMethod]
    public void TestMethod120() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod120), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod120(object? services, Func<IServiceProvider, Object> implementationFactory) =>
        PluginServiceCollection.AddSingleton<Object>(services, implementationFactory);
    [TestMethod]
    public void TestMethod121() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod121), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod121(object? services, Func<IServiceProvider, Object> implementationFactory) =>
        PluginServiceCollection.AddSingleton<Object, Object>(services, implementationFactory);
    [TestMethod]
    public void TestMethod122() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod122), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _TestMethod122(object? services, Type serviceType, object implementationInstance) =>
        PluginServiceCollection.AddSingleton(services, serviceType, implementationInstance);
    [TestMethod]
    public void TestMethod123() => Test(ServiceCollectionServiceExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod123), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod123(object? services, object implementationInstance) =>
        PluginServiceCollection.AddSingleton<Object>(services, implementationInstance);


    // ApplicationEnricherServiceCollectionExtensions
    [TestMethod]
    public void TestMethod01_001() => Test(ApplicationEnricherServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod01_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, []));
    static void _TestMethod01_001(object? services) =>
        PluginServiceCollection.AddServiceLogEnricher(services);

    [TestMethod]
    public void TestMethod01_002() => Test(ApplicationEnricherServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod01_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod01_002(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddServiceLogEnricher(services, configure);

    [TestMethod]
    public void TestMethod01_003() => Test(ApplicationEnricherServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod01_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod01_003(object? services, object? section) =>
        PluginServiceCollection.AddServiceLogEnricher_(services, section);

    // ApplicationMetadataServiceCollectionExtensions
    /*
    [TestMethod]
    public void TestMethod02_001() => Test(ApplicationMetadataServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod02_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod02_001(object? services, object? section) =>
        PluginServiceCollection.AddApplicationMetadata(services, section);

    [TestMethod]
    public void TestMethod02_002() => Test(ApplicationMetadataServiceCollectionExtensions.Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _TestMethod02_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _TestMethod02_002(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddApplicationMetadata(services, configure);
    */








    // ApplicationMetadataServiceCollectionExtensions
    // AsyncStateExtensions
    // AutoActivationExtensions
    // CommonHealthChecksExtensions
    // EncoderServiceCollectionExtensions
    // EncoderServiceCollectionExtensions
    // EnrichmentServiceCollectionExtensions
    // EnrichmentServiceCollectionExtensions
    // ExceptionSummarizationServiceCollectionExtensions
    // ServiceCollectionDescriptorExtensions
    // FakeLoggerServiceCollectionExtensions
    // FakeRedactionServiceCollectionExtensions
    // HealthCheckServiceCollectionExtensions
    // HttpClientFactoryServiceCollectionExtensions
    // HttpClientLatencyTelemetryExtensions
    // HttpClientLoggingServiceCollectionExtensions
    // HttpDiagnosticsServiceCollectionExtensions
    // HybridCacheServiceExtensions
    // KubernetesProbesExtensions
    // LatencyConsoleExtensions
    // LatencyContextExtensions
    // LatencyRegistryServiceCollectionExtensions
    // LocalizationServiceCollectionExtensions
    // LoggingServiceCollectionExtensions
    // MemoryCacheServiceCollectionExtensions
    // MetricsServiceExtensions
    // NullLatencyContextServiceCollectionExtensions
    // ObjectPoolServiceCollectionExtensions
    // OptionsConfigurationServiceCollectionExtensions
    // OptionsServiceCollectionExtensions
    // ProcessEnricherServiceCollectionExtensions
    // RedactionServiceCollectionExtensions
    // ResilienceServiceCollectionExtensions
    // ResourceMonitoringServiceCollectionExtensions
    // ServiceCollectionContainerBuilderExtensions
    // ServiceCollectionHostedServiceExtensions
    // ServiceCollectionServiceExtensions
    // SqlServerCachingServicesExtensions
    // StackExchangeRedisCacheServiceCollectionExtensions
    // TcpEndpointProbesExtensions
    // SystemdHostBuilderExtensions
    // WindowsServiceLifetimeHostBuilderExtensions


}