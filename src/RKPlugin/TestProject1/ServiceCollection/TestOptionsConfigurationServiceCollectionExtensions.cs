using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestOptionsConfigurationServiceCollectionExtensions
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

    static List<string> Invoked = OptionsConfigurationServiceCollectionExtensions.Invoked;

    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, object? config) where TOptions : class
        => Add("public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, object? config) where TOptions : class");

    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, string? name, object? config) where TOptions : class
        => Add("public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, string? name, object? config) where TOptions : class");

    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, object? config, Action<object?>? configureBinder) where TOptions : class
        => Add("public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, object? config, Action<object?>? configureBinder) where TOptions : class");

    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, string? name, object? config, Action<object?>? configureBinder) where TOptions : class
        => Add("public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, string? name, object? config, Action<object?>? configureBinder) where TOptions : class");
}
