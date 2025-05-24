using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestTcpEndpointProbesExtensions
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

    static List<string> Invoked = TcpEndpointProbesExtensions.Invoked;

    public static object? AddTcpEndpointProbe(this object? services)
        => Add("public static object? AddTcpEndpointProbe(this object? services)");

    public static object? AddTcpEndpointProbe(this object? services, string name)
        => Add("public static object? AddTcpEndpointProbe(this object? services, string name)");

    public static object? AddTcpEndpointProbe(this object? services, Action<object?> configure)
        => Add("public static object? AddTcpEndpointProbe(this object? services, Action<object?> configure)");

    public static object? AddTcpEndpointProbe(this object? services, string name, Action<object?> configure)
        => Add("public static object? AddTcpEndpointProbe(this object? services, string name, Action<object?> configure)");

    public static object? AddTcpEndpointProbe(this object? services, object? configurationSection)
        => Add("public static object? AddTcpEndpointProbe(this object? services, object? configurationSection)");

    public static object? AddTcpEndpointProbe(this object? services, string name, object? configurationSection)
        => Add("public static object? AddTcpEndpointProbe(this object? services, string name, object? configurationSection)");
}
