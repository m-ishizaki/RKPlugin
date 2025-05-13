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
IServiceCollection�� IRedactorProvider �̎�����o�^���܂��B

AddRedaction(IServiceCollection, Action<IRedactionBuilder>)	
IServiceCollection �� IRedactorProvider �̎�����o�^���A�g�p�\�ȕҏW�@�\���\�����܂��B

AddResilienceEnricher(IServiceCollection)	
�񕜐��G�����b�`���[��ǉ����܂��B

AddResourceMonitoring(IServiceCollection)	
IResourceMonitor �������\�����A�T�[�r�X �R���N�V�����ɒǉ����܂��B

AddResourceMonitoring(IServiceCollection, Action<IResourceMonitorBuilder>)	
IResourceMonitor �������\�����A�T�[�r�X �R���N�V�����ɒǉ����܂��B

BuildServiceProvider(IServiceCollection)	
�w�肳�ꂽ IServiceCollection����T�[�r�X���܂� ServiceProvider ���쐬���܂��B

BuildServiceProvider(IServiceCollection, ServiceProviderOptions)	
�w�肳�ꂽ IServiceCollection ����T�[�r�X���܂� ServiceProvider ���쐬���A�K�v�ɉ����ăT�[�r�X�̍쐬�ƃX�R�[�v�̌��؂�L���ɂ��܂��B

BuildServiceProvider(IServiceCollection, Boolean)	
�w�肵�� IServiceCollection ����T�[�r�X���܂� ServiceProvider ���쐬���A�K�v�ɉ����ăX�R�[�v�̌��؂�L���ɂ��܂��B

AddHostedService<THostedService>(IServiceCollection)	
�w�肵���^�� IHostedService �o�^��ǉ����܂��B

AddHostedService<THostedService>(IServiceCollection, Func<IServiceProvider,THostedService>)	
�w�肵���^�� IHostedService �o�^��ǉ����܂��B

AddKeyedScoped(IServiceCollection, Type, Object)	
�w�肵�� IServiceCollection�ɁAserviceType �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X��ǉ����܂��B

AddKeyedScoped(IServiceCollection, Type, Object, Func<IServiceProvider,Object,Object>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedScoped(IServiceCollection, Type, Object, Type)	
implementationType �Ŏw�肳�ꂽ�^�̎������g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedScoped<TService>(IServiceCollection, Object)	
�w�肵�� IServiceCollection�ɁATService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X��ǉ����܂��B

AddKeyedScoped<TService>(IServiceCollection, Object, Func<IServiceProvider,Object,TService>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedScoped<TService,TImplementation>(IServiceCollection, Object)	
TImplementation �Ŏw�肳�ꂽ�����^������ TService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedScoped<TService,TImplementation>(IServiceCollection, Object, Func<IServiceProvider,Object,TImplementation>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATImplementation �Ŏw�肳�ꂽ�����^�����ATService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton(IServiceCollection, Type, Object)	
serviceType �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton(IServiceCollection, Type, Object, Func<IServiceProvider,Object,Object>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton(IServiceCollection, Type, Object, Object)	
implementationInstance �Ŏw�肳�ꂽ�C���X�^���X������ serviceType �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton(IServiceCollection, Type, Object, Type)	
implementationType �Ŏw�肳�ꂽ�^�̎������g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton<TService>(IServiceCollection, Object)	
TService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton<TService>(IServiceCollection, Object, TService)	
implementationInstance �Ŏw�肳�ꂽ�C���X�^���X������ TService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton<TService>(IServiceCollection, Object, Func<IServiceProvider,Object,TService>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton<TService,TImplementation>(IServiceCollection, Object)	
TImplementation �Ŏw�肳�ꂽ�����^������ TService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton<TService,TImplementation>(IServiceCollection, Object, Func<IServiceProvider,Object,TImplementation>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATImplementation �Ŏw�肳�ꂽ�����^�����ATService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedTransient(IServiceCollection, Type, Object)	
�w�肵�� IServiceCollection�ɁAserviceType �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X��ǉ����܂��B

AddKeyedTransient(IServiceCollection, Type, Object, Func<IServiceProvider,Object,Object>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āAserviceType �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedTransient(IServiceCollection, Type, Object, Type)	
implementationType �Ŏw�肳�ꂽ�^�̎������g�p���āAserviceType �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedTransient<TService>(IServiceCollection, Object)	
�w�肵�� IServiceCollection�ɁATService �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X��ǉ����܂��B

AddKeyedTransient<TService>(IServiceCollection, Object, Func<IServiceProvider,Object,TService>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATService �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedTransient<TService,TImplementation>(IServiceCollection, Object)	
TImplementation �Ŏw�肳�ꂽ�����^������ TService �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedTransient<TService,TImplementation>(IServiceCollection, Object, Func<IServiceProvider,Object,TImplementation>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATImplementation �Ŏw�肳�ꂽ�����^������ TService �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddScoped(IServiceCollection, Type)	
�w�肵�� IServiceCollection�ɁAserviceType �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X��ǉ����܂��B

AddScoped(IServiceCollection, Type, Func<IServiceProvider,Object>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddScoped(IServiceCollection, Type, Type)	
implementationType �Ŏw�肳�ꂽ�^�̎������g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddScoped<TService>(IServiceCollection)	
�w�肵�� IServiceCollection�ɁATService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X��ǉ����܂��B

AddScoped<TService>(IServiceCollection, Func<IServiceProvider,TService>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

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