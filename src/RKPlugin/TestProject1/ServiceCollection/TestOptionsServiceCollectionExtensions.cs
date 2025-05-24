using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestOptionsServiceCollectionExtensions
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

    static List<string> Invoked = OptionsServiceCollectionExtensions.Invoked;

    [TestMethod]
    public static object? AddOptions(this object? services)
        => Add("public static object? AddOptions(this object? services)");

    [TestMethod]
    public static object? AddOptions<TOptions>(this object? services) where TOptions : class
        => Add("public static object? AddOptions<TOptions>(this object? services) where TOptions : class");

    [TestMethod]
    public static object? AddOptions<TOptions>(this object? services, string? name) where TOptions : class
        => Add("public static object? AddOptions<TOptions>(this object? services, string? name) where TOptions : class");

    [TestMethod]
    public static object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions>(this object? services, string? name = null) where TOptions : class
        => Add("public static object? AddOptionsWithValidateOnStart<TOptions>(this IServiceCollection services, string? name = null) where TOptions : class");

    [TestMethod]
    public static object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TValidateOptions>(this object? services, string? name = null) where TOptions : class where TValidateOptions : class
        => Add("public static object? AddOptionsWithValidateOnStart<TOptions, TValidateOptions>(this IServiceCollection services, string? name = null) where TOptions : class where TValidateOptions : class, IValidateOptions<TOptions>");

    [TestMethod]
    public static object? Configure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
        => Add("public static object? Configure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class");

    [TestMethod]
    public static object? Configure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class
        => Add("public static object? Configure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class");

    [TestMethod]
    public static object? ConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
        => Add("public static object? ConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class");

    [TestMethod]
    public static object? ConfigureOptions<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TConfigureOptions>(this object? services) where TConfigureOptions : class
        => Add("public static object? ConfigureOptions<TConfigureOptions>(this object? services) where TConfigureOptions : class");

    [TestMethod]
    public static object? ConfigureOptions(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type configureType)
        => Add("public static object? ConfigureOptions(this object? services, Type configureType)");

    [TestMethod]
    public static object? ConfigureOptions(this object? services, object configureInstance)
        => Add("public static object? ConfigureOptions(this object? services, object configureInstance)");

    [TestMethod]
    public static object? PostConfigure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
        => Add("public static object? PostConfigure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class");

    [TestMethod]
    public static object? PostConfigure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class
        => Add("public static object? PostConfigure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class");

    [TestMethod]
    public static object? PostConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
        => Add("public static object? PostConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class");
}