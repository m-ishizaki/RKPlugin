# RKPlugin
[![NuGet version (RkSoftware.RKPlugin)](https://img.shields.io/nuget/v/RkSoftware.RKPlugin.svg?style=flat-square)](https://www.nuget.org/packages/RkSoftware.RKPlugin/)  ![workflow](https://github.com/m-ishizaki/RKPlugin/actions/workflows/dotnet.yml/badge.svg)

# Usage
#### Applocation Code  
Example in a web application  
This is the code that calls the "ConfigureServices" method of the plugin library.
```cs
var pluginPath = Path.Combine(Assembly.GetEntryAssembly()?.Location!, "../../../../../TestPlugin/bin/Debug/net10.0");
var plugins = PluginLoadContext.LoadExtensions(pluginPath);
foreach (var plugin in plugins)
    foreach (var assembly in plugin.Assemblies)
        foreach (var type in assembly.GetTypes())
        {
            var method = type.GetMethod("ConfigureServices");
            if (method != null)
            {
                var result = PluginLoadContext.Invoke(services, method, null, null);
                Debug.Write(result);
            }
        }
```

#### Plugin Library Code  
Create a class library project  
Use the methods of the "PluginServiceCollection" class in the "ConfigureServices" method.  

The plugin does not need to reference assemblies such as "Microsoft.Extensions.Http" or "Microsoft.Extensions.DependencyInjection.Abstractions".  

```cs
public class Class1
{
    public static string ConfigureServices(object services)
    {
        var r01 = PluginServiceCollection.AddHttpClient<ITest, Test>(services, F01)?.ToString();
        var r02 = PluginServiceCollection.AddScoped(services, F02)?.ToString();
        return string.Join(", ", r02, r02);
    }
    static Test F01(HttpClient httpClient) => new Test();
    static Test F02(IServiceProvider serviceProvider) => new Test();
}
```
## Where to put the class library DLL
The DLL file will be loaded as a plugin by placing it in the path specified in the argument of the **PluginLoadContext.LoadExtensions** method. 
```cs
var pluginPath = Path.Combine(Assembly.GetEntryAssembly()?.Location!, "../../../../../TestPlugin/bin/Debug/net10.0");
var plugins = PluginLoadContext.LoadExtensions(pluginPath);
```

# What is implemented
Extension Methods on ServiceCollection

- AddTransient
- AddScoped
- AddSingleton
- AddHttpClient
- ConfigureHttpClientDefaults

"Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions,Microsoft.Extensions.Http"  
"Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions,Microsoft.Extensions.DependencyInjection.Abstractions"  


