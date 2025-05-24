using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestLoggingServiceCollectionExtensions
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

    static List<string> Invoked = LoggingServiceCollectionExtensions.Invoked;

    public static object? AddLogging(this object? services)
        => Add("public static object? AddLogging(this object? services)");

    public static object? AddLogging(this object? services, Action<object?> configure)
        => Add("public static object? AddLogging(this object? services, Action<object?> configure)");
}