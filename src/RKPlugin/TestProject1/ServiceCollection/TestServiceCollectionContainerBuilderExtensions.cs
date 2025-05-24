using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestServiceCollectionContainerBuilderExtensions
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

    static List<string> Invoked = ServiceCollectionContainerBuilderExtensions.Invoked;

    public static object? BuildServiceProvider(this object? services)
            => Add("public static object? BuildServiceProvider(this object? services)");

        public static object? BuildServiceProvider(this object? services, object? options)
            => Add("public static object? BuildServiceProvider(this object? services, object? options)");

        public static object? BuildServiceProvider(this object? services, bool validateScopes)
            => Add("public static object? BuildServiceProvider(this object? services, bool validateScopes)");
    }
