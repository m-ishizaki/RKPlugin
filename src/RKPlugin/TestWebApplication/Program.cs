using RkSoftware.RKPlugin;
using System.Diagnostics;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

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

services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();


#region



/*

AddWebEncoders(IServiceCollection)	
AddWebEncoders(IServiceCollection, Action<WebEncoderOptions>)	
AddLogEnricher(IServiceCollection, ILogEnricher)	
AddLogEnricher<T>(IServiceCollection)	
AddStaticLogEnricher(IServiceCollection, IStaticLogEnricher)	
AddStaticLogEnricher<T>(IServiceCollection)	
AddExceptionSummarizer(IServiceCollection)	
AddExceptionSummarizer(IServiceCollection, Action<IExceptionSummarizationBuilder>)	
Add(IServiceCollection, ServiceDescriptor)	
Add(IServiceCollection, IEnumerable<ServiceDescriptor>)	
RemoveAll(IServiceCollection, Type)	
RemoveAll<T>(IServiceCollection)	
RemoveAllKeyed(IServiceCollection, Type, Object)	
RemoveAllKeyed<T>(IServiceCollection, Object)	
Replace(IServiceCollection, ServiceDescriptor)	
TryAdd(IServiceCollection, ServiceDescriptor)	
TryAdd(IServiceCollection, IEnumerable<ServiceDescriptor>)	
TryAddEnumerable(IServiceCollection, ServiceDescriptor)	
TryAddEnumerable(IServiceCollection, IEnumerable<ServiceDescriptor>)	
TryAddKeyedScoped(IServiceCollection, Type, Object)	
TryAddKeyedScoped(IServiceCollection, Type, Object, Func<IServiceProvider, Object, Object>)	
TryAddKeyedScoped(IServiceCollection, Type, Object, Type)	
TryAddKeyedScoped<TService>(IServiceCollection, Object)	
TryAddKeyedScoped<TService>(IServiceCollection, Object, Func<IServiceProvider, Object, TService>)	
TryAddKeyedScoped<TService, TImplementation>(IServiceCollection, Object)	
TryAddKeyedSingleton(IServiceCollection, Type, Object)	
TryAddKeyedSingleton(IServiceCollection, Type, Object, Func<IServiceProvider, Object, Object>)	
TryAddKeyedSingleton(IServiceCollection, Type, Object, Type)	
TryAddKeyedSingleton<TService>(IServiceCollection, Object)	
TryAddKeyedSingleton<TService>(IServiceCollection, Object, TService)	
TryAddKeyedSingleton<TService>(IServiceCollection, Object, Func<IServiceProvider, Object, TService>)	
TryAddKeyedSingleton<TService, TImplementation>(IServiceCollection, Object)	
TryAddKeyedTransient(IServiceCollection, Type, Object)	
TryAddKeyedTransient(IServiceCollection, Type, Object, Func<IServiceProvider, Object, Object>)	
TryAddKeyedTransient(IServiceCollection, Type, Object, Type)	
TryAddKeyedTransient<TService>(IServiceCollection, Object)	
TryAddKeyedTransient<TService>(IServiceCollection, Object, Func<IServiceProvider, Object, TService>)	
TryAddKeyedTransient<TService, TImplementation>(IServiceCollection, Object)	
TryAddScoped(IServiceCollection, Type)	
TryAddScoped(IServiceCollection, Type, Func<IServiceProvider, Object>)	
TryAddScoped(IServiceCollection, Type, Type)	
TryAddScoped<TService>(IServiceCollection)	
TryAddScoped<TService>(IServiceCollection, Func<IServiceProvider, TService>)	
TryAddScoped<TService, TImplementation>(IServiceCollection)	
TryAddSingleton(IServiceCollection, Type)	
TryAddSingleton(IServiceCollection, Type, Func<IServiceProvider, Object>)	
TryAddSingleton(IServiceCollection, Type, Type)	
TryAddSingleton<TService>(IServiceCollection)	
TryAddSingleton<TService>(IServiceCollection, TService)	
TryAddSingleton<TService>(IServiceCollection, Func<IServiceProvider, TService>)	
TryAddSingleton<TService, TImplementation>(IServiceCollection)	
TryAddTransient(IServiceCollection, Type)	
TryAddTransient(IServiceCollection, Type, Func<IServiceProvider, Object>)	
TryAddTransient(IServiceCollection, Type, Type)	
TryAddTransient<TService>(IServiceCollection)	
TryAddTransient<TService>(IServiceCollection, Func<IServiceProvider, TService>)	
TryAddTransient<TService, TImplementation>(IServiceCollection)	
AddFakeLogging(IServiceCollection)	
AddFakeLogging(IServiceCollection, IConfigurationSection)	
AddFakeLogging(IServiceCollection, Action<FakeLogCollectorOptions>)	
AddFakeRedaction(IServiceCollection)	
AddFakeRedaction(IServiceCollection, Action<FakeRedactorOptions>)	
AddHealthChecks(IServiceCollection)	
AddHttpClient(IServiceCollection)	
AddHttpClient(IServiceCollection, String)	
AddHttpClient(IServiceCollection, String, Action<IServiceProvider, HttpClient>)	
AddHttpClient(IServiceCollection, String, Action<HttpClient>)	
AddHttpClient<TClient>(IServiceCollection)	
AddHttpClient<TClient>(IServiceCollection, Action<IServiceProvider, HttpClient>)	
AddHttpClient<TClient>(IServiceCollection, Action<HttpClient>)	
AddHttpClient<TClient>(IServiceCollection, String)	
AddHttpClient<TClient>(IServiceCollection, String, Action<IServiceProvider, HttpClient>)	
AddHttpClient<TClient>(IServiceCollection, String, Action<HttpClient>)	
AddHttpClient<TClient, TImplementation>(IServiceCollection)	
AddHttpClient<TClient, TImplementation>(IServiceCollection, Action<IServiceProvider, HttpClient>)	
AddHttpClient<TClient, TImplementation>(IServiceCollection, Action<HttpClient>)	
AddHttpClient<TClient,TImplementation>(IServiceCollection, Func<HttpClient,TImplementation>)	
AddHttpClient<TClient,TImplementation>(IServiceCollection, Func<HttpClient,IServiceProvider,TImplementation>)	
AddHttpClient<TClient,TImplementation>(IServiceCollection, String)	
AddHttpClient<TClient,TImplementation>(IServiceCollection, String, Action<IServiceProvider,HttpClient>)	
AddHttpClient<TClient,TImplementation>(IServiceCollection, String, Action<HttpClient>)	
AddHttpClient<TClient,TImplementation>(IServiceCollection, String, Func<HttpClient,TImplementation>)	
AddHttpClient<TClient,TImplementation>(IServiceCollection, String, Func<HttpClient,IServiceProvider,TImplementation>)	
ConfigureHttpClientDefaults(IServiceCollection, Action<IHttpClientBuilder>)	
AddHttpClientLatencyTelemetry(IServiceCollection)	
AddHttpClientLatencyTelemetry(IServiceCollection, IConfigurationSection)	
AddHttpClientLatencyTelemetry(IServiceCollection, Action<HttpClientLatencyTelemetryOptions>)	
AddExtendedHttpClientLogging(IServiceCollection)	
AddExtendedHttpClientLogging(IServiceCollection, IConfigurationSection)	
AddExtendedHttpClientLogging(IServiceCollection, Action<LoggingOptions>)	
AddHttpClientLogEnricher<T>(IServiceCollection)	
AddDownstreamDependencyMetadata(IServiceCollection, IDownstreamDependencyMetadata)	
AddDownstreamDependencyMetadata<T>(IServiceCollection)	
AddHybridCache(IServiceCollection)	
AddHybridCache(IServiceCollection, Action<HybridCacheOptions>)	
AddKubernetesProbes(IServiceCollection)	
AddKubernetesProbes(IServiceCollection, IConfigurationSection)	
AddKubernetesProbes(IServiceCollection, Action<KubernetesProbesOptions>)	
AddConsoleLatencyDataExporter(IServiceCollection)	
AddConsoleLatencyDataExporter(IServiceCollection, IConfigurationSection)	
AddConsoleLatencyDataExporter(IServiceCollection, Action<LatencyConsoleOptions>)	
AddLatencyContext(IServiceCollection)	
AddLatencyContext(IServiceCollection, IConfigurationSection)	
AddLatencyContext(IServiceCollection, Action<LatencyContextOptions>)	
RegisterCheckpointNames(IServiceCollection, String[])	
RegisterMeasureNames(IServiceCollection, String[])	
RegisterTagNames(IServiceCollection, String[])	
AddLocalization(IServiceCollection)	
AddLocalization(IServiceCollection, Action<LocalizationOptions>)	
AddLogging(IServiceCollection)	
AddLogging(IServiceCollection, Action<ILoggingBuilder>)	
AddDistributedMemoryCache(IServiceCollection)	
AddDistributedMemoryCache(IServiceCollection, Action<MemoryDistributedCacheOptions>)	
AddMemoryCache(IServiceCollection)	
AddMemoryCache(IServiceCollection, Action<MemoryCacheOptions>)	
AddMetrics(IServiceCollection)	
AddMetrics(IServiceCollection, Action<IMetricsBuilder>)	
AddNullLatencyContext(IServiceCollection)	
AddPooled<TService>(IServiceCollection, Action<DependencyInjectionPoolOptions>)	
AddPooled<TService,TImplementation>(IServiceCollection, Action<DependencyInjectionPoolOptions>)	
ConfigurePool<TService>(IServiceCollection, Action<DependencyInjectionPoolOptions>)	
ConfigurePools(IServiceCollection, IConfigurationSection)	
Configure<TOptions>(IServiceCollection, IConfiguration)	
Configure<TOptions>(IServiceCollection, IConfiguration, Action<BinderOptions>)	
Configure<TOptions>(IServiceCollection, String, IConfiguration)	
Configure<TOptions>(IServiceCollection, String, IConfiguration, Action<BinderOptions>)	
AddOptions(IServiceCollection)	
AddOptions<TOptions>(IServiceCollection)	
AddOptions<TOptions>(IServiceCollection, String)	
AddOptionsWithValidateOnStart<TOptions>(IServiceCollection, String)	
AddOptionsWithValidateOnStart<TOptions,TValidateOptions>(IServiceCollection, String)	
Configure<TOptions>(IServiceCollection, Action<TOptions>)	
Configure<TOptions>(IServiceCollection, String, Action<TOptions>)	
ConfigureAll<TOptions>(IServiceCollection, Action<TOptions>)	
ConfigureOptions(IServiceCollection, Object)	
ConfigureOptions(IServiceCollection, Type)	
ConfigureOptions<TConfigureOptions>(IServiceCollection)	
PostConfigure<TOptions>(IServiceCollection, Action<TOptions>)	
PostConfigure<TOptions>(IServiceCollection, String, Action<TOptions>)	
PostConfigureAll<TOptions>(IServiceCollection, Action<TOptions>)	
AddProcessLogEnricher(IServiceCollection)	
AddProcessLogEnricher(IServiceCollection, IConfigurationSection)	
AddProcessLogEnricher(IServiceCollection, Action<ProcessLogEnricherOptions>)	
AddRedaction(IServiceCollection)	
IServiceCollectionに IRedactorProvider の実装を登録します。

AddRedaction(IServiceCollection, Action<IRedactionBuilder>)	
IServiceCollection に IRedactorProvider の実装を登録し、使用可能な編集機能を構成します。

AddResilienceEnricher(IServiceCollection)	
回復性エンリッチャーを追加します。

AddResourceMonitoring(IServiceCollection)	
IResourceMonitor 実装を構成し、サービス コレクションに追加します。

AddResourceMonitoring(IServiceCollection, Action<IResourceMonitorBuilder>)	
IResourceMonitor 実装を構成し、サービス コレクションに追加します。

BuildServiceProvider(IServiceCollection)	
指定された IServiceCollectionからサービスを含む ServiceProvider を作成します。

BuildServiceProvider(IServiceCollection, ServiceProviderOptions)	
指定された IServiceCollection からサービスを含む ServiceProvider を作成し、必要に応じてサービスの作成とスコープの検証を有効にします。

BuildServiceProvider(IServiceCollection, Boolean)	
指定した IServiceCollection からサービスを含む ServiceProvider を作成し、必要に応じてスコープの検証を有効にします。

AddHostedService<THostedService>(IServiceCollection)	
指定した型の IHostedService 登録を追加します。

AddHostedService<THostedService>(IServiceCollection, Func<IServiceProvider,THostedService>)	
指定した型の IHostedService 登録を追加します。

AddKeyedScoped(IServiceCollection, Type, Object)	
指定した IServiceCollectionに、serviceType で指定された型のスコープサービスを追加します。

AddKeyedScoped(IServiceCollection, Type, Object, Func<IServiceProvider,Object,Object>)	
implementationFactory で指定されたファクトリを使用して、serviceType で指定された型のスコープサービスを、指定した IServiceCollectionに追加します。

AddKeyedScoped(IServiceCollection, Type, Object, Type)	
implementationType で指定された型の実装を使用して、serviceType で指定された型のスコープサービスを、指定した IServiceCollectionに追加します。

AddKeyedScoped<TService>(IServiceCollection, Object)	
指定した IServiceCollectionに、TService で指定された型のスコープサービスを追加します。

AddKeyedScoped<TService>(IServiceCollection, Object, Func<IServiceProvider,Object,TService>)	
implementationFactory で指定されたファクトリを使用して、TService で指定された型のスコープサービスを、指定した IServiceCollectionに追加します。

AddKeyedScoped<TService,TImplementation>(IServiceCollection, Object)	
TImplementation で指定された実装型を持つ TService で指定された型のスコープサービスを、指定した IServiceCollectionに追加します。

AddKeyedScoped<TService,TImplementation>(IServiceCollection, Object, Func<IServiceProvider,Object,TImplementation>)	
implementationFactory で指定されたファクトリを使用して、TImplementation で指定された実装型を持つ、TService で指定された型のスコープサービスを、指定した IServiceCollectionに追加します。

AddKeyedSingleton(IServiceCollection, Type, Object)	
serviceType で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddKeyedSingleton(IServiceCollection, Type, Object, Func<IServiceProvider,Object,Object>)	
implementationFactory で指定されたファクトリを使用して、serviceType で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddKeyedSingleton(IServiceCollection, Type, Object, Object)	
implementationInstance で指定されたインスタンスを持つ serviceType で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddKeyedSingleton(IServiceCollection, Type, Object, Type)	
implementationType で指定された型の実装を使用して、serviceType で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddKeyedSingleton<TService>(IServiceCollection, Object)	
TService で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddKeyedSingleton<TService>(IServiceCollection, Object, TService)	
implementationInstance で指定されたインスタンスを持つ TService で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddKeyedSingleton<TService>(IServiceCollection, Object, Func<IServiceProvider,Object,TService>)	
implementationFactory で指定されたファクトリを使用して、TService で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddKeyedSingleton<TService,TImplementation>(IServiceCollection, Object)	
TImplementation で指定された実装型を持つ TService で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddKeyedSingleton<TService,TImplementation>(IServiceCollection, Object, Func<IServiceProvider,Object,TImplementation>)	
implementationFactory で指定されたファクトリを使用して、TImplementation で指定された実装型を持つ、TService で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddKeyedTransient(IServiceCollection, Type, Object)	
指定した IServiceCollectionに、serviceType で指定された型の一時的なサービスを追加します。

AddKeyedTransient(IServiceCollection, Type, Object, Func<IServiceProvider,Object,Object>)	
implementationFactory で指定されたファクトリを使用して、serviceType で指定された型の一時的なサービスを、指定した IServiceCollectionに追加します。

AddKeyedTransient(IServiceCollection, Type, Object, Type)	
implementationType で指定された型の実装を使用して、serviceType で指定された型の一時的なサービスを、指定した IServiceCollectionに追加します。

AddKeyedTransient<TService>(IServiceCollection, Object)	
指定した IServiceCollectionに、TService で指定された型の一時的なサービスを追加します。

AddKeyedTransient<TService>(IServiceCollection, Object, Func<IServiceProvider,Object,TService>)	
implementationFactory で指定されたファクトリを使用して、TService で指定された型の一時的なサービスを、指定した IServiceCollectionに追加します。

AddKeyedTransient<TService,TImplementation>(IServiceCollection, Object)	
TImplementation で指定された実装型を持つ TService で指定された型の一時的なサービスを、指定した IServiceCollectionに追加します。

AddKeyedTransient<TService,TImplementation>(IServiceCollection, Object, Func<IServiceProvider,Object,TImplementation>)	
implementationFactory で指定されたファクトリを使用して、TImplementation で指定された実装型を持つ TService で指定された型の一時的なサービスを、指定した IServiceCollectionに追加します。

AddScoped(IServiceCollection, Type)	
指定した IServiceCollectionに、serviceType で指定された型のスコープサービスを追加します。

AddScoped(IServiceCollection, Type, Func<IServiceProvider,Object>)	
implementationFactory で指定されたファクトリを使用して、serviceType で指定された型のスコープサービスを、指定した IServiceCollectionに追加します。

AddScoped(IServiceCollection, Type, Type)	
implementationType で指定された型の実装を使用して、serviceType で指定された型のスコープサービスを、指定した IServiceCollectionに追加します。

AddScoped<TService>(IServiceCollection)	
指定した IServiceCollectionに、TService で指定された型のスコープサービスを追加します。

AddScoped<TService>(IServiceCollection, Func<IServiceProvider,TService>)	
implementationFactory で指定されたファクトリを使用して、TService で指定された型のスコープサービスを、指定した IServiceCollectionに追加します。

AddScoped<TService,TImplementation>(IServiceCollection)	
AddScoped<TService,TImplementation>(IServiceCollection, Func<IServiceProvider,TImplementation>)	
AddSingleton(IServiceCollection, Type)	
AddSingleton(IServiceCollection, Type, Func<IServiceProvider,Object>)	
AddSingleton(IServiceCollection, Type, Object)	
AddSingleton(IServiceCollection, Type, Type)	
AddSingleton<TService>(IServiceCollection)	
AddSingleton<TService>(IServiceCollection, TService)	
AddSingleton<TService>(IServiceCollection, Func<IServiceProvider,TService>)	
AddSingleton<TService,TImplementation>(IServiceCollection)	
AddSingleton<TService,TImplementation>(IServiceCollection, Func<IServiceProvider,TImplementation>)	
AddTransient(IServiceCollection, Type)	
AddTransient(IServiceCollection, Type, Func<IServiceProvider,Object>)	
AddTransient(IServiceCollection, Type, Type)	
AddTransient<TService>(IServiceCollection)	
AddTransient<TService>(IServiceCollection, Func<IServiceProvider,TService>)	
AddTransient<TService,TImplementation>(IServiceCollection)	
AddTransient<TService,TImplementation>(IServiceCollection, Func<IServiceProvider,TImplementation>)	
AddDistributedSqlServerCache(IServiceCollection, Action<SqlServerCacheOptions>)	
AddStackExchangeRedisCache(IServiceCollection, Action<RedisCacheOptions>)	
AddTcpEndpointProbe(IServiceCollection)	
AddTcpEndpointProbe(IServiceCollection, IConfigurationSection)	
AddTcpEndpointProbe(IServiceCollection, Action<TcpEndpointProbesOptions>)	
AddTcpEndpointProbe(IServiceCollection, String)	
AddTcpEndpointProbe(IServiceCollection, String, IConfigurationSection)	
AddTcpEndpointProbe(IServiceCollection, String, Action<TcpEndpointProbesOptions>)	
AddSystemd(IServiceCollection)	
AddWindowsService(IServiceCollection)	
AddWindowsService(IServiceCollection, Action<WindowsServiceLifetimeOptions>)	
*/

#endregion