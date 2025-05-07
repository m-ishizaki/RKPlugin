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
AddServiceLogEnricher(IServiceCollection)
サービス エンリッチャーのインスタンスを IServiceCollectionに追加します。

AddServiceLogEnricher(IServiceCollection, IConfigurationSection)	
サービス エンリッチャーのインスタンスを IServiceCollectionに追加します。

AddServiceLogEnricher(IServiceCollection, Action<ApplicationLogEnricherOptions>)	
サービス エンリッチャーのインスタンスを IServiceCollectionに追加します。

AddApplicationMetadata(IServiceCollection, IConfigurationSection)	
依存関係挿入コンテナーに ApplicationMetadata のインスタンスを追加します。

AddApplicationMetadata(IServiceCollection, Action<ApplicationMetadata>)	
依存関係挿入コンテナーに ApplicationMetadata のインスタンスを追加します。

AddAsyncState(IServiceCollection)	
IAsyncState、IAsyncContext<T>、および Microsoft.Extensions.AsyncState.IAsyncLocalContext`1 サービスの既定の実装を追加します。 これらのインターフェイスの実装はスレッド セーフではないことに注意してください。

ActivateKeyedSingleton(IServiceCollection, Type, Object)	
実行時ではなく、起動時にキー付きシングルトンのアクティブ化を適用します。

ActivateKeyedSingleton<TService>(IServiceCollection, Object)	
実行時ではなく、起動時にキー付きシングルトンのアクティブ化を適用します。

ActivateSingleton(IServiceCollection, Type)	
実行時ではなく、起動時にシングルトンアクティブ化を適用します。

ActivateSingleton<TService>(IServiceCollection)	
実行時ではなく、起動時にシングルトンアクティブ化を適用します。

AddActivatedKeyedSingleton(IServiceCollection, Type, Object)	
自動アクティブ化キー付きシングルトン サービスを追加します。

AddActivatedKeyedSingleton(IServiceCollection, Type, Object, Func<IServiceProvider, Object, Object>)	
自動アクティブ化キー付きシングルトン サービスを追加します。

AddActivatedKeyedSingleton(IServiceCollection, Type, Object, Type)	
自動アクティブ化キー付きシングルトン サービスを追加します。

AddActivatedKeyedSingleton<TService>(IServiceCollection, Object)	
自動アクティブ化キー付きシングルトン サービスを追加します。

AddActivatedKeyedSingleton<TService>(IServiceCollection, Object, Func<IServiceProvider, Object, TService>)	
自動アクティブ化キー付きシングルトン サービスを追加します。

AddActivatedKeyedSingleton<TService, TImplementation>(IServiceCollection, Object)	
自動アクティブ化キー付きシングルトン サービスを追加します。

AddActivatedKeyedSingleton<TService, TImplementation>(IServiceCollection, Object, Func<IServiceProvider, Object, TImplementation>)	
自動アクティブ化キー付きシングルトン サービスを追加します。

AddActivatedSingleton(IServiceCollection, Type)	
serviceType で指定された型の自動アクティブ化シングルトン サービスを、指定した IServiceCollectionに追加します。

AddActivatedSingleton(IServiceCollection, Type, Func<IServiceProvider, Object>)	
自動アクティブ化されたシングルトン サービスを追加します。

AddActivatedSingleton(IServiceCollection, Type, Type)	
自動アクティブ化されたシングルトン サービスを追加します。

AddActivatedSingleton<TService>(IServiceCollection)	
自動アクティブ化されたシングルトン サービスを追加します。

AddActivatedSingleton<TService>(IServiceCollection, Func<IServiceProvider, TService>)	
自動アクティブ化されたシングルトン サービスを追加します。

AddActivatedSingleton<TService, TImplementation>(IServiceCollection)	
自動アクティブ化されたシングルトン サービスを追加します。

AddActivatedSingleton<TService, TImplementation>(IServiceCollection, Func<IServiceProvider, TImplementation>)	
自動アクティブ化されたシングルトン サービスを追加します。

TryAddActivatedKeyedSingleton(IServiceCollection, Type, Object)	
自動アクティブ化キー付きシングルトン サービスの追加を試みます。

TryAddActivatedKeyedSingleton(IServiceCollection, Type, Object, Func<IServiceProvider, Object, Object>)	
自動アクティブ化キー付きシングルトン サービスの追加を試みます。

TryAddActivatedKeyedSingleton(IServiceCollection, Type, Object, Type)	
自動アクティブ化キー付きシングルトン サービスの追加を試みます。

TryAddActivatedKeyedSingleton<TService>(IServiceCollection, Object)	
自動アクティブ化キー付きシングルトン サービスの追加を試みます。

TryAddActivatedKeyedSingleton<TService>(IServiceCollection, Object, Func<IServiceProvider, Object, TService>)	
自動アクティブ化キー付きシングルトン サービスの追加を試みます。

TryAddActivatedKeyedSingleton<TService, TImplementation>(IServiceCollection, Object)	
自動アクティブ化キー付きシングルトン サービスの追加を試みます。

TryAddActivatedSingleton(IServiceCollection, Type)	
自動アクティブ化シングルトン サービスの追加を試みます。

TryAddActivatedSingleton(IServiceCollection, Type, Func<IServiceProvider, Object>)	
自動アクティブ化シングルトン サービスの追加を試みます。

TryAddActivatedSingleton(IServiceCollection, Type, Type)	
自動アクティブ化シングルトン サービスの追加を試みます。

TryAddActivatedSingleton<TService>(IServiceCollection)	
自動アクティブ化シングルトン サービスの追加を試みます。

TryAddActivatedSingleton<TService>(IServiceCollection, Func<IServiceProvider, TService>)	
自動アクティブ化シングルトン サービスの追加を試みます。

TryAddActivatedSingleton<TService, TImplementation>(IServiceCollection)	
自動アクティブ化シングルトン サービスの追加を試みます。

AddTelemetryHealthCheckPublisher(IServiceCollection)	
アプリケーションの正常性を表すテレメトリを出力する正常性チェック発行元を登録します。

AddTelemetryHealthCheckPublisher(IServiceCollection, IConfigurationSection)	
アプリケーションの正常性を表すテレメトリを出力する正常性チェック発行元を登録します。

AddTelemetryHealthCheckPublisher(IServiceCollection, Action<TelemetryHealthCheckPublisherOptions>)	
アプリケーションの正常性を表すテレメトリを出力する正常性チェック発行元を登録します。

AddContextualOptions(IServiceCollection)	
コンテキスト オプションを使用するために必要なサービスを追加します。

Configure<TOptions>(IServiceCollection, Action<IOptionsContext, TOptions>)	
特定の種類のオプションを構成するために使用するアクションを登録します。

Configure<TOptions>(IServiceCollection, Func<IOptionsContext, CancellationToken, ValueTask<IConfigureContextualOptions<TOptions>>>)	
特定の種類のオプションを構成するために使用するアクションを登録します。

Configure<TOptions>(IServiceCollection, String, Action<IOptionsContext, TOptions>)	
特定の種類のオプションを構成するために使用するアクションを登録します。

Configure<TOptions>(IServiceCollection, String, Func<IOptionsContext, CancellationToken, ValueTask<IConfigureContextualOptions<TOptions>>>)	
特定の種類のオプションを構成するために使用するアクションを登録します。

ConfigureAll<TOptions>(IServiceCollection, Action<IOptionsContext, TOptions>)	
特定の種類のオプションのすべてのインスタンスを構成するために使用するアクションを登録します。

ConfigureAll<TOptions>(IServiceCollection, Func<IOptionsContext, CancellationToken, ValueTask<IConfigureContextualOptions<TOptions>>>)	
特定の種類のオプションのすべてのインスタンスを構成するために使用するアクションを登録します。

AddWebEncoders(IServiceCollection)	
指定した servicesに HtmlEncoder、JavaScriptEncoder、および UrlEncoder を追加します。

AddWebEncoders(IServiceCollection, Action<WebEncoderOptions>)	
指定した servicesに HtmlEncoder、JavaScriptEncoder、および UrlEncoder を追加します。

AddLogEnricher(IServiceCollection, ILogEnricher)	
ログ エンリッチャー インスタンスを登録します。

AddLogEnricher<T>(IServiceCollection)	
ログ エンリッチャーの種類を登録します。

AddStaticLogEnricher(IServiceCollection, IStaticLogEnricher)	
静的ログ エンリッチャー インスタンスを登録します。

AddStaticLogEnricher<T>(IServiceCollection)	
静的ログ エンリッチャーの種類を登録します。

AddExceptionSummarizer(IServiceCollection)	
例外サマライザーを依存関係挿入コンテナーに登録します。

AddExceptionSummarizer(IServiceCollection, Action<IExceptionSummarizationBuilder>)	
例外サマライザーを依存関係挿入コンテナーに登録します。

Add(IServiceCollection, ServiceDescriptor)	
指定した descriptor を collectionに追加します。

Add(IServiceCollection, IEnumerable<ServiceDescriptor>)	
collectionに一連の ServiceDescriptor を追加します。

RemoveAll(IServiceCollection, Type)	
IServiceCollectionで serviceType 型のすべてのサービスを削除します。

RemoveAll<T>(IServiceCollection)	
IServiceCollectionで T 型のすべてのサービスを削除します。

RemoveAllKeyed(IServiceCollection, Type, Object)	
collectionで serviceType 型のすべてのサービスを削除します。

RemoveAllKeyed<T>(IServiceCollection, Object)	
collectionで T 型のすべてのサービスを削除します。

Replace(IServiceCollection, ServiceDescriptor)	
descriptor と同じサービスの種類を持つ IServiceCollection の最初のサービスを削除し、コレクションに descriptor を追加します。

TryAdd(IServiceCollection, ServiceDescriptor)	
サービスの種類がまだ登録されていない場合は、指定した descriptor を collection に追加します。

TryAdd(IServiceCollection, IEnumerable<ServiceDescriptor>)	
サービスの種類がまだ登録されていない場合は、指定した descriptors を collection に追加します。

TryAddEnumerable(IServiceCollection, ServiceDescriptor)	
同じ ServiceType を持つ既存の記述子と、servicesにまだ存在しない実装がある場合は、ServiceDescriptor を追加します。

TryAddEnumerable(IServiceCollection, IEnumerable<ServiceDescriptor>)	
同じ ServiceType を持つ既存の記述子と、servicesにまだ存在しない実装がある場合は、指定した ServiceDescriptorを追加します。

TryAddKeyedScoped(IServiceCollection, Type, Object)	
指定した service を Scoped サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddKeyedScoped(IServiceCollection, Type, Object, Func<IServiceProvider, Object, Object>)	
サービスの種類がまだ登録されていない場合は、implementationFactory で指定されたファクトリを使用して、指定した service を Scoped サービスとして collection に追加します。

TryAddKeyedScoped(IServiceCollection, Type, Object, Type)	
サービスの種類がまだ登録されていない場合は、指定した service を Scoped サービスとして implementationType 実装を collection に追加します。

TryAddKeyedScoped<TService>(IServiceCollection, Object)	
指定した TService を Scoped サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddKeyedScoped<TService>(IServiceCollection, Object, Func<IServiceProvider, Object, TService>)	
サービスの種類がまだ登録されていない場合は、implementationFactory で指定されたファクトリを使用して、指定した TService を Scoped サービスとして services に追加します。

TryAddKeyedScoped<TService, TImplementation>(IServiceCollection, Object)	
サービスの種類がまだ登録されていない場合は、TImplementation で指定された Scoped サービス実装型として指定した TService を collection に追加します。

TryAddKeyedSingleton(IServiceCollection, Type, Object)	
指定した service を Singleton サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddKeyedSingleton(IServiceCollection, Type, Object, Func<IServiceProvider, Object, Object>)	
サービスの種類がまだ登録されていない場合は、implementationFactory で指定されたファクトリを使用して、指定した service を Singleton サービスとして collection に追加します。

TryAddKeyedSingleton(IServiceCollection, Type, Object, Type)	
サービスの種類がまだ登録されていない場合は、指定した service を Singleton サービスとして implementationType 実装を collection に追加します。

TryAddKeyedSingleton<TService>(IServiceCollection, Object)	
指定した TService を Singleton サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddKeyedSingleton<TService>(IServiceCollection, Object, TService)	
指定した TService を、instance で指定されたインスタンスを持つ Singleton サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddKeyedSingleton<TService>(IServiceCollection, Object, Func<IServiceProvider, Object, TService>)	
サービスの種類がまだ登録されていない場合は、implementationFactory で指定されたファクトリを使用して、指定した TService を Singleton サービスとして services に追加します。

TryAddKeyedSingleton<TService, TImplementation>(IServiceCollection, Object)	
サービスの種類がまだ登録されていない場合は、TImplementation で指定された Singleton サービス実装型として指定した TService を collection に追加します。

TryAddKeyedTransient(IServiceCollection, Type, Object)	
指定した service を Transient サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddKeyedTransient(IServiceCollection, Type, Object, Func<IServiceProvider, Object, Object>)	
サービスの種類がまだ登録されていない場合は、implementationFactory で指定されたファクトリを使用して、指定した service を Transient サービスとして collection に追加します。

TryAddKeyedTransient(IServiceCollection, Type, Object, Type)	
サービスの種類がまだ登録されていない場合は、指定した service を Transient サービスとして implementationType 実装を collection に追加します。

TryAddKeyedTransient<TService>(IServiceCollection, Object)	
指定した TService を Transient サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddKeyedTransient<TService>(IServiceCollection, Object, Func<IServiceProvider, Object, TService>)	
サービスの種類がまだ登録されていない場合は、implementationFactory で指定されたファクトリを使用して、指定した TService を Transient サービスとして services に追加します。

TryAddKeyedTransient<TService, TImplementation>(IServiceCollection, Object)	
サービスの種類がまだ登録されていない場合は、TImplementation で指定された Transient サービス実装型として指定した TService を collection に追加します。

TryAddScoped(IServiceCollection, Type)	
指定した service を Scoped サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddScoped(IServiceCollection, Type, Func<IServiceProvider, Object>)	
サービスの種類がまだ登録されていない場合は、implementationFactory で指定されたファクトリを使用して、指定した service を Scoped サービスとして collection に追加します。

TryAddScoped(IServiceCollection, Type, Type)	
サービスの種類がまだ登録されていない場合は、指定した service を Scoped サービスとして implementationType 実装を collection に追加します。

TryAddScoped<TService>(IServiceCollection)	
指定した TService を Scoped サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddScoped<TService>(IServiceCollection, Func<IServiceProvider, TService>)	
サービスの種類がまだ登録されていない場合は、implementationFactory で指定されたファクトリを使用して、指定した TService を Scoped サービスとして services に追加します。

TryAddScoped<TService, TImplementation>(IServiceCollection)	
サービスの種類がまだ登録されていない場合は、TImplementation で指定された Scoped サービス実装型として指定した TService を collection に追加します。

TryAddSingleton(IServiceCollection, Type)	
指定した service を Singleton サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddSingleton(IServiceCollection, Type, Func<IServiceProvider, Object>)	
サービスの種類がまだ登録されていない場合は、implementationFactory で指定されたファクトリを使用して、指定した service を Singleton サービスとして collection に追加します。

TryAddSingleton(IServiceCollection, Type, Type)	
サービスの種類がまだ登録されていない場合は、指定した service を Singleton サービスとして implementationType 実装を collection に追加します。

TryAddSingleton<TService>(IServiceCollection)	
指定した TService を Singleton サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddSingleton<TService>(IServiceCollection, TService)	
指定した TService を、instance で指定されたインスタンスを持つ Singleton サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddSingleton<TService>(IServiceCollection, Func<IServiceProvider, TService>)	
サービスの種類がまだ登録されていない場合は、implementationFactory で指定されたファクトリを使用して、指定した TService を Singleton サービスとして services に追加します。

TryAddSingleton<TService, TImplementation>(IServiceCollection)	
サービスの種類がまだ登録されていない場合は、TImplementation で指定された Singleton サービス実装型として指定した TService を collection に追加します。

TryAddTransient(IServiceCollection, Type)	
指定した service を Transient サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddTransient(IServiceCollection, Type, Func<IServiceProvider, Object>)	
サービスの種類がまだ登録されていない場合は、implementationFactory で指定されたファクトリを使用して、指定した service を Transient サービスとして collection に追加します。

TryAddTransient(IServiceCollection, Type, Type)	
サービスの種類がまだ登録されていない場合は、指定した service を Transient サービスとして implementationType 実装を collection に追加します。

TryAddTransient<TService>(IServiceCollection)	
指定した TService を Transient サービスとして collection に追加します (サービスの種類がまだ登録されていない場合)。

TryAddTransient<TService>(IServiceCollection, Func<IServiceProvider, TService>)	
サービスの種類がまだ登録されていない場合は、implementationFactory で指定されたファクトリを使用して、指定した TService を Transient サービスとして services に追加します。

TryAddTransient<TService, TImplementation>(IServiceCollection)	
サービスの種類がまだ登録されていない場合は、TImplementation で指定された Transient サービス実装型として指定した TService を collection に追加します。

AddFakeLogging(IServiceCollection)	
既定のオプションを使用して偽のログ記録を構成します。

AddFakeLogging(IServiceCollection, IConfigurationSection)	
偽のログ記録を構成します。

AddFakeLogging(IServiceCollection, Action<FakeLogCollectorOptions>)	
偽のログ記録を構成します。

AddFakeRedaction(IServiceCollection)	
常に偽の redactor インスタンスを返す偽のリダクター プロバイダーを登録します。

AddFakeRedaction(IServiceCollection, Action<FakeRedactorOptions>)	
常に偽の redactor インスタンスを返す偽のリダクター プロバイダーを登録します。

AddHealthChecks(IServiceCollection)	
指定されたデリゲートを使用して正常性チェックを登録して、HealthCheckService をコンテナーに追加します。

AddHttpClient(IServiceCollection)	
IHttpClientFactory および関連するサービスを IServiceCollectionに追加します。

AddHttpClient(IServiceCollection, String)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、名前付き HttpClientを構成します。

AddHttpClient(IServiceCollection, String, Action<IServiceProvider, HttpClient>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、名前付き HttpClientを構成します。

AddHttpClient(IServiceCollection, String, Action<HttpClient>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、名前付き HttpClientを構成します。

AddHttpClient<TClient>(IServiceCollection)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。 クライアント名は、TClientの完全な名前に設定されます。

AddHttpClient<TClient>(IServiceCollection, Action<IServiceProvider, HttpClient>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。 クライアント名は、TClientの型名に設定されます。

AddHttpClient<TClient>(IServiceCollection, Action<HttpClient>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。 クライアント名は、TClientの型名に設定されます。

AddHttpClient<TClient>(IServiceCollection, String)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。

AddHttpClient<TClient>(IServiceCollection, String, Action<IServiceProvider, HttpClient>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。

AddHttpClient<TClient>(IServiceCollection, String, Action<HttpClient>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。

AddHttpClient<TClient, TImplementation>(IServiceCollection)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。 クライアント名は、TClientの型名に設定されます。

AddHttpClient<TClient, TImplementation>(IServiceCollection, Action<IServiceProvider, HttpClient>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。 クライアント名は、TClientの型名に設定されます。

AddHttpClient<TClient, TImplementation>(IServiceCollection, Action<HttpClient>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。 クライアント名は、TClientの型名に設定されます。

AddHttpClient<TClient,TImplementation>(IServiceCollection, Func<HttpClient,TImplementation>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。

AddHttpClient<TClient,TImplementation>(IServiceCollection, Func<HttpClient,IServiceProvider,TImplementation>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。

AddHttpClient<TClient,TImplementation>(IServiceCollection, String)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。 クライアント名は、TClientの型名に設定されます。

AddHttpClient<TClient,TImplementation>(IServiceCollection, String, Action<IServiceProvider,HttpClient>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。

AddHttpClient<TClient,TImplementation>(IServiceCollection, String, Action<HttpClient>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。

AddHttpClient<TClient,TImplementation>(IServiceCollection, String, Func<HttpClient,TImplementation>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。

AddHttpClient<TClient,TImplementation>(IServiceCollection, String, Func<HttpClient,IServiceProvider,TImplementation>)	
IHttpClientFactory および関連サービスを IServiceCollection に追加し、TClient 型と名前付き HttpClientの間のバインディングを構成します。

ConfigureHttpClientDefaults(IServiceCollection, Action<IHttpClientBuilder>)	
すべての HttpClient インスタンスの構成に使用されるデリゲートを追加します。

AddHttpClientLatencyTelemetry(IServiceCollection)	
待機時間情報を収集し、すべての http クライアントの送信要求ログを強化するための DelegatingHandler を追加します。

AddHttpClientLatencyTelemetry(IServiceCollection, IConfigurationSection)	
待機時間情報を収集し、すべての http クライアントの送信要求ログを強化するための DelegatingHandler を追加します。

AddHttpClientLatencyTelemetry(IServiceCollection, Action<HttpClientLatencyTelemetryOptions>)	
待機時間情報を収集し、すべての http クライアントの送信要求ログを強化するための DelegatingHandler を追加します。

AddExtendedHttpClientLogging(IServiceCollection)	
IHttpClientFactoryで作成されたすべての HTTP クライアントの送信要求のログを出力する IHttpClientAsyncLogger を追加します。

AddExtendedHttpClientLogging(IServiceCollection, IConfigurationSection)	
IHttpClientFactoryで作成されたすべての HTTP クライアントの送信要求のログを出力する IHttpClientAsyncLogger を追加します。

AddExtendedHttpClientLogging(IServiceCollection, Action<LoggingOptions>)	
IHttpClientFactoryで作成されたすべての HTTP クライアントの送信要求のログを出力する IHttpClientAsyncLogger を追加します。

AddHttpClientLogEnricher<T>(IServiceCollection)	
T のエンリッチャー インスタンスを IServiceCollection に追加して、HttpClient ログをエンリッチします。

AddDownstreamDependencyMetadata(IServiceCollection, IDownstreamDependencyMetadata)	
依存関係メタデータを追加します。

AddDownstreamDependencyMetadata<T>(IServiceCollection)	
依存関係メタデータを追加します。

AddHybridCache(IServiceCollection)	
サービス記述子のコレクションのコントラクトを指定します。

AddHybridCache(IServiceCollection, Action<HybridCacheOptions>)	
サービス記述子のコレクションのコントラクトを指定します。

AddKubernetesProbes(IServiceCollection)	
既定のオプションを使用して、liveness、startup、および readiness プローブを登録します。

AddKubernetesProbes(IServiceCollection, IConfigurationSection)	
構成されたオプションを使用して、liveness、startup、および readiness プローブを登録します。

AddKubernetesProbes(IServiceCollection, Action<KubernetesProbesOptions>)	
構成されたオプションを使用して、liveness、startup、および readiness プローブを登録します。

AddConsoleLatencyDataExporter(IServiceCollection)	
コンソールの待機時間データ エクスポーターを追加します。

AddConsoleLatencyDataExporter(IServiceCollection, IConfigurationSection)	
コンソールの待機時間データ エクスポーターを追加します。

AddConsoleLatencyDataExporter(IServiceCollection, Action<LatencyConsoleOptions>)	
コンソールの待機時間データ エクスポーターを追加します。

AddLatencyContext(IServiceCollection)	
待機時間コンテキストを追加します。

AddLatencyContext(IServiceCollection, IConfigurationSection)	
待機時間コンテキストを追加します。

AddLatencyContext(IServiceCollection, Action<LatencyContextOptions>)	
待機時間コンテキストを追加します。

RegisterCheckpointNames(IServiceCollection, String[])	
待機時間コンテキストのチェックポイント名のセットを登録します。

RegisterMeasureNames(IServiceCollection, String[])	
待機時間コンテキストのメジャー名のセットを登録します。

RegisterTagNames(IServiceCollection, String[])	
待機時間コンテキストのタグ名のセットを登録します。

AddLocalization(IServiceCollection)	
アプリケーションのローカライズに必要なサービスを追加します。

AddLocalization(IServiceCollection, Action<LocalizationOptions>)	
アプリケーションのローカライズに必要なサービスを追加します。

AddLogging(IServiceCollection)	
指定した IServiceCollectionにログ サービスを追加します。

AddLogging(IServiceCollection, Action<ILoggingBuilder>)	
指定した IServiceCollectionにログ サービスを追加します。

AddDistributedMemoryCache(IServiceCollection)	
メモリに項目を格納する IDistributedCache の既定の実装を IServiceCollectionに追加します。 分散キャッシュを機能させる必要があるフレームワークでは、依存関係リストの一部としてこの依存関係を安全に追加して、少なくとも 1 つの実装が使用可能であることを確認できます。

AddDistributedMemoryCache(IServiceCollection, Action<MemoryDistributedCacheOptions>)	
メモリに項目を格納する IDistributedCache の既定の実装を IServiceCollectionに追加します。 分散キャッシュを機能させる必要があるフレームワークでは、依存関係リストの一部としてこの依存関係を安全に追加して、少なくとも 1 つの実装が使用可能であることを確認できます。

AddMemoryCache(IServiceCollection)	
IMemoryCache の非分散メモリ実装を IServiceCollectionに追加します。

AddMemoryCache(IServiceCollection, Action<MemoryCacheOptions>)	
IMemoryCache の非分散メモリ実装を IServiceCollectionに追加します。

AddMetrics(IServiceCollection)	
指定した IServiceCollectionにメトリック サービスを追加します。

AddMetrics(IServiceCollection, Action<IMetricsBuilder>)	
指定した IServiceCollectionにメトリック サービスを追加します。

AddNullLatencyContext(IServiceCollection)	
依存関係挿入コンテナーに no-op 待機時間コンテキストを追加します。

AddPooled<TService>(IServiceCollection, Action<DependencyInjectionPoolOptions>)	
ObjectPool<T> を追加し、DI が TServiceのスコープ付きインスタンスを返すことができます。

AddPooled<TService,TImplementation>(IServiceCollection, Action<DependencyInjectionPoolOptions>)	
ObjectPool<T> を追加し、DI が TServiceのスコープ付きインスタンスを返すことができます。

ConfigurePool<TService>(IServiceCollection, Action<DependencyInjectionPoolOptions>)	
型指定されたプールの DependencyInjectionPoolOptions の構成に使用するアクションを登録します。

ConfigurePools(IServiceCollection, IConfigurationSection)	
DI プールを構成します。

Configure<TOptions>(IServiceCollection, IConfiguration)	
TOptions バインドする構成インスタンスを登録し、構成が変更されたときにオプションを更新します。

Configure<TOptions>(IServiceCollection, IConfiguration, Action<BinderOptions>)	
TOptions がバインドする構成インスタンスを登録します。

Configure<TOptions>(IServiceCollection, String, IConfiguration)	
TOptions がバインドする構成インスタンスを登録します。

Configure<TOptions>(IServiceCollection, String, IConfiguration, Action<BinderOptions>)	
TOptions がバインドする構成インスタンスを登録します。

AddOptions(IServiceCollection)	
オプションを使用するために必要なサービスを追加します。

AddOptions<TOptions>(IServiceCollection)	
同じ名前付き TOptions の Configure 呼び出しを基になるサービス コレクションに転送するオプション ビルダーを取得します。

AddOptions<TOptions>(IServiceCollection, String)	
同じ名前付き TOptions の Configure 呼び出しを基になるサービス コレクションに転送するオプション ビルダーを取得します。

AddOptionsWithValidateOnStart<TOptions>(IServiceCollection, String)	
オプションを使用するために必要なサービスを追加し、実行時ではなく起動時にオプション検証チェックを適用します。

AddOptionsWithValidateOnStart<TOptions,TValidateOptions>(IServiceCollection, String)	
オプションを使用するために必要なサービスを追加し、実行時ではなく起動時にオプション検証チェックを適用します。

Configure<TOptions>(IServiceCollection, Action<TOptions>)	
起動時に特定の種類のオプションを 1 回構成するために使用するアクションを登録します。 これは、PostConfigure<TOptions>(IServiceCollection, Action<TOptions>)する前に実行されます。 構成を更新しても、アクションは再度呼び出されません。

Configure<TOptions>(IServiceCollection, String, Action<TOptions>)	
特定の種類のオプションを構成するために使用するアクションを登録します。 これらは、PostConfigure<TOptions>(IServiceCollection, Action<TOptions>)する前に実行されます。

ConfigureAll<TOptions>(IServiceCollection, Action<TOptions>)	
特定の種類のオプションのすべてのインスタンスを構成するために使用するアクションを登録します。

ConfigureOptions(IServiceCollection, Object)	
すべての I[Post]ConfigureOptions が登録されるオブジェクトを登録します。

ConfigureOptions(IServiceCollection, Type)	
すべての I[Post]ConfigureOptions が登録される型を登録します。

ConfigureOptions<TConfigureOptions>(IServiceCollection)	
すべての I[Post]ConfigureOptions が登録される型を登録します。

PostConfigure<TOptions>(IServiceCollection, Action<TOptions>)	
特定の種類のオプションを初期化するために使用するアクションを登録します。 これらは Configure<TOptions>(IServiceCollection, Action<TOptions>)後に実行されます。

PostConfigure<TOptions>(IServiceCollection, String, Action<TOptions>)	
特定の種類のオプションを構成するために使用するアクションを登録します。 これらは Configure<TOptions>(IServiceCollection, Action<TOptions>)後に実行されます。

PostConfigureAll<TOptions>(IServiceCollection, Action<TOptions>)	
特定の種類のオプションのすべてのインスタンスを構成した後に使用するアクションを登録します。 これらは Configure<TOptions>(IServiceCollection, Action<TOptions>)後に実行されます。

AddProcessLogEnricher(IServiceCollection)	
プロセス エンリッチャーのインスタンスを IServiceCollectionに追加します。

AddProcessLogEnricher(IServiceCollection, IConfigurationSection)	
ホスト エンリッチャーのインスタンスを IServiceCollectionに追加します。

AddProcessLogEnricher(IServiceCollection, Action<ProcessLogEnricherOptions>)	
プロセス エンリッチャーのインスタンスを IServiceCollectionに追加します。

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
TImplementation で指定された実装型を持つ TService で指定された型のスコープサービスを、指定した IServiceCollectionに追加します。

AddScoped<TService,TImplementation>(IServiceCollection, Func<IServiceProvider,TImplementation>)	
implementationFactory で指定されたファクトリを使用して、TImplementation で指定された実装型を持つ、TService で指定された型のスコープサービスを、指定した IServiceCollectionに追加します。

AddSingleton(IServiceCollection, Type)	
serviceType で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddSingleton(IServiceCollection, Type, Func<IServiceProvider,Object>)	
implementationFactory で指定されたファクトリを使用して、serviceType で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddSingleton(IServiceCollection, Type, Object)	
implementationInstance で指定されたインスタンスを持つ serviceType で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddSingleton(IServiceCollection, Type, Type)	
implementationType で指定された型の実装を使用して、serviceType で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddSingleton<TService>(IServiceCollection)	
TService で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddSingleton<TService>(IServiceCollection, TService)	
implementationInstance で指定されたインスタンスを持つ TService で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddSingleton<TService>(IServiceCollection, Func<IServiceProvider,TService>)	
implementationFactory で指定されたファクトリを使用して、TService で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddSingleton<TService,TImplementation>(IServiceCollection)	
TImplementation で指定された実装型を持つ TService で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddSingleton<TService,TImplementation>(IServiceCollection, Func<IServiceProvider,TImplementation>)	
implementationFactory で指定されたファクトリを使用して、TImplementation で指定された実装型を持つ、TService で指定された型のシングルトン サービスを、指定した IServiceCollectionに追加します。

AddTransient(IServiceCollection, Type)	
指定した IServiceCollectionに、serviceType で指定された型の一時的なサービスを追加します。

AddTransient(IServiceCollection, Type, Func<IServiceProvider,Object>)	
implementationFactory で指定されたファクトリを使用して、serviceType で指定された型の一時的なサービスを、指定した IServiceCollectionに追加します。

AddTransient(IServiceCollection, Type, Type)	
implementationType で指定された型の実装を使用して、serviceType で指定された型の一時的なサービスを、指定した IServiceCollectionに追加します。

AddTransient<TService>(IServiceCollection)	
指定した IServiceCollectionに、TService で指定された型の一時的なサービスを追加します。

AddTransient<TService>(IServiceCollection, Func<IServiceProvider,TService>)	
implementationFactory で指定されたファクトリを使用して、TService で指定された型の一時的なサービスを、指定した IServiceCollectionに追加します。

AddTransient<TService,TImplementation>(IServiceCollection)	
TImplementation で指定された実装型を持つ TService で指定された型の一時的なサービスを、指定した IServiceCollectionに追加します。

AddTransient<TService,TImplementation>(IServiceCollection, Func<IServiceProvider,TImplementation>)	
implementationFactory で指定されたファクトリを使用して、TImplementation で指定された実装型を持つ TService で指定された型の一時的なサービスを、指定した IServiceCollectionに追加します。

AddDistributedSqlServerCache(IServiceCollection, Action<SqlServerCacheOptions>)	
指定した IServiceCollectionに Microsoft SQL Server 分散キャッシュ サービスを追加します。

AddStackExchangeRedisCache(IServiceCollection, Action<RedisCacheOptions>)	
指定した IServiceCollectionに Redis 分散キャッシュ サービスを追加します。

AddTcpEndpointProbe(IServiceCollection)	
サービスが正常な IHealthCheckと見なされる場合、TCP ポートを使用して正常性状態レポートを登録します。

AddTcpEndpointProbe(IServiceCollection, IConfigurationSection)	
サービスが正常な IHealthCheckと見なされる場合、TCP ポートを使用して正常性状態レポートを登録します。

AddTcpEndpointProbe(IServiceCollection, Action<TcpEndpointProbesOptions>)	
サービスが正常な IHealthCheckと見なされる場合、TCP ポートを使用して正常性状態レポートを登録します。

AddTcpEndpointProbe(IServiceCollection, String)	
サービスが正常な IHealthCheckと見なされる場合、TCP ポートを使用して正常性状態レポートを登録します。

AddTcpEndpointProbe(IServiceCollection, String, IConfigurationSection)	
サービスが正常な IHealthCheckと見なされる場合、TCP ポートを使用して正常性状態レポートを登録します。

AddTcpEndpointProbe(IServiceCollection, String, Action<TcpEndpointProbesOptions>)	
サービスが正常な IHealthCheckと見なされる場合、TCP ポートを使用して正常性状態レポートを登録します。

AddSystemd(IServiceCollection)	
services から SystemdLifetimeにビルドされた IHost の有効期間を構成し、アプリケーションの起動と停止の通知メッセージを提供し、システム形式にコンソール ログを構成します。

AddWindowsService(IServiceCollection)	
services から WindowsServiceLifetime にビルドされた IHost の有効期間を構成し、アプリケーション名を既定のソース名として使用してイベント ログにログを記録できるようにします。

AddWindowsService(IServiceCollection, Action<WindowsServiceLifetimeOptions>)	
services から WindowsServiceLifetime にビルドされた IHost の有効期間を構成し、アプリケーション名を既定のソース名として使用してイベント ログにログを記録できるようにします。

ToFrozenDictionary<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
指定したキー セレクター関数に従って、IEnumerable<T> から FrozenDictionary<TKey,TValue> を作成します。

ToFrozenDictionary<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>, IEqualityComparer<TKey>)	
指定したキー セレクターおよび要素セレクター関数に従って、IEnumerable<T> から FrozenDictionary<TKey,TValue> を作成します。

ToFrozenSet<T>(IEnumerable<T>, IEqualityComparer<T>)	
指定した値を使用して FrozenSet<T> を作成します。

AsReadOnly<T>(IList<T>)	
指定したリストの読み取り専用 ReadOnlyCollection<T> ラッパーを返します。

ToImmutableArray<TSource>(IEnumerable<TSource>)	
指定したコレクションから変更できない配列を作成します。

ToImmutableDictionary<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
変換関数をソース キーに適用して、要素の既存のコレクションから変更できないディクショナリを構築します。

ToImmutableDictionary<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
シーケンスの変換に基づいて、変更できないディクショナリを構築します。

ToImmutableDictionary<TSource,TKey,TValue>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TValue>)	
シーケンスを列挙して変換し、その内容の変更できないディクショナリを生成します。

ToImmutableDictionary<TSource,TKey,TValue>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TValue>, IEqualityComparer<TKey>)	
シーケンスを列挙して変換し、指定したキー比較子を使用してその内容の変更できないディクショナリを生成します。

ToImmutableDictionary<TSource,TKey,TValue>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TValue>, IEqualityComparer<TKey>, IEqualityComparer<TValue>)	
シーケンスを列挙して変換し、指定したキーと値の比較子を使用してその内容の変更できないディクショナリを生成します。

ToImmutableHashSet<TSource>(IEnumerable<TSource>)	
シーケンスを列挙し、その内容の変更できないハッシュ セットを生成します。

ToImmutableHashSet<TSource>(IEnumerable<TSource>, IEqualityComparer<TSource>)	
シーケンスを列挙し、その内容の変更できないハッシュ セットを生成し、セット型に対して指定された等値比較子を使用します。

ToImmutableList<TSource>(IEnumerable<TSource>)	
シーケンスを列挙し、その内容の変更できないリストを生成します。

ToImmutableSortedDictionary<TSource,TKey,TValue>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TValue>)	
シーケンスを列挙して変換し、その内容の変更できない並べ替えられたディクショナリを生成します。

ToImmutableSortedDictionary<TSource,TKey,TValue>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TValue>, IComparer<TKey>)	
シーケンスを列挙して変換し、指定したキー比較子を使用して、その内容の変更できない並べ替えられたディクショナリを生成します。

ToImmutableSortedDictionary<TSource,TKey,TValue>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TValue>, IComparer<TKey>, IEqualityComparer<TValue>)	
シーケンスを列挙して変換し、指定したキーと値の比較子を使用して、その内容の変更できない並べ替えられたディクショナリを生成します。

ToImmutableSortedSet<TSource>(IEnumerable<TSource>)	
シーケンスを列挙し、その内容の変更できない並べ替えられたセットを生成します。

ToImmutableSortedSet<TSource>(IEnumerable<TSource>, IComparer<TSource>)	
シーケンスを列挙し、その内容の変更できない並べ替えられたセットを生成し、指定された比較子を使用します。

CopyToDataTable<T>(IEnumerable<T>)	
ジェネリック パラメーター T が DataRowされている入力 IEnumerable<T> オブジェクトを指定して、DataRow オブジェクトのコピーを格納する DataTable を返します。

CopyToDataTable<T>(IEnumerable<T>, DataTable, LoadOption)	
ジェネリック パラメーター T が DataRowされている入力 IEnumerable<T> オブジェクトが指定された DataTableに DataRow オブジェクトをコピーします。

CopyToDataTable<T>(IEnumerable<T>, DataTable, LoadOption, FillErrorEventHandler)	
ジェネリック パラメーター T が DataRowされている入力 IEnumerable<T> オブジェクトが指定された DataTableに DataRow オブジェクトをコピーします。

Aggregate<TSource>(IEnumerable<TSource>, Func<TSource,TSource,TSource>)	
アキュムレータ関数をシーケンスに適用します。

Aggregate<TSource,TAccumulate>(IEnumerable<TSource>, TAccumulate, Func<TAccumulate,TSource,TAccumulate>)	
アキュムレータ関数をシーケンスに適用します。 指定されたシード値は、初期アキュムレータ値として使用されます。

Aggregate<TSource,TAccumulate,TResult>(IEnumerable<TSource>, TAccumulate, Func<TAccumulate,TSource,TAccumulate>, Func<TAccumulate,TResult>)	
アキュムレータ関数をシーケンスに適用します。 指定したシード値が初期アキュムレータ値として使用され、指定された関数を使用して結果値が選択されます。

All<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
シーケンスのすべての要素が条件を満たすかどうかを判断します。

Any<TSource>(IEnumerable<TSource>)	
シーケンスに要素が含まれているかどうかを判断します。

Any<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
シーケンスの要素が条件を満たすかどうかを判断します。

Append<TSource>(IEnumerable<TSource>, TSource)	
シーケンスの末尾に値を追加します。

AsEnumerable<TSource>(IEnumerable<TSource>)	
IEnumerable<T>として入力された入力を返します。

Average<TSource>(IEnumerable<TSource>, Func<TSource,Decimal>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される Decimal 値のシーケンスの平均を計算します。

Average<TSource>(IEnumerable<TSource>, Func<TSource,Double>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される Double 値のシーケンスの平均を計算します。

Average<TSource>(IEnumerable<TSource>, Func<TSource,Int32>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される Int32 値のシーケンスの平均を計算します。

Average<TSource>(IEnumerable<TSource>, Func<TSource,Int64>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される Int64 値のシーケンスの平均を計算します。

Average<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Decimal>>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される null 許容 Decimal 値のシーケンスの平均を計算します。

Average<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Double>>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される null 許容 Double 値のシーケンスの平均を計算します。

Average<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int32>>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される null 許容 Int32 値のシーケンスの平均を計算します。

Average<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int64>>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される null 許容 Int64 値のシーケンスの平均を計算します。

Average<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Single>>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される null 許容 Single 値のシーケンスの平均を計算します。

Average<TSource>(IEnumerable<TSource>, Func<TSource,Single>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される Single 値のシーケンスの平均を計算します。

Cast<TResult>(IEnumerable)	
IEnumerable の要素を指定した型にキャストします。

Chunk<TSource>(IEnumerable<TSource>, Int32)	
シーケンスの要素を最大 sizeサイズのチャンクに分割します。

Concat<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)	
2 つのシーケンスを連結します。

Contains<TSource>(IEnumerable<TSource>, TSource)	
既定の等値比較子を使用して、シーケンスに指定した要素が含まれているかどうかを判断します。

Contains<TSource>(IEnumerable<TSource>, TSource, IEqualityComparer<TSource>)	
指定した IEqualityComparer<T>を使用して、シーケンスに指定した要素が含まれているかどうかを判断します。

Count<TSource>(IEnumerable<TSource>)	
シーケンス内の要素の数を返します。

Count<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
指定したシーケンス内の 1 つの条件を満たす要素の数を表す数値を返します。

DefaultIfEmpty<TSource>(IEnumerable<TSource>)	
シーケンスが空の場合は、指定したシーケンスの要素、またはシングルトン コレクション内の型パラメーターの既定値を返します。

DefaultIfEmpty<TSource>(IEnumerable<TSource>, TSource)	
シーケンスが空の場合は、指定したシーケンスの要素、またはシングルトン コレクション内の指定した値を返します。

Distinct<TSource>(IEnumerable<TSource>)	
既定の等値比較子を使用して値を比較することにより、シーケンスから個別の要素を返します。

Distinct<TSource>(IEnumerable<TSource>, IEqualityComparer<TSource>)	
指定した IEqualityComparer<T> を使用して値を比較することにより、シーケンスから個別の要素を返します。

DistinctBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
指定したキー セレクター関数に従って、シーケンスから個別の要素を返します。

DistinctBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
指定したキー セレクター関数に従ってシーケンスから個別の要素を返し、指定した比較子を使用してキーを比較します。

ElementAt<TSource>(IEnumerable<TSource>, Index)	
シーケンス内の指定したインデックス位置にある要素を返します。

ElementAt<TSource>(IEnumerable<TSource>, Int32)	
シーケンス内の指定したインデックス位置にある要素を返します。

ElementAtOrDefault<TSource>(IEnumerable<TSource>, Index)	
シーケンス内の指定したインデックス位置にある要素を返します。インデックスが範囲外の場合は既定値を返します。

ElementAtOrDefault<TSource>(IEnumerable<TSource>, Int32)	
シーケンス内の指定したインデックス位置にある要素を返します。インデックスが範囲外の場合は既定値を返します。

Except<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)	
既定の等値比較子を使用して値を比較することにより、2 つのシーケンスのセット差を生成します。

Except<TSource>(IEnumerable<TSource>, IEnumerable<TSource>, IEqualityComparer<TSource>)	
指定した IEqualityComparer<T> を使用して値を比較することにより、2 つのシーケンスのセット差を生成します。

ExceptBy<TSource,TKey>(IEnumerable<TSource>, IEnumerable<TKey>, Func<TSource,TKey>)	
指定されたキー セレクター関数に従って、2 つのシーケンスのセット差を生成します。

ExceptBy<TSource,TKey>(IEnumerable<TSource>, IEnumerable<TKey>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
指定されたキー セレクター関数に従って、2 つのシーケンスのセット差を生成します。

First<TSource>(IEnumerable<TSource>)	
シーケンスの最初の要素を返します。

First<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
指定した条件を満たすシーケンス内の最初の要素を返します。

FirstOrDefault<TSource>(IEnumerable<TSource>)	
シーケンスの最初の要素を返します。シーケンスに要素が含まれている場合は既定値を返します。

FirstOrDefault<TSource>(IEnumerable<TSource>, TSource)	
シーケンスの最初の要素を返します。シーケンスに要素が含まれている場合は、指定した既定値を返します。

FirstOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
条件を満たすシーケンスの最初の要素、またはそのような要素が見つからない場合は既定値を返します。

FirstOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>, TSource)	
条件を満たすシーケンスの最初の要素を返します。そのような要素が見つからない場合は、指定した既定値を返します。

GroupBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
指定したキー セレクター関数に従ってシーケンスの要素をグループ化します。

GroupBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
指定したキー セレクター関数に従ってシーケンスの要素をグループ化し、指定した比較子を使用してキーを比較します。

GroupBy<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>)	
指定したキー セレクター関数に従ってシーケンスの要素をグループ化し、指定した関数を使用して各グループの要素を投影します。

GroupBy<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>, IEqualityComparer<TKey>)	
キー セレクター関数に従ってシーケンスの要素をグループ化します。 キーは比較子を使用して比較され、各グループの要素は指定された関数を使用して投影されます。

GroupBy<TSource,TKey,TResult>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TKey,IEnumerable<TSource>,TResult>)	
指定したキー セレクター関数に従ってシーケンスの要素をグループ化し、各グループとそのキーから結果値を作成します。

GroupBy<TSource,TKey,TResult>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TKey,IEnumerable<TSource>,TResult>, IEqualityComparer<TKey>)	
指定したキー セレクター関数に従ってシーケンスの要素をグループ化し、各グループとそのキーから結果値を作成します。 キーは、指定された比較子を使用して比較されます。

GroupBy<TSource,TKey,TElement,TResult>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>, Func<TKey,IEnumerable<TElement>,TResult>)	
指定したキー セレクター関数に従ってシーケンスの要素をグループ化し、各グループとそのキーから結果値を作成します。 各グループの要素は、指定された関数を使用して投影されます。

GroupBy<TSource,TKey,TElement,TResult>(IEnumerable<TSource>, Func<TSource, TKey>, Func<TSource,TElement>, Func<TKey,IEnumerable<TElement>, TResult>, IEqualityComparer<TKey>)	
指定したキー セレクター関数に従ってシーケンスの要素をグループ化し、各グループとそのキーから結果値を作成します。 キー値は指定された比較子を使用して比較され、各グループの要素は指定された関数を使用して投影されます。

GroupJoin<TOuter,TInner,TKey,TResult>(IEnumerable<TOuter>, IEnumerable<TInner>, Func<TOuter,TKey>, Func<TInner,TKey>, Func<TOuter,IEnumerable<TInner>, TResult>)	
キーの等価性に基づいて 2 つのシーケンスの要素を関連付け、結果をグループ化します。 キーの比較には、既定の等値比較子が使用されます。

GroupJoin<TOuter,TInner,TKey,TResult>(IEnumerable<TOuter>, IEnumerable<TInner>, Func<TOuter,TKey>, Func<TInner,TKey>, Func<TOuter,IEnumerable<TInner>, TResult>, IEqualityComparer<TKey>)	
キーの等価性に基づいて 2 つのシーケンスの要素を関連付け、結果をグループ化します。 キーの比較には、指定した IEqualityComparer<T> が使用されます。

Intersect<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)	
既定の等値比較子を使用して値を比較することにより、2 つのシーケンスの集合積集合を生成します。

Intersect<TSource>(IEnumerable<TSource>, IEnumerable<TSource>, IEqualityComparer<TSource>)	
指定した IEqualityComparer<T> を使用して値を比較することにより、2 つのシーケンスの集合積集合を生成します。

IntersectBy<TSource,TKey>(IEnumerable<TSource>, IEnumerable<TKey>, Func<TSource,TKey>)	
指定したキー セレクター関数に従って、2 つのシーケンスの集合積集合を生成します。

IntersectBy<TSource,TKey>(IEnumerable<TSource>, IEnumerable<TKey>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
指定したキー セレクター関数に従って、2 つのシーケンスの集合積集合を生成します。

Join<TOuter,TInner,TKey,TResult>(IEnumerable<TOuter>, IEnumerable<TInner>, Func<TOuter,TKey>, Func<TInner,TKey>, Func<TOuter,TInner,TResult>)	
一致するキーに基づいて、2 つのシーケンスの要素を関連付けます。 キーの比較には、既定の等値比較子が使用されます。

Join<TOuter,TInner,TKey,TResult>(IEnumerable<TOuter>, IEnumerable<TInner>, Func<TOuter,TKey>, Func<TInner,TKey>, Func<TOuter,TInner,TResult>, IEqualityComparer<TKey>)	
一致するキーに基づいて、2 つのシーケンスの要素を関連付けます。 キーの比較には、指定した IEqualityComparer<T> が使用されます。

Last<TSource>(IEnumerable<TSource>)	
シーケンスの最後の要素を返します。

Last<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
指定した条件を満たすシーケンスの最後の要素を返します。

LastOrDefault<TSource>(IEnumerable<TSource>)	
シーケンスの最後の要素を返します。シーケンスに要素が含まれている場合は既定値を返します。

LastOrDefault<TSource>(IEnumerable<TSource>, TSource)	
シーケンスの最後の要素を返します。シーケンスに要素が含まれている場合は、指定した既定値を返します。

LastOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
条件を満たすシーケンスの最後の要素、またはそのような要素が見つからない場合は既定値を返します。

LastOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>, TSource)	
条件を満たすシーケンスの最後の要素を返します。そのような要素が見つからない場合は、指定された既定値を返します。

LongCount<TSource>(IEnumerable<TSource>)	
シーケンス内の要素の合計数を表す Int64 を返します。

LongCount<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
条件を満たすシーケンス内の要素の数を表す Int64 を返します。

Max<TSource>(IEnumerable<TSource>)	
ジェネリック シーケンスの最大値を返します。

Max<TSource>(IEnumerable<TSource>, IComparer<TSource>)	
ジェネリック シーケンスの最大値を返します。

Max<TSource>(IEnumerable<TSource>, Func<TSource,Decimal>)	
シーケンスの各要素に対して変換関数を呼び出し、最大 Decimal 値を返します。

Max<TSource>(IEnumerable<TSource>, Func<TSource,Double>)	
シーケンスの各要素に対して変換関数を呼び出し、最大 Double 値を返します。

Max<TSource>(IEnumerable<TSource>, Func<TSource,Int32>)	
シーケンスの各要素に対して変換関数を呼び出し、最大 Int32 値を返します。

Max<TSource>(IEnumerable<TSource>, Func<TSource,Int64>)	
シーケンスの各要素に対して変換関数を呼び出し、最大 Int64 値を返します。

Max<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Decimal>>)	
シーケンスの各要素に対して変換関数を呼び出し、null 許容の最大 Decimal 値を返します。

Max<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Double>>)	
シーケンスの各要素に対して変換関数を呼び出し、null 許容の最大 Double 値を返します。

Max<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int32>>)	
シーケンスの各要素に対して変換関数を呼び出し、null 許容の最大 Int32 値を返します。

Max<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int64>>)	
シーケンスの各要素に対して変換関数を呼び出し、null 許容の最大 Int64 値を返します。

Max<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Single>>)	
シーケンスの各要素に対して変換関数を呼び出し、null 許容の最大 Single 値を返します。

Max<TSource>(IEnumerable<TSource>, Func<TSource,Single>)	
シーケンスの各要素に対して変換関数を呼び出し、最大 Single 値を返します。

Max<TSource,TResult>(IEnumerable<TSource>, Func<TSource,TResult>)	
ジェネリック シーケンスの各要素に対して変換関数を呼び出し、結果の最大値を返します。

MaxBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
指定したキー セレクター関数に従って、ジェネリック シーケンスの最大値を返します。

MaxBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IComparer<TKey>)	
指定したキー セレクター関数とキー比較子に従って、ジェネリック シーケンスの最大値を返します。

Min<TSource>(IEnumerable<TSource>)	
ジェネリック シーケンスの最小値を返します。

Min<TSource>(IEnumerable<TSource>, IComparer<TSource>)	
ジェネリック シーケンスの最小値を返します。

Min<TSource>(IEnumerable<TSource>, Func<TSource,Decimal>)	
シーケンスの各要素に対して変換関数を呼び出し、最小 Decimal 値を返します。

Min<TSource>(IEnumerable<TSource>, Func<TSource,Double>)	
シーケンスの各要素に対して変換関数を呼び出し、最小 Double 値を返します。

Min<TSource>(IEnumerable<TSource>, Func<TSource,Int32>)	
シーケンスの各要素に対して変換関数を呼び出し、最小 Int32 値を返します。

Min<TSource>(IEnumerable<TSource>, Func<TSource,Int64>)	
シーケンスの各要素に対して変換関数を呼び出し、最小 Int64 値を返します。

Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Decimal>>)	
シーケンスの各要素に対して変換関数を呼び出し、null 許容の最小 Decimal 値を返します。

Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Double>>)	
シーケンスの各要素に対して変換関数を呼び出し、null 許容の最小 Double 値を返します。

Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int32>>)	
シーケンスの各要素に対して変換関数を呼び出し、null 許容の最小 Int32 値を返します。

Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int64>>)	
シーケンスの各要素に対して変換関数を呼び出し、null 許容の最小 Int64 値を返します。

Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Single>>)	
シーケンスの各要素に対して変換関数を呼び出し、null 許容の最小 Single 値を返します。

Min<TSource>(IEnumerable<TSource>, Func<TSource,Single>)	
シーケンスの各要素に対して変換関数を呼び出し、最小 Single 値を返します。

Min<TSource,TResult>(IEnumerable<TSource>, Func<TSource,TResult>)	
ジェネリック シーケンスの各要素に対して変換関数を呼び出し、結果の最小値を返します。

MinBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
指定したキー セレクター関数に従って、ジェネリック シーケンスの最小値を返します。

MinBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IComparer<TKey>)	
指定したキー セレクター関数とキー比較子に従って、ジェネリック シーケンスの最小値を返します。

OfType<TResult>(IEnumerable)	
指定した型に基づいて、IEnumerable の要素をフィルター処理します。

Order<T>(IEnumerable<T>)	
シーケンスの要素を昇順で並べ替えます。

Order<T>(IEnumerable<T>, IComparer<T>)	
シーケンスの要素を昇順で並べ替えます。

OrderBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
キーに従って、シーケンスの要素を昇順で並べ替えます。

OrderBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IComparer<TKey>)	
指定した比較子を使用して、シーケンスの要素を昇順で並べ替えます。

OrderByDescending<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
キーに従ってシーケンスの要素を降順に並べ替えます。

OrderByDescending<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IComparer<TKey>)	
指定した比較子を使用して、シーケンスの要素を降順で並べ替えます。

OrderDescending<T>(IEnumerable<T>)	
シーケンスの要素を降順で並べ替えます。

OrderDescending<T>(IEnumerable<T>, IComparer<T>)	
シーケンスの要素を降順で並べ替えます。

Prepend<TSource>(IEnumerable<TSource>, TSource)	
シーケンスの先頭に値を追加します。

Reverse<TSource>(IEnumerable<TSource>)	
シーケンス内の要素の順序を反転します。

Select<TSource,TResult>(IEnumerable<TSource>, Func<TSource,TResult>)	
シーケンスの各要素を新しいフォームに投影します。

Select<TSource,TResult>(IEnumerable<TSource>, Func<TSource,Int32,TResult>)	
要素のインデックスを組み込んで、シーケンスの各要素を新しいフォームに投影します。

SelectMany<TSource,TResult>(IEnumerable<TSource>, Func<TSource,IEnumerable<TResult>>)	
シーケンスの各要素を IEnumerable<T> に投影し、結果のシーケンスを 1 つのシーケンスにフラット化します。

SelectMany<TSource,TResult>(IEnumerable<TSource>, Func<TSource,Int32,IEnumerable<TResult>>)	
シーケンスの各要素を IEnumerable<T>に投影し、結果のシーケンスを 1 つのシーケンスにフラット化します。 各ソース要素のインデックスは、その要素の投影形式で使用されます。

SelectMany<TSource,TCollection,TResult>(IEnumerable<TSource>, Func<TSource,IEnumerable<TCollection>>, Func<TSource,TCollection,TResult>)	
シーケンスの各要素を IEnumerable<T>に投影し、結果のシーケンスを 1 つのシーケンスにフラット化し、その中の各要素に対して結果セレクター関数を呼び出します。

SelectMany<TSource,TCollection,TResult>(IEnumerable<TSource>, Func<TSource,Int32,IEnumerable<TCollection>>, Func<TSource,TCollection,TResult>)	
シーケンスの各要素を IEnumerable<T>に投影し、結果のシーケンスを 1 つのシーケンスにフラット化し、その中の各要素に対して結果セレクター関数を呼び出します。 各ソース要素のインデックスは、その要素の中間投影形式で使用されます。

SequenceEqual<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)	
型の既定の等値比較子を使用して要素を比較することで、2 つのシーケンスが等しいかどうかを判断します。

SequenceEqual<TSource>(IEnumerable<TSource>, IEnumerable<TSource>, IEqualityComparer<TSource>)	
指定した IEqualityComparer<T>を使用して要素を比較して、2 つのシーケンスが等しいかどうかを判断します。

Single<TSource>(IEnumerable<TSource>)	
シーケンスの唯一の要素を返し、シーケンス内に要素が 1 つだけ存在しない場合は例外をスローします。

Single<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
指定した条件を満たすシーケンスの唯一の要素を返し、そのような要素が複数存在する場合は例外をスローします。

SingleOrDefault<TSource>(IEnumerable<TSource>)	
シーケンスの唯一の要素を返します。シーケンスが空の場合は既定値を返します。シーケンス内に複数の要素がある場合、このメソッドは例外をスローします。

SingleOrDefault<TSource>(IEnumerable<TSource>, TSource)	
シーケンスの唯一の要素を返します。シーケンスが空の場合は、指定した既定値を返します。シーケンス内に複数の要素がある場合、このメソッドは例外をスローします。

SingleOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
指定した条件を満たすシーケンスの唯一の要素、またはそのような要素が存在しない場合は既定値を返します。このメソッドは、複数の要素が条件を満たす場合に例外をスローします。

SingleOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>, TSource)	
指定した条件を満たすシーケンスの唯一の要素、またはそのような要素が存在しない場合は指定された既定値を返します。このメソッドは、複数の要素が条件を満たす場合に例外をスローします。

Skip<TSource>(IEnumerable<TSource>, Int32)	
シーケンス内の指定された数の要素をバイパスし、残りの要素を返します。

SkipLast<TSource>(IEnumerable<TSource>, Int32)	
ソース コレクションの最後の count 要素を省略した source の要素を含む新しい列挙可能なコレクションを返します。

SkipWhile<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
指定した条件が true である限り、シーケンス内の要素をバイパスし、残りの要素を返します。

SkipWhile<TSource>(IEnumerable<TSource>, Func<TSource,Int32,Boolean>)	
指定した条件が true である限り、シーケンス内の要素をバイパスし、残りの要素を返します。 要素のインデックスは、述語関数のロジックで使用されます。

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Decimal>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される Decimal 値のシーケンスの合計を計算します。

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Double>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される Double 値のシーケンスの合計を計算します。

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Int32>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される Int32 値のシーケンスの合計を計算します。

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Int64>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される Int64 値のシーケンスの合計を計算します。

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Decimal>>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される null 許容 Decimal 値のシーケンスの合計を計算します。

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Double>>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される null 許容 Double 値のシーケンスの合計を計算します。

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int32>>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される null 許容 Int32 値のシーケンスの合計を計算します。

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int64>>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される null 許容 Int64 値のシーケンスの合計を計算します。

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Single>>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される null 許容 Single 値のシーケンスの合計を計算します。

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Single>)	
入力シーケンスの各要素で変換関数を呼び出すことによって取得される Single 値のシーケンスの合計を計算します。

Take<TSource>(IEnumerable<TSource>, Int32)	
シーケンスの先頭から指定した数の連続する要素を返します。

Take<TSource>(IEnumerable<TSource>, Range)	
シーケンスから指定した連続する要素の範囲を返します。

TakeLast<TSource>(IEnumerable<TSource>, Int32)	
sourceの最後の count 要素を含む新しい列挙可能なコレクションを返します。

TakeWhile<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
指定した条件が true である限り、シーケンスから要素を返します。

TakeWhile<TSource>(IEnumerable<TSource>, Func<TSource,Int32,Boolean>)	
指定した条件が true である限り、シーケンスから要素を返します。 要素のインデックスは、述語関数のロジックで使用されます。

ToArray<TSource>(IEnumerable<TSource>)	
IEnumerable<T>から配列を作成します。

ToDictionary<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
指定したキー セレクター関数に従って、IEnumerable<T> から Dictionary<TKey,TValue> を作成します。

ToDictionary<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
指定したキー セレクター関数とキー比較子に従って、IEnumerable<T> から Dictionary<TKey,TValue> を作成します。

ToDictionary<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>)	
指定したキー セレクターおよび要素セレクター関数に従って、IEnumerable<T> から Dictionary<TKey,TValue> を作成します。

ToDictionary<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>, IEqualityComparer<TKey>)	
指定したキー セレクター関数、比較子、および要素セレクター関数に従って、IEnumerable<T> から Dictionary<TKey,TValue> を作成します。

ToHashSet<TSource>(IEnumerable<TSource>)	
IEnumerable<T>から HashSet<T> を作成します。

ToHashSet<TSource>(IEnumerable<TSource>, IEqualityComparer<TSource>)	
キーを比較する comparer を使用して、IEnumerable<T> から HashSet<T> を作成します。

ToList<TSource>(IEnumerable<TSource>)	
IEnumerable<T>から List<T> を作成します。

ToLookup<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
指定したキー セレクター関数に従って、IEnumerable<T> から Lookup<TKey,TElement> を作成します。

ToLookup<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
指定したキー セレクター関数とキー比較子に従って、IEnumerable<T> から Lookup<TKey,TElement> を作成します。

ToLookup<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>)	
指定したキー セレクターおよび要素セレクター関数に従って、IEnumerable<T> から Lookup<TKey,TElement> を作成します。

ToLookup<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>, IEqualityComparer<TKey>)	
指定したキー セレクター関数、比較子、および要素セレクター関数に従って、IEnumerable<T> から Lookup<TKey,TElement> を作成します。

TryGetNonEnumeratedCount<TSource>(IEnumerable<TSource>, Int32)	
列挙を強制せずに、シーケンス内の要素の数を特定しようとします。

Union<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)	
既定の等値比較子を使用して、2 つのシーケンスのセット和集合を生成します。

Union<TSource>(IEnumerable<TSource>, IEnumerable<TSource>, IEqualityComparer<TSource>)	
指定した IEqualityComparer<T>を使用して、2 つのシーケンスのセット和集合を生成します。

UnionBy<TSource,TKey>(IEnumerable<TSource>, IEnumerable<TSource>, Func<TSource,TKey>)	
指定したキー セレクター関数に従って、2 つのシーケンスのセット和集合を生成します。

UnionBy<TSource,TKey>(IEnumerable<TSource>, IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
指定したキー セレクター関数に従って、2 つのシーケンスのセット和集合を生成します。

Where<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
述語に基づいて値のシーケンスをフィルター処理します。

Where<TSource>(IEnumerable<TSource>, Func<TSource,Int32,Boolean>)	
述語に基づいて値のシーケンスをフィルター処理します。 各要素のインデックスは、述語関数のロジックで使用されます。

Zip<TFirst,TSecond>(IEnumerable<TFirst>, IEnumerable<TSecond>)	
指定した 2 つのシーケンスの要素を含むタプルのシーケンスを生成します。

Zip<TFirst,TSecond,TThird>(IEnumerable<TFirst>, IEnumerable<TSecond>, IEnumerable<TThird>)	
指定された 3 つのシーケンスの要素を持つタプルのシーケンスを生成します。

Zip<TFirst,TSecond,TResult>(IEnumerable<TFirst>, IEnumerable<TSecond>, Func<TFirst,TSecond,TResult>)	
指定した関数を 2 つのシーケンスの対応する要素に適用し、結果のシーケンスを生成します。

AsParallel(IEnumerable)	
クエリの並列化を有効にします。

AsParallel<TSource>(IEnumerable<TSource>)	
クエリの並列化を有効にします。

AsQueryable(IEnumerable)	
IEnumerable を IQueryableに変換します。

AsQueryable<TElement>(IEnumerable<TElement>)	
ジェネリック IEnumerable<T> をジェネリック IQueryable<T>に変換します。

Ancestors<T>(IEnumerable<T>)	
ソース コレクション内のすべてのノードの先祖を含む要素のコレクションを返します。

Ancestors<T>(IEnumerable<T>, XName)	
ソース コレクション内のすべてのノードの先祖を含む要素のフィルター処理されたコレクションを返します。 コレクションには、一致する XName を持つ要素のみが含まれます。

DescendantNodes<T>(IEnumerable<T>)	
ソース コレクション内のすべてのドキュメントと要素の子孫ノードのコレクションを返します。

Descendants<T>(IEnumerable<T>)	
ソース コレクション内のすべての要素とドキュメントの子孫要素を含む要素のコレクションを返します。

Descendants<T>(IEnumerable<T>, XName)	
ソース コレクション内のすべての要素とドキュメントの子孫要素を含む要素のフィルター処理されたコレクションを返します。 コレクションには、一致する XName を持つ要素のみが含まれます。

Elements<T>(IEnumerable<T>)	
ソース コレクション内のすべての要素とドキュメントの子要素のコレクションを返します。

Elements<T>(IEnumerable<T>, XName)	
ソース コレクション内のすべての要素とドキュメントの子要素のフィルター処理されたコレクションを返します。 コレクションには、一致する XName を持つ要素のみが含まれます。

InDocumentOrder<T>(IEnumerable<T>)	
ドキュメントの順序で並べ替えられた、ソース コレクション内のすべてのノードを含むノードのコレクションを返します。

Nodes<T>(IEnumerable<T>)	
ソース コレクション内のすべてのドキュメントおよび要素の子ノードのコレクションを返します。

Remove<T>(IEnumerable<T>)	
ソース コレクション内のすべてのノードを親ノードから削除します。
*/

#endregion