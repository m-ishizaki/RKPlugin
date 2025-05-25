using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestHttpClientFactoryServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);

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

    static List<string> Invoked = HttpClientFactoryServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddHttpClient_001() => Test(nameof(_Test_AddHttpClient_001));
    static void _Test_AddHttpClient_001(object? services)
        => PluginServiceCollection.AddHttpClient(services);

    [TestMethod]
    public void Test_ConfigureHttpClientDefaults_002() => Test(nameof(_Test_ConfigureHttpClientDefaults_002));
    static void _Test_ConfigureHttpClientDefaults_002(object? services)
        => PluginServiceCollection.ConfigureHttpClientDefaults(services, configure: (Action<object?>)Test1.DummyAction);

    [TestMethod]
    public void Test_AddHttpClient_003() =>Test(nameof(_Test_AddHttpClient_003));
    static void _Test_AddHttpClient_003(object? services)
        => PluginServiceCollection.AddHttpClient(services, name: "");

    [TestMethod]
    public void Test_AddHttpClient_004() => Test(nameof(_Test_AddHttpClient_004));
    static void _Test_AddHttpClient_004(object? services)
        => PluginServiceCollection.AddHttpClient(services, name: "", configureClient: Test1.DummyAction);

    [TestMethod]
    public void Test_AddHttpClient_005() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
          _Test_AddHttpClient_005), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_005(object? services, string name, Action<IServiceProvider, HttpClient> configureClient)
    => PluginServiceCollection.AddHttpClient(services, name, configureClient);

    [TestMethod]
    public void Test_AddHttpClient_006() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
          _Test_AddHttpClient_006), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_006<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services) where TClient : class
    => PluginServiceCollection.AddHttpClient<object>(services);

    [TestMethod]
    public void Test_AddHttpClient_007() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddHttpClient_007), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_007<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TClient : class where TImplementation : class, TClient
    => PluginServiceCollection.AddHttpClient<object>(services);

    [TestMethod]
    public void Test_AddHttpClient_008() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
           _Test_AddHttpClient_008), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_008<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, string name) where TClient : class
    => PluginServiceCollection.AddHttpClient<object>(services, name);

    [TestMethod]
    public void Test_AddHttpClient_009() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
          _Test_AddHttpClient_009), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_009<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, string name) where TClient : class where TImplementation : class, TClient
    => PluginServiceCollection.AddHttpClient<object>(services, name);

    [TestMethod]
    public void Test_AddHttpClient_010() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
           _Test_AddHttpClient_010), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_010<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, Action<HttpClient> configureClient) where TClient : class
    => PluginServiceCollection.AddHttpClient<object>(services, configureClient);

    [TestMethod]
    public void Test_AddHttpClient_011() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
         _Test_AddHttpClient_011), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_011<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, Action<IServiceProvider, HttpClient> configureClient) where TClient : class
    => PluginServiceCollection.AddHttpClient<object>(services, configureClient);

    [TestMethod]
    public void Test_AddHttpClient_012() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
          _Test_AddHttpClient_012), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_012<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient
    => PluginServiceCollection.AddHttpClient<object>(services, configureClient);

    [TestMethod]
    public void Test_AddHttpClient_013() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
       _Test_AddHttpClient_013), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_013<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient
    => PluginServiceCollection.AddHttpClient<object>(services, configureClient);

    [TestMethod]
    public void Test_AddHttpClient_014() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
           _Test_AddHttpClient_014), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_014<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, string name, Action<HttpClient> configureClient) where TClient : class
    => PluginServiceCollection.AddHttpClient<object>(services, name, configureClient);

    [TestMethod]
    public void Test_AddHttpClient_015() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
         _Test_AddHttpClient_015), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_015<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class
    => PluginServiceCollection.AddHttpClient<object>(services, name, configureClient);

    [TestMethod]
    public void Test_AddHttpClient_016() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
          _Test_AddHttpClient_016), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_016<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, string name, Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient
    => PluginServiceCollection.AddHttpClient<object>(services, name, configureClient);

    [TestMethod]
    public void Test_AddHttpClient_017() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddHttpClient_017), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_017<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient
    => PluginServiceCollection.AddHttpClient<object>(services, name, configureClient);

    [TestMethod]
    public void Test_AddHttpClient_018() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
          _Test_AddHttpClient_018), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_018<TClient, TImplementation>(object? services, Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient
    => PluginServiceCollection.AddHttpClient<TClient, TImplementation>(services, factory);

    [TestMethod]
    public void Test_AddHttpClient_019() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
          _Test_AddHttpClient_019), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_019<TClient, TImplementation>(object? services, string name, Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient
    => PluginServiceCollection.AddHttpClient<TClient, TImplementation>(services, name, factory);

    [TestMethod]
    public void Test_AddHttpClient_020() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
          _Test_AddHttpClient_020), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_020<TClient, TImplementation>(object? services, Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient
    => PluginServiceCollection.AddHttpClient<TClient, TImplementation>(services, factory);

    [TestMethod]
    public void Test_AddHttpClient_021() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
          _Test_AddHttpClient_021), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClient_021<TClient, TImplementation>(object? services, string name, Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient
    => PluginServiceCollection.AddHttpClient<TClient, TImplementation>(services, name, factory);

}

