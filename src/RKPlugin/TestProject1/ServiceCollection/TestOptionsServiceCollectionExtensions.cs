using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestOptionsServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = OptionsServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddOptions_001() =>
        Test(nameof(
            _Test_AddOptions_001));
    static void _Test_AddOptions_001(object? services)
=> PluginServiceCollection.AddOptions(services);

    [TestMethod]
    public void Test_AddOptions_002() =>
        Test(nameof(
            _Test_AddOptions_002));
    static void _Test_AddOptions_002<TOptions>(object? services) where TOptions : class
=> PluginServiceCollection.AddOptions<TOptions>(services);

    [TestMethod]
    public void Test_AddOptions_003() =>
        Test(nameof(
            _Test_AddOptions_003));
    static void _Test_AddOptions_003<TOptions>(object? services, string? name) where TOptions : class
    => PluginServiceCollection.AddOptions<TOptions>(services, name);

    [TestMethod]
    public void Test_AddOptionsWithValidateOnStart_004() =>
        Test(nameof(
             _Test_AddOptionsWithValidateOnStart_004));
    static void _Test_AddOptionsWithValidateOnStart_004<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions>(object? services, string? name = null) where TOptions : class
    => PluginServiceCollection.AddOptionsWithValidateOnStart<object>(services, name);

    [TestMethod]
    public void Test_AddOptionsWithValidateOnStart_005() =>
        Test(nameof(
             _Test_AddOptionsWithValidateOnStart_005));
    static void _Test_AddOptionsWithValidateOnStart_005<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TValidateOptions>(object? services, string? name = null) where TOptions : class where TValidateOptions : class
    => PluginServiceCollection.AddOptionsWithValidateOnStart<object, object>(services, name);

    [TestMethod]
    public void Test_Configure_006() =>
        Test(nameof(
             _Test_Configure_006));
    static void _Test_Configure_006<TOptions>(object? services, Action<TOptions> configureOptions) where TOptions : class
    => PluginServiceCollection.Configure<TOptions>(services, configureOptions);

    [TestMethod]
    public void Test_Configure_007() =>
        Test(nameof(
             _Test_Configure_007));
    static void _Test_Configure_007<TOptions>(object? services, string? name, Action<TOptions> configureOptions) where TOptions : class
    => PluginServiceCollection.Configure<TOptions>(services, name, configureOptions);

    [TestMethod]
    public void Test_ConfigureAll_008() =>
        Test(nameof(
             _Test_ConfigureAll_008));
    static void _Test_ConfigureAll_008<TOptions>(object? services, Action<TOptions> configureOptions) where TOptions : class
    => PluginServiceCollection.ConfigureAll<TOptions>(services, configureOptions);

    [TestMethod]
    public void Test_ConfigureOptions_009() =>
        Test(nameof(
             _Test_ConfigureOptions_009));
    static void _Test_ConfigureOptions_009<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TConfigureOptions>(object? services) where TConfigureOptions : class
    => PluginServiceCollection.ConfigureOptions<object>(services);

    [TestMethod]
    public void Test_ConfigureOptions_010() =>
        Test(nameof(
             _Test_ConfigureOptions_010));
    static void _Test_ConfigureOptions_010(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type configureType)
    => PluginServiceCollection.ConfigureOptions(services, configureType);

    [TestMethod]
    public void Test_ConfigureOptions_011() =>
        Test(nameof(
             _Test_ConfigureOptions_011));
    static void _Test_ConfigureOptions_011(object? services, object configureInstance)
    => PluginServiceCollection.ConfigureOptions(services, configureInstance);

    [TestMethod]
    public void Test_PostConfigure_012() =>
        Test(nameof(
             _Test_PostConfigure_012));
    static void _Test_PostConfigure_012<TOptions>(object? services, Action<TOptions> configureOptions) where TOptions : class
    => PluginServiceCollection.PostConfigure<TOptions>(services, configureOptions);

    [TestMethod]
    public void Test_PostConfigure_013() =>
        Test(nameof(
             _Test_PostConfigure_013));
    static void _Test_PostConfigure_013<TOptions>(object? services, string? name, Action<TOptions> configureOptions) where TOptions : class
    => PluginServiceCollection.PostConfigure<TOptions>(services, name, configureOptions);

    [TestMethod]
    public void Test_PostConfigureAll_014() =>
        Test(nameof(
             _Test_PostConfigureAll_014));
    static void _Test_PostConfigureAll_014<TOptions>(object? services, Action<TOptions> configureOptions) where TOptions : class
    => PluginServiceCollection.PostConfigureAll<TOptions>(services, configureOptions);
}