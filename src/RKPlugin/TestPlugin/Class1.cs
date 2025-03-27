using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace TestPlugin
{
    public class Class1
    {
        public static string Method(object service)
        {
            var r01 = RkSoftware.RKPlugin.DependencyInjection.PluginHttpClientFactoryServiceCollection.AddHttpClient<ITest, Test>(service, F01)?.ToString();
            var r02 = RkSoftware.RKPlugin.DependencyInjection.PluginServiceCollectionService.AddScoped(service, F02)?.ToString();
            return string.Join(", ", r02, r02);
        }

        static Test F01(HttpClient httpClient) => new Test();

        static Test F02(IServiceProvider serviceProvider) => new Test();

    }

    interface ITest
    {
        string TestMethod();
    }

    class Test : ITest
    {
        public string TestMethod()
        {
            return "Test";
        }
    }
}
