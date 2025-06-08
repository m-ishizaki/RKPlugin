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

    public static void Test(string methodName, Object caller, Object @lock, List<string> invoked)
    {
        var method = caller.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
        var act = () => PluginLoadContext.Invoke(new object(), method);

        lock (_lock)
        {
            int count = invoked.Count;
            act();
            Assert.AreEqual(count + 1, invoked.Count);
            Assert.IsTrue(!invoked.Reverse<string>().Skip(1).Any(x => x == invoked.LastOrDefault()));
        }
    }

    public static void DummyAction(object? onj) { }
    public static object? DummyFunc(object? onj) => null;
    public static IEnumerable<object> Enumerable = null;

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