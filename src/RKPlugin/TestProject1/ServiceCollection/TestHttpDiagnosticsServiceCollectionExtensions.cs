using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestHttpDiagnosticsServiceCollectionExtensions
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

    public static object? AddDownstreamDependencyMetadata(this object? services, object? downstreamDependencyMetadata)
        => Add("public static object? AddDownstreamDependencyMetadata(this object? services, object? downstreamDependencyMetadata)");

    public static object? AddDownstreamDependencyMetadata<T>(this object? services) where T : class
        => Add("public static object? AddDownstreamDependencyMetadata<T>(this object? services) where T : class");
}
