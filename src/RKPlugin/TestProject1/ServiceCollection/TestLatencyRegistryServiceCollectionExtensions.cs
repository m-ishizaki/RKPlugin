using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestLatencyRegistryServiceCollectionExtensions
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

    static List<string> Invoked = LatencyRegistryServiceCollectionExtensions.Invoked;

    public static object? RegisterCheckpointNames(this object? services, params string[] names)
        => Add("public static object? RegisterCheckpointNames(this object? services, params string[] names)");

    public static object? RegisterMeasureNames(this object? services, params string[] names)
        => Add("public static object? RegisterMeasureNames(this object? services, params string[] names)");

    public static object? RegisterTagNames(this object? services, params string[] names)
        => Add("public static object? RegisterTagNames(this object? services, params string[] names)");

    private static void ConfigureOption(this object? services, Action<object?> action)
        => Add("private static void ConfigureOption(this object? services, Action<object?> action)");
}
