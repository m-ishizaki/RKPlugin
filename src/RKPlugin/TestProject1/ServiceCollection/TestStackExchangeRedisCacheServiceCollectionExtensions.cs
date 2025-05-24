using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestStackExchangeRedisCacheServiceCollectionExtensions
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

    static List<string> Invoked = StackExchangeRedisCacheServiceCollectionExtensions.Invoked;

    public static object? AddStackExchangeRedisCache(this object? services, object? section)
        => Add("public static object? AddStackExchangeRedisCache(this object? services, object? section)");

    public static object? AddStackExchangeRedisCache(this object? services, Action<object?> configure)
        => Add("public static object? AddStackExchangeRedisCache(this object? services, Action<object?> configure)");
}